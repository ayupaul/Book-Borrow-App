import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  Backend:string="http://localhost:5030/api/Book"
  constructor(private http:HttpClient,private userService:UserService) { }

  //add book
  addBook(bookDetails:any):Observable<any>{
    const userId=this.userService.getUserIdFromToken();
    return this.http.post(`${this.Backend}/addBook/${userId}`,bookDetails);
  }

  //get available books
  getAvailableBooks():Observable<any>{
    return this.http.get(`${this.Backend}/getAvaiableBooks`);
  }

  //get book by id
  getBookById(id:any):Observable<any>{
    return this.http.get(`${this.Backend}/getBookById/${id}`);
  }
  //borrow book
  borrowBook(bookId:any,userId:any):Observable<any>{
    const payload = { userId: userId }; 
    return this.http.post(`${this.Backend}/borrow/${bookId}`,payload);
  }
  //get book borrowed by user
  getBorrowedBooks(userId:any):Observable<any>{
    return this.http.get(`${this.Backend}/getBookBorrowed/${userId}`);
  }
  //get book lent by user
  getLentBooks(userId:any):Observable<any>{
    return this.http.get(`${this.Backend}/getBookLent/${userId}`);
  }
  //get all books added by others
  getAllBooksAddedByOthers(userId:any):Observable<any>{
    return this.http.get(`${this.Backend}/getAllBooksAddedByOthers/${userId}`);
  }

  //search books
  searchBooks(word:any):Observable<any>{
    return this.http.get(`${this.Backend}/search/${word}`);
  }
  //get lented User Id
  getLentedUserId(bookId:any):Observable<any>{
    return this.http.get(`${this.Backend}/getLenderUserId/${bookId}`);
  }
}
