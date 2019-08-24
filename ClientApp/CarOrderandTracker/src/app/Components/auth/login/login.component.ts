import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService, SocialUser, GoogleLoginProvider } from 'ng4-social-login';
import {
  FormsModule,
  ReactiveFormsModule,
  FormGroup,
  FormBuilder,
  Validators
} from '@angular/forms';
import { Route, RouterModule, Router } from '@angular/router';
import { UserService } from '../../../shared/services/userservice';
//import { stringify } from '@angular/core/src/util';
import { IUser } from '../../../shared/interfaces/IUser.interface';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  public user: any;
  public isAuthenticUser: boolean;
  private socialUser: IUser = {} as IUser;
  private appUser: IUser = {} as IUser;

  constructor(
    private route: Router,
    public socialAuthSrvice: AuthService,
    public fb: FormBuilder,
    private userService: UserService
  ) {}
  loginForm = this.fb.group({
    simpleFormEmailEx: ['', [Validators.required, Validators.email]],
    simpleFormPasswordEx: ['', Validators.required]
  });
  ngOnInit() {
    localStorage.clear();
  }

  ngOnDestroy() {}
  onSubmit() {}
  public googleLogin() {
    this.socialAuthSrvice
      .signIn(GoogleLoginProvider.PROVIDER_ID)
      .then((userData) => {
        this.user = userData;
        console.log(this.user);
        localStorage.setItem('email', this.user.email);
        localStorage.setItem('id', "2");

        if (this.user != null) 
          this.socialUser.EmailId = this.user.email;
          this.userService.addUser(this.socialUser);
          this.route.navigateByUrl('orderpage');
        }
      );
  }
  public appLogin() {
    this.appUser.EmailId = this.loginForm.value.simpleFormEmailEx;
    this.appUser.Password = this.loginForm.value.simpleFormPasswordEx;
    this.userService.getUser(this.appUser).subscribe((data) => {
      console.log(data);
      this.isAuthenticUser = data;
      if (this.isAuthenticUser) 
        this.route.navigateByUrl('orderpage');
      }
    );
  }
}
