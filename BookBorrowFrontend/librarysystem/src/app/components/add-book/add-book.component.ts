import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { UserService } from 'src/app/services/user.service';
import { NgbRatingModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent {
  addBookForm:FormGroup
  constructor(private formBuilder:FormBuilder,private bookService:BookService,private userService:UserService,private route:Router,private toastr: ToastrService){
    this.addBookForm=this.formBuilder.group({
      bookName:["",Validators.required],
      author:["",Validators.required],
      description:["",Validators.required],
      genre:["",Validators.required],
      rating:["",Validators.required]
    })
  }
  onAdd(){
    const lentByUserId=this.userService.getUserIdFromToken();
    const bookDetails={...this.addBookForm.value,lentByUserId};
    console.log(bookDetails);
    this.bookService.addBook(bookDetails).subscribe((res)=>{
      console.log(res);
      this.toastr.success("Book Added Successfully");
      this.route.navigateByUrl("/dashboard");
    },
    (error)=>{
      console.log(error);
      this.toastr.error("Something went wrong");
    })
  }
}
