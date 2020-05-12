import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { AuthService } from '../auth.service';
import { async } from '@angular/core/testing';

@Injectable()
export class AuthHeaderInterceptor implements HttpInterceptor{
    
    constructor(public auth: AuthService) {
    }


    intercept(request: HttpRequest<any>, next: HttpHandler){
        //const authToken = "Bearer " + this.auth.accessToken ;
        let authToken
        if(this.auth.accessToken.i != undefined){
             authToken = "Bearer " + this.auth.accessToken.i.token; //authentication header moet hier nog bijkomen zonder te hardcoden
        }
        else { authToken = "" }
        //console.log(this.auth.accessToken);
        //console.log(this.auth.accessToken.i.token);
        const authReq = request.clone({
            setHeaders: {Authorization: authToken}
        });
        return next.handle(authReq);
    }
}