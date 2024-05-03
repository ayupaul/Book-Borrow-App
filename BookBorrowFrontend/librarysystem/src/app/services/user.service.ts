import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  avaiableToken:any
  BackendUrl:string="http://localhost:5030/api/User"
  constructor(private http:HttpClient) { }

  //login
  login(userDetails:any):Observable<any>{
    return this.http.post(`${this.BackendUrl}/login`,userDetails);
  }

  //get user by id
  getUserById(id:any):Observable<any>{
    return this.http.get(`${this.BackendUrl}/getUserById/${id}`);
  }
  // is logged in or not
  isLoggedIn(){
    return !!localStorage.getItem('token');
  }
  //get available token
  getAvailableToken(id:any):Observable<any>{
    return this.http.get(`${this.BackendUrl}/getAvailableToken/${id}`);
  }

  //store token
  storeToken(tokenValue:any){
    
    localStorage.setItem('token',tokenValue);
  }

  //get token
  getToken(){
    const token=localStorage.getItem('token');
    return token;
  }
  //decode token
  decodedToken(){
    const jwtHelper=new JwtHelperService();
    const token=this.getToken() ?? '';
    return jwtHelper.decodeToken(token);
  }
  getUsernameFromToken(){
    const userToken=this.decodedToken();
    if(userToken){
      const username=userToken.name;
      return username;
    }
    return "";
  }
  getAvailableTokenFromToken(){
    const userToken=this.decodedToken();
    if(userToken){
     
     
        this.avaiableToken=userToken.TokenAvailable;
      
      
     
      return this.avaiableToken;
    }
    return "";
  }
  getUserIdFromToken(){
    const userToken=this.decodedToken();
    if(userToken){
      return userToken.UserId;
    }
  }
}
