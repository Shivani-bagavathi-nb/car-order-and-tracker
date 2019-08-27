import {IOrder} from './../interfaces/IOrder.interface'

export class Order implements IOrder {
  public orderId: number;
  public userId : number;
  public orderItemModel: string;
  public engine: string;
  public make: string;
  public year: string
}
