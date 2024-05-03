import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  availableBooks:any
  userId:any
  availableToken:any
  word:any
  constructor(private userStoreService:UserStoreService,private userService:UserService,private bookService:BookService,private route:Router){}
  ngOnInit(): void {
    const username=this.userService.getUsernameFromToken();
    this.userId=this.userService.getUserIdFromToken();
    this.userStoreService.setData(username);
    this.bookService.getAvailableBooks().subscribe((res)=>{
      console.log(res);
      this.availableBooks=res;
    },(error)=>{
      console.log(error);
    })
    this.userService.getAvailableToken(this.userId).subscribe((res)=>{
      this.availableToken=res;
      this.userStoreService.setDashboardToken(this.availableToken);
    })
  }
  viewDetails(id:any){
    this.route.navigate(["viewDetails",id]);
  }
}
