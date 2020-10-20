import { EmployeesComponent } from "./employee/employees.component";
import { EmployeesEditComponent } from "./employee/employees-edit.component";
export var routes = [
      { path: 'employees', component: EmployeesComponent, pathMatch: 'full' },
      { path: 'employees/:id', component: EmployeesEditComponent },
      { path: '**', pathMatch: 'full', redirectTo: '/employees' }
    ]
