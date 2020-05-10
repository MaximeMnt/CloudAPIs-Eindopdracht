import { Component, OnInit } from '@angular/core';
import { ApiService, IArtist } from '../services/api.service';
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
    // const phone = this.fb.group({
    //   line: [],
    // })

    this.myForm = this.fb.group({
      socials: this.fb.array([])
    })
    this.myForm.valueChanges.subscribe(console.log);
  }

  get phoneForms() {
    return this.myForm.get('socials') as FormArray
  }

  addField() {
    this.firstFieldCreated = true;
    const phone = this.fb.group({
      url: [],
    });

    this.phoneForms.push(phone);
  }

  deleteURL(i) {
    this.phoneForms.removeAt(i);
  }

  CreateTrack(title, album, genre, year, bpm, key) {
    console.log("title " + title);
    console.log("a " + album);
    console.log("g " + genre);
    console.log("y " + year);
    console.log("b " + bpm);
    console.log("k " + key);
    console.log(this.selectedArtist);

    //TODO: Eerst converteren naar JSON: Dan pas kunnen we een nieuwe track sturen naar de db
    //juiste formaat:
    //   {
    //     title: "R.A.F. (Rien à foutre)",
    //     album: "Wie Is Guy?",
    //     genre: "Hip/Hop",
    //     year: 2019,
    //     bpm: 130,
    //     key: "Amin",
    //     artists: [
    //       {
    //             artist: {
    //                 name: "Zwangere Guy",
    //                 socials: null
    //             }
    //         }
    //     ]
    // }

  }

  CreateArtist(Artistname) {
    console.log(Artistname);
    console.log(this.phoneForms.value[0]);
  }

  getArtists() {
    this.api.getArtists().subscribe(artists => {
      this.artists = artists;
    })
  }

}
