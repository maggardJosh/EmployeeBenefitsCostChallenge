import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { EmployeesComponent } from "./employee/employees.component";
import { EmployeesEditComponent } from "./employee/employees-edit.component";
import { EmployeesDependentEditComponent } from "./employee/employees-dependent-edit.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeesComponent,
    EmployeesEditComponent,
    EmployeesDependentEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'employees', component: EmployeesComponent, pathMatch: 'full' },
      { path: 'employees/:id', component: EmployeesEditComponent },
      {path: '**', pathMatch: 'full', redirectTo: '/employees' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
