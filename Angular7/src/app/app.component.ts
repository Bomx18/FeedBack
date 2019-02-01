import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles : []
})
export class AppComponent {
  title = 'Angular7';
  
}
export interface FormModel {
  captcha?: string;
}

