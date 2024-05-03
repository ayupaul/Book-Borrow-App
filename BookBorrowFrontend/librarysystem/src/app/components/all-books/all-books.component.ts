import { Component } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-all-books',
  templateUrl: './all-books.component.html',
  styleUrls: ['./all-books.component.css']
})
export class AllBooksComponent {
  allBooks:any
  constructor(private bookService:BookService,private userService:UserService){}
  ngOnInit(): void {
    const userId=this.userService.getUserIdFromToken();
    this.bookService.getAllBooksAddedByOthers(userId).subscribe((res)=>{
      console.log(res);
      this.allBooks=res;
    },(error)=>{
      console.log(error);
    })
  }
}
