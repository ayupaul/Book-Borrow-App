import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-searched-books',
  templateUrl: './searched-books.component.html',
  styleUrls: ['./searched-books.component.css']
})
export class SearchedBooksComponent implements OnInit {
  word:any
  searchedBooks:any
  constructor(private router:ActivatedRoute,private bookService:BookService,private route:Router){
    this.router.params.subscribe((param)=>{
      this.word=param['word'];
    })
  }
  ngOnInit(): void {
        this.bookService.searchBooks(this.word).subscribe((res)=>{
          console.log(res);
          this.searchedBooks=res;
        },(error)=>{
          console.log(error);
        })
  }
  viewDetails(id:any){
    this.route.navigate(["viewDetails",id]);
  }
}
