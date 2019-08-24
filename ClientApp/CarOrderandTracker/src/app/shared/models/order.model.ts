import {IOrder} from './../interfaces/IOrder.interface'

export class Order implements IOrder {
  public Orderid: number;
  public Orderitemmodel: string;
  public Engine: string;
  public Make: string;
  public Year: string
}
