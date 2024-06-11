import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../enviroments/enviroments';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment; //ADD URL DA API
  private loggedIn: boolean = false; 
  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    return this.http
      .post<any>(`${this.apiUrl}/login`, { username, password })
      .pipe(
        map((response) => {
          if (response && response.token) {
            this.setLoggedIn(true);
            localStorage.setItem(
              'currentUser',
              JSON.stringify({ username, token: response.token })
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
    const currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
    return currentUser ? currentUser.token : null;
  }

  // Método para definir o status de login
  setLoggedIn(value: boolean) {
    this.loggedIn = value;
  }

  // Método para verificar o status de login
  isLoggedIn(): boolean {
    return this.loggedIn;
  }
}
