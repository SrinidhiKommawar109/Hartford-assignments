import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive-form',
  imports: [ReactiveFormsModule],
  templateUrl: './reactive-form.html',
  styleUrl: './reactive-form.css',
})
export class ReactiveForm {
  /*
  email = new FormControl('');
  password = new FormControl('');
  login(){
    console.log(this.email.value,this.password.value);
  }
  resetForm(){
    this.email.setValue("");
    this.password.setValue
    ("");
  }
    */

  loginForm = new FormGroup({
    name : new FormControl('',[Validators.required,Validators.minLength(3),Validators.maxLength(20)]),
    email : new FormControl('',[Validators.required,Validators.email,Validators.maxLength(40)]),
    password : new FormControl('',[Validators.required,Validators.minLength(8),Validators.maxLength(16)]),
  });
  get name(){
    return this.loginForm.get('name');
  }
  get email(){
    return this.loginForm.get('email');
  }
  get password(){
    return this.loginForm.get('password');
  }
  handleProfile(){
    console.log(this.loginForm.value);
  }
  reset(){
    this.loginForm.setValue({name: '', email: '', password: ''});
  }
  }

