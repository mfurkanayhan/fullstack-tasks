import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-transactions',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './transactions.component.html',
  styleUrl: './transactions.component.scss'
})
export class TransactionsComponent {
  transactionForm: FormGroup;
  resultMessage = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.transactionForm = this.fb.group({
      date: ['', Validators.required],
      description: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(0.01)]]
    });
  }

  onSubmit() {
    if (this.transactionForm.invalid) {
      this.resultMessage = 'Please fill in all fields correctly.';
      return;
    }

    const transaction = this.transactionForm.value;

    this.http.post<any>('https://localhost:7247/api/transaction/save', transaction)
      .subscribe({
        next: () => this.resultMessage = 'Submission successful!',
        error: () => this.resultMessage = 'Submission failed.'
      });
  }
}
