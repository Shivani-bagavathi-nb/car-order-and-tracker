
import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../shared/services/orderservice';
import {IOrder} from '../../shared/interfaces/IOrder.interface';
import {Order} from '../../shared/models/order.model';
import { Router } from "@angular/router";


@Component({
	selector: 'app-orderpage',
	templateUrl: './order-page.component.html',
	styleUrls: [ './order-page.component.scss' ]
})

export class OrderpageComponent implements OnInit {
  show: boolean = false;
  Orderitem : Order;
  items: any;
  orders :any;
  constructor(private orderService: OrderService, private router: Router) {}

  ngOnInit() {
    this.orderService
      .getOrderItems(+localStorage.getItem("id"))
      .subscribe(item => {
        this.Orderitem = item;
        this.show = true;
        console.log(this.Orderitem);
      },
     
      error => {
       console.log('----',error) 
      });
  }

  public addItem(order : any) {
    var selectedData = {} as IOrder;
    selectedData.orderId = +localStorage.getItem('orderId');
    selectedData.userId = +localStorage.getItem('userId');
    selectedData.orderItemModel = localStorage.getItem('orderItemModel');
    selectedData.engine = localStorage.getItem('engine'); 
    selectedData.make = localStorage.getItem('make');
    selectedData.year = localStorage.getItem('year');
    
    console.log('on sumbit', selectedData);
    this.orderService.addItem(selectedData).subscribe((res) => {
           console.log(res);})    
  }

  
  public deleteItem(order: any) {
    console.log(order);
    this.orders = [];
    this.deleteItem(this.orders);
   
    if (this.orders.length === 0) {
      this.show = false;
    }
    console.log(this.orders);
  }

  orderDetails(order) {
    this.router.navigate(["orderpage/" + order.orderitemId]);
  }
}

       
   


  
