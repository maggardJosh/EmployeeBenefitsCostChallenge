import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  public employees: IEmployee[];
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IEmployee[]>(baseUrl + 'api/employee').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }
}

interface IEmployee extends IPerson {
  dependentData: IPerson[];
}

interface IPerson {
  name: string;
  benefitCost: IBenefitCostResult;
}

interface IBenefitCostResult {
  annualBenefitCost: number;
  paycheckBenefitCost: number;
}
