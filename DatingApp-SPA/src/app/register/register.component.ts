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
  constructor(private auth: AuthService) { }

  ngOnInit() {
  }
  cancel() {
    this.showRegister.emit(false);
  }

  register() {

this.auth.register(this.model).subscribe(next => {
  console.log(next);
} , error => { console.log(error); });
  }

} 
