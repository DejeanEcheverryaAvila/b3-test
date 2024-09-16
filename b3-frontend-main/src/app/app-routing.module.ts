import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CalculatorComponent } from './calculator/calculator.component';

const routes: Routes = [
  { path: 'calculadora', component: CalculatorComponent },
  { path: '', redirectTo: '/calculadora', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
