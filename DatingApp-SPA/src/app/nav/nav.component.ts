import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { retry } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
  constructor( private auth: AuthService) { }

  ngOnInit() {
  }
  isLoggedIn() {
  const token=localStorage.getItem('token');
  if( token) {
    return true;
  }
  return false;
  }
  login() {
    this.auth.login(this.model).subscribe( next => {

      console.log('logged in');
    } , error => {

      console.log(error);
    });
  }
  logOut() {
    localStorage.removeItem('token');
  console.log('logged out');
  }

}
