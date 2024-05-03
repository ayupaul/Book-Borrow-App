import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-borrowed-books',
  templateUrl: './borrowed-books.component.html',
  styleUrls: ['./borrowed-books.component.css']
})
export class BorrowedBooksComponent implements OnInit {
  userId:any;
  borrowedBooks:any
  availableToken:any
  constructor(private userService:UserService,private bookService:BookService,private userStoreService:UserStoreService){
    this.userId= this.userService.getUserIdFromToken();
  }
  ngOnInit(): void {
     this.bookService.getBorrowedBooks(this.userId).subscribe((res)=>{
      console.log(res);
      this.borrowedBooks=res;
     },(error)=>{
      console.log(error);
     })
    this.userService.getAvailableToken(this.userId).subscribe((res)=>{
      this.availableToken=res;
      this.userStoreService.setAvailableToken(this.availableToken);
      localStorage.setItem('finalToken',this.availableToken);
    })
  }
}
