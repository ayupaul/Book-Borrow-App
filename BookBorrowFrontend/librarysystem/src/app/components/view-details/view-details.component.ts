import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookService } from 'src/app/services/book.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-view-details',
  templateUrl: './view-details.component.html',
  styleUrls: ['./view-details.component.css']
})
export class ViewDetailsComponent implements OnInit {
  book:any
  bookId:any
  lentByUserId:any
  lenderName:any
  userId:any
  currentRating:any
  avlbToken:any
  constructor(private bookService:BookService,private router:ActivatedRoute,private userService:UserService,private route:Router,private userStoreService:UserStoreService,private toastr:ToastrService){
    this.router.params.subscribe((params)=>{
      this.bookId=params['id'];
    })
  }
  ngOnInit(): void {
    this.bookService.getBookById(this.bookId).subscribe((res)=>{
      console.log(res);
      this.book=res;
      this.currentRating=this.book.rating;
      this.bookService.getLentedUserId(this.book.bookId).subscribe((reso)=>{
        this.lentByUserId=reso;
        console.log(reso);
        this.userService.getUserById(this.lentByUserId).subscribe((resp)=>{
          console.log(resp.name);
          this.lenderName=resp.name;
          const id=this.userService.getUserIdFromToken();
          
          console.log(resp);
        },(error)=>{
          console.log(error);
        })
      },(error)=>{
        console.log(error);
      })
    
      this.userId=this.userService.getUserIdFromToken();
      
    },(error)=>{
      console.log(error);
    })
   
  }
  borrow(bookId:any){
    const userId=this.userService.getUserIdFromToken();
    this.userService.getAvailableToken(userId).subscribe((resp)=>{
      this.avlbToken=resp;
      console.log(this.avlbToken);
      if(this.avlbToken>0){
        if(userId!==this.lentByUserId){
        this.bookService.borrowBook(bookId,userId).subscribe((res)=>{
          this.route.navigateByUrl("/borrowedBooks");
        
        },(error)=>{
          console.log(error);
        })
      }
    }
    else{
      this.toastr.error("Insufficient token");
    }
    })
   
  }
}
