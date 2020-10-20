import { EmployeesComponent } from "./employees.component";
import { ComponentFixture, TestBed, tick, fakeAsync } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import { Router } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { Location } from "@angular/common";
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';


let component: EmployeesEditComponent;
let fixture: ComponentFixture<EmployeesEditComponent>;

import { routes } from "../router";
import { EmployeesEditComponent } from "./employees-edit.component";
import { Employee, Dependent } from "./models/Employee.model";
describe("employees-edit",
  () => {


    let router;
    let location;

    beforeEach(() => {
      TestBed.configureTestingModule({
        imports: [
          RouterTestingModule.withRoutes(routes),
          FormsModule,
          NgbModule,
          ReactiveFormsModule,
          HttpClientTestingModule
        ],
        declarations: [EmployeesComponent, EmployeesEditComponent]
      });
      router = TestBed.get(Router);
      location = TestBed.get(Location);
      fixture = TestBed.createComponent(EmployeesEditComponent);
      component = fixture.componentInstance;

      router.initialNavigation();
      fixture.detectChanges();
    });

    it('should display header',
      () => {
        const h2: HTMLElement = fixture.nativeElement.querySelector('h2');
        expect(h2.textContent).toContain("Employee Information");
      });

    it('clicking cancel should navigate to home',
      fakeAsync(() => {
        component.loaded = true;
        fixture.detectChanges();
        const cancelButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#cancelButton');
        cancelButton.click();
        tick();
        expect(location.path()).toBe('/employees');
      }));
    it('invalid form clicking save should do nothing',
      fakeAsync(() => {
        spyOn(component, 'onSubmit');
        component.loaded = true;
        fixture.detectChanges();
        const saveButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#saveButton');
        saveButton.click();
        expect(component.onSubmit).not.toHaveBeenCalled();
      }));

    it('click add dependent adds dependent',
      fakeAsync(() => {
        component.loaded = true;
        fixture.detectChanges();
        const addDependentButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#addDependentButton');
        addDependentButton.click();
        tick();
        expect(component.dependents.length).toBe(1);
      }));

    it('click remove dependent removes dependent',
      fakeAsync(() => {
        component.loaded = true;
        let employee: Employee = new Employee();
        employee.firstName = "First";
        employee.lastName = "Last";
        employee.dependents = [
          new Dependent()
        ];
        component.employeeForm = component.buildForm(employee);
        fixture.detectChanges();
        const removeDependentButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#removeDependentButton');
        removeDependentButton.click();
        tick();
        expect(component.dependents.length).toBe(0);
      }));

    it('Valid form clicking save should call onSubmit',
      fakeAsync(() => {
        spyOn(component, 'onSubmit');

        component.loaded = true;
        let employee: Employee = new Employee();
        employee.firstName = "First";
        employee.lastName = "Last";
        component.employeeForm = component.buildForm(employee);
        fixture.detectChanges();

        const saveButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#saveButton');
        saveButton.click();

        expect(component.onSubmit).toHaveBeenCalled();
      }));

    it('click delete should call deleteEmployee',
      fakeAsync(() => {
        spyOn(component, "deleteEmployee");
        component.loaded = true;
        component.isEdit = true;
        let employee: Employee = new Employee();
        employee.firstName = "First";
        employee.lastName = "Last";
        employee.dependents = [
          new Dependent()
        ];
        component.employeeForm = component.buildForm(employee);
        fixture.detectChanges();
        const deleteEmployeeButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#deleteButton');
        deleteEmployeeButton.click();
        expect(component.deleteEmployee).toHaveBeenCalled();

      }));

    it('delete button should not exist in add mode',
      fakeAsync(() => {
        component.loaded = true;
        component.isEdit = false;
        let employee: Employee = new Employee();
        employee.firstName = "First";
        employee.lastName = "Last";
        employee.dependents = [
          new Dependent()
        ];
        component.employeeForm = component.buildForm(employee);
        fixture.detectChanges();
        const deleteEmployeeButton: HTMLAnchorElement = fixture.nativeElement.querySelector('#deleteButton');
        expect(deleteEmployeeButton).toBeNull();

      }));
  });
