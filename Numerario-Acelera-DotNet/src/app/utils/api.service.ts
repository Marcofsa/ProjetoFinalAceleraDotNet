import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../enviroments/enviroments';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = environment;

  constructor(private http: HttpClient) {}

  getTeste(): Observable<any> {
    return this.http.get(`${this.baseUrl}/teste`);
  }
}
