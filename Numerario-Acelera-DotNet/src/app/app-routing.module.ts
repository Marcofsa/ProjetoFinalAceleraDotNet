import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { BalanceComponent } from './components/balance/balance.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  {path: 'Login', component: LoginComponent},
  {path: 'Balance', component: BalanceComponent},
  {path: 'Dashboard', component: DashboardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
