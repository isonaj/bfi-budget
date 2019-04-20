import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {
  transactions: any;

  constructor(private client: HttpClient) { }

  ngOnInit() {
     this.client.get('/api/transactions').subscribe(data => {
       this.transactions = data;
       console.log(data);
     });
  }

  submit() {
    console.log('submit');
  }
}
