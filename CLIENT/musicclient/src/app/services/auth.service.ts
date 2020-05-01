import { Injectable } from '@angular/core';
import {Router} from '@angular/router';

import { auth } from 'firebase/app';
import { AngularFireAuth } from '@angular/fire/auth';
import { AngularFirestore, AngularFirestoreDocument } from '@angular/fire/firestore';

import { Observable,of } from 'rxjs';
import { switchMap } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user$:Observable<any>;

  constructor(
    private afAuth:AngularFireAuth,
    private afs: AngularFirestore,
    private router: Router
  ) {
    //this.user$ = this.afAuth.authState;

    this.user$ = this.afAuth.authState.pipe(
      switchMap(user => {
        if(user) {
          return this.afs.doc<any>('users/${user.uid}').valueChanges();
        } else {
          return of(null);
        }
      })
    );
   }

   async googleSignin(){
     const provider = new auth.GoogleAuthProvider();
     const credential = await this.afAuth.signInWithPopup(provider);
     return this.updateUserData(credential.user);
   }

   private updateUserData(user) {
    // Sets user data to firestore on login
    const userRef: AngularFirestoreDocument<any> = this.afs.doc(`users/${user.uid}`);

    const data = { 
      uid: user.uid, 
      email: user.email, 
      displayName: user.displayName, 
      photoURL: user.photoURL
    } 

    return userRef.set(data, { merge: true })

  }

  async signOut() {
    //await this.afAuth.auth.signOut();
    await this.afAuth.signOut();
    this.router.navigate(['/']);
  }

}
