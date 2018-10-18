import { AlertifyService } from './../_services/alertify.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() showRegister = new EventEmitter<boolean> ();
  @Input() inputTest: any;
model: any = {} ;
  constructor(private auth: AuthService , private alertify: AlertifyService) { }

  ngOnInit() {
  }
  cancel() {
    this.showRegister.emit(false);
  }

  register() {

this.auth.register(this.model).subscribe(next => {
  this.alertify.success('registered successfully');
} , error => { this.alertify.error('there was an error'); });
  }

} 
