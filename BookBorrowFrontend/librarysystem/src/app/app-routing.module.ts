import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { ViewDetailsComponent } from './components/view-details/view-details.component';
import { BorrowedBooksComponent } from './components/borrowed-books/borrowed-books.component';
import { BooksLentComponent } from './components/books-lent/books-lent.component';
import { AllBooksComponent } from './components/all-books/all-books.component';
import { ActionGuard } from './guards/action.guard';
import { SearchedBooksComponent } from './components/searched-books/searched-books.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent,canActivate:[ActionGuard] },
  { path: 'addBook', component: AddBookComponent,canActivate:[ActionGuard] },
  { path: 'viewDetails/:id', component: ViewDetailsComponent,canActivate:[ActionGuard] },
  { path: 'borrowedBooks', component: BorrowedBooksComponent,canActivate:[ActionGuard] },
  { path: 'lentBooks', component: BooksLentComponent,canActivate:[ActionGuard] },
  { path: 'allBooks', component: AllBooksComponent,canActivate:[ActionGuard] },
  {path:'search/:word',component:SearchedBooksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
