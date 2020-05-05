import { Component, OnInit } from '@angular/core';
import { ApiService, ITrack } from '../../services/api.service';
import { AuthService } from '../../services/auth.service'
import { interval } from 'rxjs';



@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {


  constructor(public auth: AuthService, public api: ApiService) {
      this.getTracks();
      interval(1000).subscribe(x => {
        this.getTracks();
      });
  }
  public tracks: ITrack;

  ngOnInit() {
  }

  getTracks() {
    this.api.getTracks().subscribe(tracks => {
      //console.log(tracks);
      this.tracks = tracks;

      console.log(this.tracks[0].artists[0].artist.name);
    })

    
    
  }

}
