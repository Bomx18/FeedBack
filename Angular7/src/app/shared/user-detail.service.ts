import { Injectable } from '@angular/core';
import { UserDetail, MessageDetail, Theme } from './user-detail.model';
import { HttpClient } from '@angular/common/http'
import { stringify } from '@angular/compiler/src/util';


@Injectable({
  providedIn: 'root'
})

export class UserDetailService {


  readonly rootURL = 'http://bomx19-001-site1.itempurl.com/api';
  // readonly rootURL = 'http://localhost:53916/api'; 
  str: string;
  listMessage: MessageDetail[];
  listTheme: Theme[];
  listUser: UserDetail[];

  formData: UserDetail;
  formDataMS: MessageDetail;
  formDataTh: Theme;
  constructor(private http: HttpClient) { }



  GetlistMessage() {
    this.http.get(this.rootURL + '/MessageDetailsController2')
      .toPromise()
      .then(res => this.listMessage = res as MessageDetail[]);

  }

  GetlistTheme() {
    this.http.get(this.rootURL + '/ThemeDetails')
      .toPromise()
      .then(res => this.listTheme = res as Theme[]);
  }

  GetlistUser() {
    this.http.get(this.rootURL + '/UserDetailsController2')
      .toPromise()
      .then(res => this.listUser = res as UserDetail[]);
  }

  postUserDetail(formData: UserDetail, ) {
    return this.http.post(this.rootURL + '/UserDetailsController2', formData);
  }

  postMessageDetail(formDataMS: MessageDetail, ) {
    return this.http.post(this.rootURL + '/MessageDetailsController2', formDataMS);
  }

}
