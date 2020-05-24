# CloudAPIs-Eindopdracht - Music Client - Maxime Minta

Music client en API is een service waarmee de gebruiker data van een liedje kan bekijken, toevoegen, verwijderen of aanpassen. Het is enkel mogelijk om data toe te voegen, verwijderen, ... als de user ingelogd is.

## Laten we beginnen met de ASP .NET Core Applicatie

Deze instructies laten je toe om de ASP .NET Core applicatie succesvol op te zetten op je lokale machine voor development en testing doeleinden.

### Installatie:

Om het project te kunnen runnen moet je eerst beschikken over de juiste versie van .NET Core SDK, deze kan gedownload worden op [Download .NET Core 3.1 SDK](https://aka.ms/dotnet-download)
Eens geïnstalleerd, navigeer naar het project en voer het volgende commando uit: ```dotnet restore```
Dit commando gaat alle dependencies installeren.

Het project kan gebuild worden met:
```dotnet publish Release```

### Gebruik

Na het opstarten van het project zijn er standaard een aantal routes beschikbaar:
```
https://localhost:6123/api/tracks
https://localhost:6123/api/artists
https://localhost:6123/api/URLs
```
Elke route ondersteunt volledige CRUD functionaliteit, BEHALVE de url klasse, deze klasse ondersteunt enkel *POST*,*PUT* & *DELETE* requests omdat het voor deze applicatie niet nodig was om een *GET* request te ondersteunen.

**Paging, sorting, searching wordt ook ondersteund bij tracks & artists**

## Angular Client applicatie

Voor het openen van de angular applicatie, zorg ervoor dat zowel Node.js,npm en Angular CLI geïnstalleerd is.
Zo niet, kan dit op:
* [NodeJs](https://nodejs.org/en/download/)
* [npm](https://www.npmjs.com/get-npm)
* [angular cli](https://cli.angular.io/)

### Installatie

Het installeren van het project begint met het uitvoeren van een
```npm install```

Het uitvoeren van het project kan via
```npm start```

In development omgeving start de client standaard op op het volgende adres:
```localhost:4000```

### Gebruik

De client geeft de user de mogelijkheid om op een gemakkelijke manier data uit de database te lezen, data toe te voegen, aan te passen of te verwijderen.
Op de homepagina wordt alle data getoond zonder searching paging & sorting. Om toch de data te kunnen sorteren of zoeken, ... Moet de user navigeren naar de CRUD pagina. Daar worden alle CRUD operaties uitgevoerd.
Om als user de data vanuit de database te kunnen lezen moet er ingelogd worden. De login methode die gebruikt is geweest is [Firebase Authentication](https://firebase.google.com/docs/auth/)


Als Third party api wordt er gebruik gemaakt van de [Chuck norris jokes api](https://api.chucknorris.io/)
Deze toont wanneer een user niet is ingelogd en op een knop drukt een mopje.

## License

MIT License

Copyright (c) 2020 Maxime Minta

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
