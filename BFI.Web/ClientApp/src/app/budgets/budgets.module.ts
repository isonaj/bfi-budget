import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BudgetsRoutingModule } from './budgets-routing.module';
import { BudgetComponent } from './budget/budget.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    BudgetComponent
  ],
  imports: [
    CommonModule,
    BudgetsRoutingModule,
    SharedModule
  ]
})
export class BudgetsModule { }
