import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
showRegister = true;
  constructor() { }

  ngOnInit() {
  }
  register() {
    this.showRegister =  !this.showRegister;
  }
  hideRegister(value) {
    this.showRegister = true;
  }

}
