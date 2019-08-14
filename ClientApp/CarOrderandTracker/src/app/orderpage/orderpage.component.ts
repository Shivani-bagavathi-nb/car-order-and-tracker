
import { Component } from '@angular/core';
import { OrderService } from '../shared/services/orderservice';
import { Order } from '../shared/models/order.model'
import { IOrder } from '../shared/interfaces/IOrder.interface';

@Component({
	selector: 'app-orderpage',
	templateUrl: './orderpage.component.html',
	styleUrls: [ './orderpage.component.scss' ]
})

export class OrderpageComponent {
  task: string;
  tasks = [];
  orders = ({} = []);
  showTable = false;

  constructor (private _orderService: OrderService) {

  }

  ngOnInit(){
  	this.tasks.push({name: this.task, strike: false});
    this.task = '';
    // plotOptions: {
    //   series: {
    //     point: {
    //       events: {
    //         click: (e) => this.getOrderedItems(e)
    //       }
    //       }
    
    //     }
    //   }
  }

  public getOrderedItems(order: any){
    this._orderService.getOrderedItems()
    .subscribe(result => {
      this.orders = result;
      console.log(this.orders,  'this is data');
    })
  }
       
    public addItem(order : any) {
    var selectedData = {} as IOrder;
    selectedData.Orderitemmodel = localStorage.getItem('orderitemmodel');
    selectedData.Engine = localStorage.getItem('engine');
    selectedData.Make = localStorage.getItem('make');
    selectedData.Year = localStorage.getItem('year');
    
    console.log('on sumbit', selectedData);
    this._orderService.addItem(selectedData).subscribe((res) => {
           console.log(res);})    
  }

  public deleteItem(order: any) {
    console.log(order);
    this.orders = [];
    this.deleteItem(this.orders);
   
    if (this.orders.length === 0) {
      this.showTable = false;
    }
    console.log(this.orders);
  }


}


  
