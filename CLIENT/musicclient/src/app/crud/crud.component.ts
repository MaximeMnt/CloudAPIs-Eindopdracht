import { Component, OnInit } from '@angular/core';
import { ApiService, IArtist, ITrack } from '../services/api.service';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { ɵBrowserPlatformLocation } from '@angular/platform-browser';

@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.scss']
})
export class CRUDComponent implements OnInit {

  public Selected;
  public artists: IArtist;
  firstFieldCreated: boolean = false;

  myForm: FormGroup;
  selectedArtist: any;

  constructor(public api: ApiService, private fb: FormBuilder) {
    this.getArtists();
  }


  ngOnInit() {
       this.myForm = this.fb.group({
      socials: this.fb.array([])
    })
    this.myForm.valueChanges.subscribe(console.log);
  }

  //  --CREATE--
  get ArtistForms() {
    return this.myForm.get('socials') as FormArray
  }

  addField() {
    this.firstFieldCreated = true;
    const phone = this.fb.group({
      url: [],
    });

    this.ArtistForms.push(phone);
  }

  deleteURL(i) {
    this.ArtistForms.removeAt(i);
  }

  CreateTrack(title, album, genre, year, bpm, key) {
    console.log("title " + title);
    console.log("a " + album);
    console.log("g " + genre);
    console.log("y " + year);
    console.log("b " + bpm);
    console.log("k " + key);
    console.log(this.selectedArtist);
    
    var body = {
      title: title,
      album: album,
      genre: genre,
      year: year,
      bpm: bpm,
      key: key,
      artists: [{
        name: this.selectedArtist
      }]
    }

    this.api.createTrack(body);
    console.log(JSON.stringify(body));
    //TODO: Eerst converteren naar JSON: Dan pas kunnen we een nieuwe track sturen naar de db
    //juiste formaat:
    //   {
    //     title: "on my mind",
    //     album: "Soulswing flips",
    //     genre: "Hip/Hop",
    //     year: 2018,
    //     bpm: 75,
    //     key: "Bbm",
    //     artists: [
    //       {
    //             artist: {
    //                 Name: "Tera Kòrá",
    //                 socials: [
    //                            {
    //                                url: "http://terakora.bandcamp.com",
    //                                url: "https://soundcloud.com/tera-kora",
    //                                url: "https://www.instagram.com/terakoraa/"
    //                            }]
    //             }
    //         }
    //     ]
    // }

  }

  CreateArtist(Artistname) {
    var body = {
      name: Artistname,
      socials: [{
        url: null
      }]
    }
    body.socials.pop();
    body.socials.push(this.ArtistForms.value);



    this.api.createArtist(body);
    console.log(JSON.stringify(body));


  //   {

  //     name: "TEST",
  //     socials: [
  //         {
  //             url: "https://test.org"
  //         },
  //         {
  //             url: "https://test.com"
  //         }
  //     ]
  // }

  }
  

  getArtists() {
    this.api.getArtists().subscribe(artists => {
      this.artists = artists;
    })
  }

  // --END CREATE--
}
