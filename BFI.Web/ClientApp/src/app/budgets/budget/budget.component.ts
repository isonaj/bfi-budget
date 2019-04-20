import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.css']
})
export class BudgetComponent implements OnInit {

  income: [
    { name: 'Salary', amount: 1000 }
  ];
  expenses: [
    { name: 'Daily Expenses', amount: 600 },
    { name: 'Smile', amount: 100 },
    { name: 'Splurge', amount: 100},
    { name: 'Fire Extinguisher', amount: 200 }
  ];

  constructor() { }

  ngOnInit() {
  }

}
