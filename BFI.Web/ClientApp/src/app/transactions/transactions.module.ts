import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

import { TransactionsRoutingModule } from './transactions-routing.module';
import { TransactionsComponent } from './transactions/transactions.component';

@NgModule({
  declarations: [TransactionsComponent],
  imports: [
    CommonModule,
    SharedModule,
    TransactionsRoutingModule
  ]
})
export class TransactionsModule { }
