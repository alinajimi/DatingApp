import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private httpclient: HttpClient) { }
currentUserToken: any;
decodedToken: any;
login(model: any) {
  return this.httpclient.post(environment.apiUrl + 'auth/login' , model).pipe(

    map((response: any) => {
      const user = response;
      if( user) {
        localStorage.setItem('token' , user.token);
        this.currentUserToken = user.token;
      console.log(user.token);
      }

    } )
  );


}
register(model: any) {
  return this.httpclient.post(environment.apiUrl + 'auth/register' , model);
}
}

