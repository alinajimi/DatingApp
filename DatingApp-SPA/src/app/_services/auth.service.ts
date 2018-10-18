import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import {map} from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private httpclient: HttpClient) { }
currentUserToken: any;
decodedToken: any;
 jwtHelper = new JwtHelperService();
login(model: any) {
  return this.httpclient.post(environment.apiUrl + 'auth/login' , model).pipe(

    map((response: any) => {
      const user = response;
      if( user) {
        localStorage.setItem('token' , user.token);
        this.currentUserToken = user.token;
     this.decodedToken = this.jwtHelper.decodeToken(user.token);
      }

    } )
  );


}
register(model: any) {
  return this.httpclient.post(environment.apiUrl + 'auth/register' , model);
}
isLoggedIn() {
const token = localStorage.getItem('token');
return this.jwtHelper.isTokenExpired(token);

}
}

