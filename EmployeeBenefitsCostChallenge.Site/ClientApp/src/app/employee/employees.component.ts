import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from "./models/Employee.model";
import { Router } from "@angular/router";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  public employees: Employee[];
  
  constructor(http: HttpClient, private router: Router) {
    http.get<Employee[]>('api/employee').subscribe(result => {
      this.employees = result;
      console.log(result);
    }, error => console.error(error));
  }

  navigateToAdd() {
    this.router.navigateByUrl('employees/0');
  }
}

