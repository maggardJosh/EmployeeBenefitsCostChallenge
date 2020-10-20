import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from "./models/Employee.model";
import { Router } from "@angular/router";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  employees: Employee[];
  errorMessage: string;
  
  constructor(http: HttpClient, private router: Router) {
    
    http.get<Employee[]>('api/employee').subscribe(result => {
      this.employees = result;
      
    }, error => this.errorMessage = "Unable To Retrieve Employees");
  }

  getTotalCostSum() {
    return this.employees.reduce((acc, val) => acc + val.totalBenefitCost.annualBenefitCost, 0)
  }
}

