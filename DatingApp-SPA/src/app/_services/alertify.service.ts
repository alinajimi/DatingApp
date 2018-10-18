import { element } from 'protractor';
import { Injectable } from '@angular/core';

declare let alertify: any;
@Injectable({
  providedIn: 'root'
})

export class AlertifyService {
  

constructor() { }

Confirm(message: string , okCallback: () => any) {
  alertify.confirm(message , function(e) {

    if (e) {
      okCallback();
    }  else {

    }
  });

}
alert(message: string) {
  alertify.alert(message);
}
warning(message: string) {
  alertify.warning(message);
}
error(message: string) {
  alertify.error(message);
}

success(message: string) {
  alertify.success(message);
}
message(message: string) {
  alertify.message(message);
}
}
