import { NgModule } from '@angular/core';
import {
  BrowserModule,
  provideClientHydration,
} from '@angular/platform-browser';
import {
  HttpClientModule,
  provideHttpClient,
  withInterceptorsFromDi,
} from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BalanceComponent } from './components/balance/balance.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './utils/auth.service';
import { AuthGuard } from './utils/auth.guard';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChartmodalComponent } from './components/chartmodal/chartmodal.component';

// Função para obter o token do localStorage
export function tokenGetter() {
  const currentUser = localStorage.getItem('currentUser');
  return currentUser ? JSON.parse(currentUser).token : null;
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    BalanceComponent,
    ChartmodalComponent,
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgxPaginationModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    NgbModalModule,
    ModalModule.forRoot(),
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5001'],
        disallowedRoutes: ['http://localhost:5001/api/auth/login'],
      },
    }),
  ],
  providers: [
    AuthService,
    AuthGuard,
    provideClientHydration(),
    provideHttpClient(withInterceptorsFromDi()),
  ],
})
export class AppModule {}
