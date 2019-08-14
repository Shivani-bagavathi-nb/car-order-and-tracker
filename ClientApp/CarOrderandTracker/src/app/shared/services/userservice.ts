import { HttpClientModule, HttpClient, HttpParams } from '@angular/common/http';
import { environment } from './../../../environments/environment';
 
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {}
  url: string = environment.url + 'user';
  addUser(userInfo): Observable<any> {
    return this.http.post(this.url + '/adduser', userInfo);
  }
  getUser(userInfo: User): Observable<any> {
    const loginData = new HttpParams()
      .set('emailId', userInfo.EmailId)
      .set('password', userInfo.Password);
    return this.http.get(this.url + '/getuser', { params: loginData });
  }
}
