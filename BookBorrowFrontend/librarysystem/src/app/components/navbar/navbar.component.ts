import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserStoreService } from 'src/app/services/user-store.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  username:any
  availableToken:any
  userId:any
  word:any
  tokenFromLocal:any
  constructor(private route:Router,private userService:UserService,private userStoreService:UserStoreService){
    this.userStoreService.getData().subscribe((res)=>{
      this.username=res||this.userService.getUsernameFromToken();
      
    })
     this.userStoreService.getAvailableToken().subscribe((res)=>{
     this.tokenFromLocal=this.userService.getAvailableTokenFromToken();
      this.userStoreService.getDashboardToken().subscribe((resp)=>{
        this.availableToken=res||resp||localStorage.getItem('finalToken')||this.tokenFromLocal;
      
      })
    
     })
  }
  onLogout(){
    localStorage.clear();
    this.route.navigateByUrl("");
  }
  search(){
    this.route.navigate(['search',this.word]);
  }
}
