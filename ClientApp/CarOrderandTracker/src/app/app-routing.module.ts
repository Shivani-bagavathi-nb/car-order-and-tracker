import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/auth/login/login.component';
import { NotfoundComponent } from './Components/notfound/not-found.component';
import { OrderpageComponent } from './Components/orderpage/order-page.component';
import {AuthService} from './shared/services/authservice'


const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch:'full' },
  { path: 'login', component: LoginComponent },
  {
    path: 'orderpage',
    component: OrderpageComponent,
   // canActivate: [AuthService]
    
  },
  { path: '**', component: NotfoundComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
