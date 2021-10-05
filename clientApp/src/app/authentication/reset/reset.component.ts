import { MessageService } from 'primeng/api';
import { AuthService } from 'src/app/core/service/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import {confirmedPasswordValidator} from './password-confirmed.validator';
@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',
  styleUrls: ['./reset.component.scss'],
  providers: [MessageService]
})
export class ResetComponent implements OnInit {

  chanagePasswordForm:FormGroup;
  submited = false;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.chanagePasswordForm = this.formBuilder.group({
      schoolDomain:['', Validators.required],
      email:['', Validators.required,Validators.email],
      password:['', Validators.required, Validators.minLength(6)],
      confirmPassword:['', Validators.required]
    },{
      validator:confirmedPasswordValidator('password', 'confirmPassword')
    });
  }

  get f() {
    return this.chanagePasswordForm.controls;
  }

  onSubmit() 
  {
    this.submited = true;

    if (this.chanagePasswordForm.invalid)
    {
      return;
    }
    else
    {
      this.authService.resetPassword(this.chanagePasswordForm.value)
      .subscribe(response=>{
        if(response.isSuccess)
        {
          this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
        }
        else
        {
          this.messageService.add({severity:'error', summary: 'error', detail: response.message});
        }
      },error=>{
        this.messageService.add({severity:'error', summary: 'error', detail:"Network error has been occured. Please try again."});
      });
      
    }
  }

 

}
