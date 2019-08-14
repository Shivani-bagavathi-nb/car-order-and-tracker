import {IOrder} from '../interfaces/IOrder.interface';

export class Order implements IOrder {
  public Orderitem: BigInteger;
  public Orderitemmodel: string;
  public Engine: string;
  public Make: string;
  public Year: string
}
