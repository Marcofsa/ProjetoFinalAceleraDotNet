import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../utils/auth.service';
import { LoginModel } from '../models/model.login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(
    private router: Router, 
    private authService: AuthService,
    private formBuilder: FormBuilder
  ) {
    this.loginForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
     const userCredentials: LoginModel = {
       idUser: 0,
       NomeUsuario: this.loginForm.value.login,
       Senha: this.loginForm.value.password,
     };

    if (this.loginForm.valid) {
      this.authService.login(userCredentials).subscribe(
        (response) => {
          this.router.navigate(['/balance']);
        },
        (error) => {
          alert('Login ou senha inválidos');
        }
      );
    }
  }
}
