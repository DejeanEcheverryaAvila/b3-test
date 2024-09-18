import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface ApiResponse {
  grossInvestment: number;
  netInvestment: number;
}

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})

export class CalculatorComponent {
  investmentAmount: number | undefined;
  redemptionMonths: number | undefined;
  grossAmount: number | undefined;
  netAmount: number | undefined;
  showResults: boolean = false;
  buttonLabel: string = 'Calcular';
  isTestEnvironment: boolean = false;
  
  constructor(
    private http: HttpClient
  ) {
    this.investmentAmount = 0.01;
    this.redemptionMonths = 2;


  }
  

  
  onSubmit() {
    this.buttonLabel = 'Calculando...';
    this.showResults = false;
    const postData = {
      moneyToInvest: this.investmentAmount,
      monthsToRedemption: this.redemptionMonths,
    };

     this.http.post<ApiResponse>('https://localhost:5001/api/v1/cdb', postData).subscribe({
      next: (response) => {
        console.log(response);
        this.buttonLabel = 'Calcular';
        this.grossAmount = response.grossInvestment;
        this.netAmount = response.netInvestment;
        this.showResults = true;
      },
      error: (error) => {
        this.buttonLabel = 'Calcular';
        // check if its status 400
        if(error.status === 400) {
          
          // check if its a validation error
          if(error.error.errors.hasOwnProperty('MoneyToInvest')) {
            alert("Ops! O campo 'Valor a ser investido' é obrigatório, e precisa ser um valor maior que zero.");
          }
          if(error.error.errors.hasOwnProperty('MonthsToRedemption')) {
            alert("Ops! O campo 'Meses para resgate' é obrigatório, e precisa ser um número inteiro maior que 1.");
          }
          if(error.error.errors.hasOwnProperty('calculationRequest')) {
            alert("Por favor, preencha corretamente todos os campos");
          }
        }

      }
    });
  }
}
