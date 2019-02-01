import { Component, OnInit, ViewChild, VERSION } from '@angular/core';
import { UserDetailService } from 'src/app/shared/user-detail.service';
import { NgForm, FormGroup, FormControl, Validators, FormsModule } from '@angular/forms';
import { textBinding } from '@angular/core/src/render3';
import { from } from 'rxjs';
import { getListeners } from '@angular/core/src/render3/discovery_utils';
import { Services } from '@angular/core/src/view';
import { ToastrService } from 'ngx-toastr';
import { FormModel } from 'src/app/app.component';
import { UserDetail, MessageDetail, Theme } from 'src/app/shared/user-detail.model';
import { stringify } from '@angular/core/src/render3/util';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styles: []
})


export class UserDetailComponent implements OnInit {
  public formModel: FormModel = {};
  public Userform: UserDetail;

  enableEdit: boolean = false;
  ShowUser: string;
  ShowEmail: string;
  ShowPhone: string;
  ShowTheme: string;
  ShowMessage: string;

  str: string;

  resolved(captchaResponse: string) {
    console.log(`Resolved captcha with response ${captchaResponse}:`);
  }
  constructor(public service: UserDetailService,
    private toastr: ToastrService) {
  }

  ngOnInit() {
    this.service.GetlistUser();
    this.service.GetlistTheme();
    this.service.GetlistMessage();
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      UserID: 0,
      UserName: '',
      UserEmail: '',
      UserNumPhone: '',
      IDMessage: 0,
      IDTheme: 0
    }
    this.service.formDataTh = {
      ThemeID: 0,
      TextTheme: ''
    }
    this.service.formDataMS = {
      MessageID: 0,
      TextMessage: ''
    }
    this.formModel = {
      captcha: ''
    }
    this.str = ''
  }

  onSubmit(form: NgForm) {

    console.log(form.value);
    
    //запись в базу через два контроллера 
  this.service.postUserDetail(form.value).subscribe(
        res => {
          this.service.postMessageDetail(form.value).subscribe(
            res => {
              this.enableEdit=true;
              
              this.service.GetlistUser();
              this.resetForm(form);
            },
            err => {
              console.log(err);
            }
          )
          this.resetForm(form);
        },
        err => {
          console.log(err);
        }
      )
      
      /*ShowUser: string;
      ShowEmail: string;
      ShowPhone: string;
      ShowTheme: string;
      ShowMessage: string;*/



  }

  selectOption(id: number) {
    this.service.formData.IDTheme = id;

  }
  public SetVal(form?: NgForm) {

    this.service.GetlistMessage();
    try {
      this.service.formData.IDMessage = this.service.listMessage[this.service.listMessage.length - 1].MessageID+1;
    }
    catch (e) {
      this.service.formData.IDMessage = 1;
    }


    console.log(this.str);

    //this.listMessage[0].MessageID;
    //console.log(this.listMessage[0].MessageID);
    this.service.GetlistUser();
    this.service.GetlistTheme();

    this.ShowUser = this.service.formData.UserName;
    this.ShowEmail = this.service.formData.UserEmail;
    this.ShowPhone = this.service.formData.UserNumPhone;
    this.ShowTheme = this.service.listTheme[+this.service.str - 1].TextTheme;
    this.ShowMessage = this.service.formDataMS.TextMessage;

  }
  //ввод только цифр в <input>
  public restrictNumeric(e) {
    let input;
    if (e.metaKey || e.ctrlKey) {
      return true;
    }
    if (e.which === 32) {
      return false;
    }
    if (e.which === 0) {
      return true;
    }
    if (e.which < 33) {
      return true;
    }
    input = String.fromCharCode(e.which);
    return !!/[\d\s]/.test(input);
  }
}
