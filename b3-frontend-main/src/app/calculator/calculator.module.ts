import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CalculatorComponent } from './calculator.component';
import { CurrencyMaskModule } from 'ng2-currency-mask';

@NgModule({
  declarations: [CalculatorComponent],
  imports: [CommonModule, FormsModule, CurrencyMaskModule],
  providers: [ ],
  exports: [CalculatorComponent],
})
export class CalculatorModule {}
