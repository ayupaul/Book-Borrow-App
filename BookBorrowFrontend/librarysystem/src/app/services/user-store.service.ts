import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
  dataSubject:BehaviorSubject<any>=new BehaviorSubject<any>(null);
  tokenSubject:BehaviorSubject<any>=new BehaviorSubject<any>(null);
  dashboardToken:BehaviorSubject<any>=new BehaviorSubject<any>(null);
  constructor() { }
  getData(){
    return this.dataSubject.asObservable();
  }
  setData(value:any){
    this.dataSubject.next(value);
  }
  getAvailableToken(){
    return this.tokenSubject.asObservable();
  }
  setAvailableToken(value:any){
    this.tokenSubject.next(value);
  }
  getDashboardToken(){
    return this.dashboardToken.asObservable();
  }
  setDashboardToken(value:any){
    this.dashboardToken.next(value);
  }

}
