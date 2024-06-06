import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  login: string = '';
  password: string = '';

  constructor(private router: Router) {}
  onSubmit(event: Event) {

    event.preventDefault();

    if (this.login === 'user' && this.password === '123') {
      this.router.navigate([
        '/src/app/components//balance/balance.component.html',
      ]);
    } else {
      alert('Login ou senha inválidos');
    }
  }
}
