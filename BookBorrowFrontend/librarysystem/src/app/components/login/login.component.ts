import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm:FormGroup
  constructor(private formBuilder:FormBuilder,private route:Router,private userService:UserService,private toastr: ToastrService){
    this.loginForm=this.formBuilder.group({
      username:"",
      password:''
    });
}
onLogin(){
  console.log(this.loginForm.value);
  this.userService.login(this.loginForm.value).subscribe((res)=>{
    console.log(res.token);
    this.userService.storeToken(res.token);
    const name=this.userService.getUsernameFromToken();
    this.toastr.success(`Hi ${name}`);
    this.route.navigateByUrl("/dashboard");
  },
  (error)=>{
   this.toastr.error("Login failed");
    console.log(error);
  })
}
}
