import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-books-lent',
  templateUrl: './books-lent.component.html',
  styleUrls: ['./books-lent.component.css']
})
export class BooksLentComponent implements OnInit {
  lentBooks:any
  constructor(private bookService:BookService,private userService:UserService){}
  ngOnInit(): void {
    const userId=this.userService.getUserIdFromToken();
    this.bookService.getLentBooks(userId).subscribe((res)=>{
      console.log(res);
      this.lentBooks=res;
    },(error)=>{
      console.log(error);
    })
  }

}
