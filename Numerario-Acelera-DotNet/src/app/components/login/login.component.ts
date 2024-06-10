import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../utils/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})

export class LoginComponent {
  login: string = '';
  password: string = '';

  constructor(private router: Router, private authService: AuthService) {}

  onSubmit(event: Event) {
    event.preventDefault();

    this.authService.login(this.login, this.password).subscribe(
      (response) => {
     
        this.router.navigate(['/balance']);
      },
      (error) => {
        alert('Login ou senha inválidos');
      }
    );
  }
}
