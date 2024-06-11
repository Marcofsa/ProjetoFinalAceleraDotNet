import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../enviroments/enviroments';
import { LoginModel } from '../components/models/model.login';


@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment; //ADD URL DA API
  private loggedIn: boolean = false;

  constructor(private http: HttpClient) {}

  login(credentials: LoginModel): Observable<any> {

    return this.http
      .post<any>(`${this.apiUrl}/doLogin`, credentials) 
      .pipe(
        map((response) => {
          if (response && response.token) {
            this.setLoggedIn(true);
            localStorage.setItem(
              'currentUser',
              JSON.stringify({
                username: credentials.NomeUsuario,
                token: response.token,
              }) 
            );
          }
          return response;
        })
      );
  }

  logout() {
    this.setLoggedIn(false);
    localStorage.removeItem('currentUser');
  }

  getToken(): string | null {
    const currentUser = JSON.parse(localStorage.getItem('currentUser') || '{ "token": "2"}');
    return currentUser ? currentUser.token : null;
  }

  setLoggedIn(value: boolean) {
    this.loggedIn = value;
  }

  isLoggedIn(): boolean {
    return this.loggedIn;
  }
}
