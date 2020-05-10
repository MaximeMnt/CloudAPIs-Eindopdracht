import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class ApiService {

	constructor(private http: HttpClient) { }

	//CREATE -- INSERT
	createTrack(track:ITrack) {
		return this.http.post<ITrack>('http://localhost:6123/api/tracks',track);
	}

	createArtist(Artist:IArtist){
		return this.http.post<IArtist>('http://localhost:6123/api/artists',Artist);
	}

	//READ
	getTracks() {
		return this.http.get<ITrack>('http://localhost:6123/api/tracks');
	}

	getArtists() {
		return this.http.get<IArtist>('http://localhost:6123/api/artists');
	}
}







export interface IArtist {
	artistID: number;
	name: string;
	socials: any;
	tracks: ITrack[];
}

export interface ITrack {
	trackID: number;
	title: string;
	album: string;
	genre: string;
	year: number;
	bpm: number;
	key: string;
	artists: IArtist[];
}


// export interface IArtist{
//   artistID:number;
//   name:string;
//   socials:any[];
// }