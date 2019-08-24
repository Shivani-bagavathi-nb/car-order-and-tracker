import { BrowserModule } from '@angular/platform-browser';
import { NgModule,NO_ERRORS_SCHEMA } from '@angular/core';
import { NotfoundComponent } from './Components/notfound/not-found.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './Components/auth/login/login.component';
import { HttpClientModule } from '@angular/common/http'; 
import {
  SocialLoginModule,
  GoogleLoginProvider,
  AuthServiceConfig
} from 'ng4-social-login';
import { OrderpageComponent } from './Components/orderpage/order-page.component';
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




