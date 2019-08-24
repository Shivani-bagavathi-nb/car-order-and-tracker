import { environment } from './../../../environments/environment';
import { Observable } from 'rxjs';
import { Order } from '../models/Order.model';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

// Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseurl: string = environment.url + 'order';
  jsonurl = "../../../assets/strings.json"
  balletVotes: Order[] = ({} = []);
  constructor(private http: HttpClient) {}

  getOrderItems(id : number): Observable<any>  {
    return this.http.get(this.baseurl + "/getorder/" + id );
  }

  addItem(order: Order): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*'
      })
    };
    return this.http.post(this.baseurl + '/additem', order, httpOptions);
  }

  deleteItem(orderitemmodel: string): Observable<any> {
    return this.http.get<any>(this.baseurl);
  }

  
}