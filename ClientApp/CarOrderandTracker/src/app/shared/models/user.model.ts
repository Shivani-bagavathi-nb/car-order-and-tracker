import { IUser } from '../interfaces/IUser.interface';

export class User implements IUser {
  public EmailId: string;
  public Password: string;
}
