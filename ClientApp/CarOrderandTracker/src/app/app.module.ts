import { BrowserModule } from '@angular/platform-browser';
import { NgModule,NO_ERRORS_SCHEMA } from '@angular/core';
import { NotfoundComponent } from './notfound/notfound.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './auth/login/login.component';
import { HttpClientModule } from '@angular/common/http'; 
import {
  SocialLoginModule,
  GoogleLoginProvider,
  AuthServiceConfig
} from 'ng4-social-login';
import { OrderpageComponent } from './orderpage/orderpage.component';
const config = new AuthServiceConfig(
  [
    {
      id: GoogleLoginProvider.PROVIDER_ID,
      provider: new GoogleLoginProvider(
        '96794856160-65udm8mpg1k23jicjtcmnbf6g553am2s.apps.googleusercontent.com'
      )
    }
  ],
  false
);

// @NgModule({
//   declarations: [
//     AppComponent,
//     LoginComponent,
//   ],
//   imports: [
//     BrowserModule,
//     AppRoutingModule
//   ],
//   providers: [],
//   bootstrap: [AppComponent]
// })
// export class AppModule { }


export function provideConfig() {
  return config;
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NotfoundComponent,
    OrderpageComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,    
    FormsModule,
    ReactiveFormsModule,
    SocialLoginModule,
    // ChartsModule,
    HttpClientModule,  
  ],
  schemas: [NO_ERRORS_SCHEMA],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}




