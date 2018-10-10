import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  constructor(private http: HttpClient) { }
baseUrl: any = environment.apiUrl;
  Values: any;
  ngOnInit() {
    this.LoadValues();
  }
  LoadValues() {
    return this.http.get(this.baseUrl + 'values').subscribe( response => {

      this.Values = response;
    } , error => {
console.log(error);

    });
  }
  // GenerateRequestOptions () {
  //   const options = new requesto
  // }

}
