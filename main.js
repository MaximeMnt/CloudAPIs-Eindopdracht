const { app, BrowserWindow } = require('electron');


let win;

function createWindow () {
    // Create the browser window.
    win = new BrowserWindow({
      width: 600, 
      height: 600,
      backgroundColor: '#ffffff',
      icon: `file://${__dirname}/dist/assets/logo.png`
    })

    win.loadURL('file://${__dirname}/dist/index.html')



    //om de chrome dev tools te gebruiken:
    win.webContents.openDevTools();


    //event when window is closed.
    win.on('closed', function() { win = null});

    //create window on electron initialization
    app.on('ready', createWindow);

    //quit when all windows are closed.
    app.on('window-all-closed', function(){

        //voor macOs close process
        if(process.platform !== 'darwin'){
            app.quit();
        }
    })

    app.on('activate', function () {
        // macOS specific close process
        if (win === null) {
          createWindow()
        }
      })
}