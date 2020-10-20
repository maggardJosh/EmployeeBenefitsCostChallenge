import { EmployeesComponent } from "./employees.component";
import { ComponentFixture, TestBed, tick, fakeAsync } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import { Router } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { Location } from "@angular/common";
import { HttpClientTestingModule } from '@angular/common/http/testing';


let component: EmployeesComponent;
let fixture: ComponentFixture<EmployeesComponent>;

import { routes } from "../router";
import { EmployeesEditComponent } from "./employees-edit.component";
import { Employee } from "./models/Employee.model";

describe("employees",
  () => {
    let router;
    let location;
    beforeEach(() => {
      TestBed.configureTestingModule({
        imports: [
          RouterTestingModule.withRoutes(routes), FormsModule, NgbModule, ReactiveFormsModule, HttpClientTestingModule
        ],
        declarations: [EmployeesComponent, EmployeesEditComponent]
      });
      router = TestBed.get(Router);
      location = TestBed.get(Location);
      fixture = TestBed.createComponent(EmployeesComponent);
      component = fixture.componentInstance;
      router.initialNavigation();
      fixture.detectChanges();
    });

    it('should display header',
      () => {
        const h1: HTMLElement = fixture.nativeElement.querySelector('h1');
        expect(h1.textContent).toContain("Employees");
      });

    it('clicking add should navigate to add page',
      fakeAsync(() => {
        component.employees = [];
        fixture.detectChanges();
        const addButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#addButton');
        addButton.click();
        tick();
        expect(location.path()).toBe('/employees/0');
      }));

    it('clicking employee name should navigate to edit page',
      fakeAsync(() => {
        let e = new Employee();
        e.employeeID = 2;
        component.employees = [e];
        fixture.detectChanges();
        const editButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#editButton');
        editButton.click();
        tick();
        expect(location.path()).toBe('/employees/2');
      }));
  });
