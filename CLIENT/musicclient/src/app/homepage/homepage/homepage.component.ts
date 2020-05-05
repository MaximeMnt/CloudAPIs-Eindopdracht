import { Component, OnInit } from '@angular/core';
import { ApiService, ITrack, IArtist } from '../../services/api.service';
import { AuthService } from '../../services/auth.service'
import { interval } from 'rxjs';



@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {


  constructor(public auth: AuthService, public api: ApiService) {
      interval(2000).subscribe(x => {
        this.refreshData();
      });
  }
  public tracks: ITrack;
  public artists: IArtist;
  ngOnInit() {
  }

  refreshData(){
    this.getTracks();
    this.getArtists();
  }

  getTracks() {
    this.api.getTracks().subscribe(tracks => {
      //console.log(tracks);
      this.tracks = tracks;

      //console.log(this.tracks[0].artists[0].artist.name);
    })
  }

  getArtists(){
    this.api.getArtists().subscribe(artists=>{
      this.artists = artists;
    })
  }

}
