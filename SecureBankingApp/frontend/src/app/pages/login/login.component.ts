import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import * as CryptoJS from 'crypto-js';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
})
export class LoginComponent {
  loginForm: FormGroup;
  resultMessage = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    const { email, password } = this.loginForm.value;
    const hashedPassword = CryptoJS.SHA256(password).toString(CryptoJS.enc.Hex);

    this.http.post<any>('https://localhost:7047/api/auth/login', {
      email,
      passwordHash: hashedPassword,
    }).subscribe({
      next: res => this.resultMessage = res.message,
      error: err => this.resultMessage = err.error.message || 'Login failed',
    });
  }
}
