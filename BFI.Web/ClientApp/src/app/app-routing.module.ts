import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CallbackComponent } from './callback/callback.component';
import { CounterComponent } from './counter/counter.component';
import { AuthGuard } from './services/auth.guard';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: 'callback', component: CallbackComponent },

    { path: 'budget', loadChildren: './budgets/budgets.module#BudgetsModule', canActivate: [AuthGuard] },
    { path: 'transactions', loadChildren: './transactions/transactions.module#TransactionsModule', canActivate: [AuthGuard] },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
