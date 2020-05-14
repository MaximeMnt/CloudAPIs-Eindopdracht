import { Component, OnInit } from '@angular/core';
import { ApiService, IArtist, ITrack } from '../services/api.service';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';


@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.scss']
})
export class CRUDComponent implements OnInit {

  public Selected;
  firstFieldCreated: boolean = false;

  myForm: FormGroup;
  selectedArtist: any;

  constructor(public api: ApiService, private fb: FormBuilder) {
    this.getArtists();
    this.getTracks();
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
  
    // --END CREATE--

    // -- READ -- 
    public selectedSearch:any
    public artists: IArtist;
    public tracks:ITrack;
    public SearchKeyWord:string;
    public trackSearchResults:ITrack;

    public length;
    public page;
    public sortType;
    public sortMethod;
  getArtists() {
    this.api.getArtists().subscribe(artists => {
      this.artists = artists;
    })
  }


  getTracks(){
    this.api.getTracks().subscribe(tracks => {
      this.tracks = tracks;  
    })
  }
  
  getPageTracks(){
    this.api.getTracksPage(this.page, this.length).subscribe(tracks => {
      this.tracks = tracks;
    })
  }
  getTracksSearchResults(){
    this.api.SearchTracks(this.selectedSearch,this.SearchKeyWord).subscribe(tracks =>{
      this.tracks = tracks;
    })
  }

  sortResults(){
    this.api.SortTracks(this.sortType, this.sortMethod).subscribe(tracks =>{
      this.tracks = tracks;
    })
  }


}
