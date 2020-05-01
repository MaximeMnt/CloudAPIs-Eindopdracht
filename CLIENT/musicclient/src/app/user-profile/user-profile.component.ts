import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ApiService, ITrack } from '../services/api.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  public tracks:ITrack[] = [];

  constructor(public auth: AuthService, public api:ApiService) { }

  ngOnInit() {
    this.api.getTracks().subscribe(Tracks =>{
      this.tracks.push(Tracks);
      console.log(Tracks);
    })
  }

public showauth(){
  this.auth.user$.forEach(element => {
    console.log(element);
  });
}

}
