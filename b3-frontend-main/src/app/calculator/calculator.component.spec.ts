import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CalculatorComponent } from './calculator.component';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;
  let httpTestingController: HttpTestingController;

  beforeEach(async () => {
    
    await TestBed.configureTestingModule({
      declarations: [CalculatorComponent],
      imports: [HttpClientTestingModule, FormsModule],
    }).compileComponents();

    fixture = TestBed.createComponent(CalculatorComponent);
    component = fixture.componentInstance;
    component.isTestEnvironment = true;
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should update buttonLabel to "Calculando..." on form submission', () => {
    const mockApiResponse = { grossInvestment: 1000, netInvestment: 950 };
    
    component.onSubmit(); 
    expect(component.buttonLabel).toEqual('Calculando...');
    const req = httpTestingController.expectOne('https://localhost:7109/api/v1/cdb');
    expect(req.request.method).toEqual('POST');
    req.flush(mockApiResponse);
    
    
    fixture.detectChanges();
    expect(component.grossAmount).toEqual(mockApiResponse.grossInvestment);
    expect(component.netAmount).toEqual(mockApiResponse.netInvestment);
  });

  it('should make a POST request to the API on form submission', () => {
    const mockApiResponse = { grossInvestment: 1000, netInvestment: 950 };
    component.onSubmit();

    const req = httpTestingController.expectOne('https://localhost:7109/api/v1/cdb');
    expect(req.request.method).toEqual('POST');
    req.flush(mockApiResponse);

    expect(component.grossAmount).toEqual(mockApiResponse.grossInvestment);
    expect(component.netAmount).toEqual(mockApiResponse.netInvestment);
    expect(component.showResults).toBeTrue();
  });

  it('should handle errors when making a POST request', () => {
    const mockError = new ErrorEvent('mock error', {
      error: {
        errors: {
          MoneyToInvest: 'Invalid'
        }
      }
    });
    component.onSubmit();

    const req = httpTestingController.expectOne('https://localhost:7109/api/v1/cdb');
    expect(req.request.method).toEqual('POST');
    req.error(mockError);

    expect(component.buttonLabel).toEqual('Calcular');
    expect(component.grossAmount).toBeUndefined();
    expect(component.netAmount).toBeUndefined();
    expect(component.showResults).toBeFalse();
  });

  afterEach(() => {
    httpTestingController.verify();
  });
});
