import { BrowserModule, provideClientHydration,} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BalanceComponent } from './components/balance/balance.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './utils/auth.service';
import { AuthGuard } from './utils/auth.guard';

export function tokenGetter() {
  return JSON.parse(localStorage.getItem('') || '{}').token;
}

@NgModule({ declarations: [
        AppComponent,
        LoginComponent,
        DashboardComponent,
        BalanceComponent,
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        AppRoutingModule,
        FormsModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                allowedDomains: ['localhost:5001'],
                disallowedRoutes: ['http://localhost:5001/api/auth/login'],
            },
        })], providers: [AuthService, AuthGuard, provideClientHydration(), provideHttpClient(withInterceptorsFromDi())] })
export class AppModule {}
