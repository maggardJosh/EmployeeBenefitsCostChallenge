import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { IEmployee } from '../shared/interfaces';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  public employees: IEmployee[];
  

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private router: Router) {
    http.get<IEmployee[]>(baseUrl + 'api/employee').subscribe(result => {
      this.employees = result;
      console.log(result);
    }, error => console.error(error));
  }
}

