import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class ApiService {

	constructor(private http: HttpClient) { }

	//CREATE -- INSERT
	createTrack(track) {
		return this.http.post<ITrack>('http://localhost:6123/api/tracks',track);
	}

	createArtist(Artist){
		return this.http.post<IArtist>('http://localhost:6123/api/artists',Artist);
	}

	//READ
	getTracks() {
		return this.http.get<ITrack>('http://localhost:6123/api/tracks');
	}

	getTracksPage(page:number,length:number = 5){
		return this.http.get<ITrack>('http://localhost:6123/api/tracks?page=' + page + '&length=' + length);

	}

	getArtists() {
		return this.http.get<IArtist>('http://localhost:6123/api/artists');
	}
	
	SearchTracks(type:string, search:any){
		return this.http.get<ITrack>('http://localhost:6123/api/tracks?' + type + '=' + search);
	}

	SortTracks(type:string, dir:string){
		return this.http.get<ITrack>('http://localhost:6123/api/tracks?sort=' + type + '&dir=' + dir);
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