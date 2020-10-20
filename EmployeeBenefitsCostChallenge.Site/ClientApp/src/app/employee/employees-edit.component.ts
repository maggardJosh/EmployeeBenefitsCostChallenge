import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee, Dependent } from "./models/Employee.model";

@Component({
  selector: 'employees-edit',
  templateUrl: './employees-edit.component.html'
})
export class EmployeesEditComponent {

  employeeForm: FormGroup;
  loaded: boolean = false;
  isEdit: boolean = false;
  errorMessage: string;


  constructor(private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder) {
    this.employeeForm = this.buildForm(new Employee());
  }

  buildForm(e: Employee): FormGroup {
    return this.fb.group({
      employeeID: e.employeeID,
      firstName: [e.firstName, Validators.required],
      lastName: [e.lastName, Validators.required],
      dependents: this.fb.array(e.dependents.map(d => this.buildDependentForm(d)))
    });
  }

  buildDependentForm(d: Dependent): FormGroup {
    return this.fb.group({
      firstName: [d.firstName, Validators.required],
      lastName: [d.lastName, Validators.required]
    });
  }

  get dependents(): FormArray {
    return this.employeeForm.get('dependents') as FormArray;
  }

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.isEdit = id !== '0';
    if (!this.isEdit) {
      this.loaded = true;
      return;
    }

    this.http.get<Employee>('api/employee/' + id).subscribe(result => {
      this.employeeForm = this.buildForm(result);
      this.loaded = true;
    },
      () => { this.errorMessage = "Error retrieving employee information" }
    );


  }

  onSubmit() {

    if (!this.isEdit) {
      this.http.post<Employee>('api/employee/', this.employeeForm.value)
        .subscribe(() => this.navigateHome(),
                    () => this.errorMessage = "Unable to add employee");
      return;
    }

    const id = this.route.snapshot.params['id'];
    this.http.put<Employee>('api/employee/' + id, this.employeeForm.value)
      .subscribe(() => this.navigateHome(),
                  () => this.errorMessage = "Unable to update employee");
  }

  navigateHome() {
    this.router.navigateByUrl('');
  }

  addDependent() {
    this.dependents.push(this.buildDependentForm(new Dependent()));
  }

  removeDependent(i: number) {
    this.dependents.removeAt(i);
  }

  deleteEmployee() {
    const id = this.route.snapshot.params['id'];
    this.http.delete('api/employee/' + id)
      .subscribe(() => this.navigateHome(),
                  () => this.errorMessage = "Unable to delete employee");
  }
}
