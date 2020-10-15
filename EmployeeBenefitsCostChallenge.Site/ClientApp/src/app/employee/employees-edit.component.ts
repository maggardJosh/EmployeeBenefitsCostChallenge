import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Employee, Dependent } from "./models/Employee.model";

@Component({
  selector: 'employees-edit',
  templateUrl: './employees-edit.component.html'
})
export class EmployeesEditComponent {

  employeeForm: FormGroup;
  loaded: boolean = false;


  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private route: ActivatedRoute,
    private fb: FormBuilder) {
    this.employeeForm = this.buildForm(new Employee());
  }

  buildForm(e:Employee): FormGroup {
    return this.fb.group({
      firstName: e.firstName,
      lastName: e.lastName,
      dependents: this.fb.array(e.dependents.map(d=>this.buildDependentForm(d)))
    });
  }

  buildDependentForm(d: Dependent): FormGroup {
    
    return this.fb.group({ firstName: d.firstName, lastName: d.lastName });
  }

  get dependents(): FormArray {
    return this.employeeForm.get('dependents') as FormArray;
  }

  ngOnInit() {
    let id = this.route.snapshot.params['id'];
    if (id !== '0') {
      this.http.get<Employee>(this.baseUrl + 'api/employee/' + id).subscribe(result => {
          //TODO: extract this to data retrieval service
          this.employeeForm = this.buildForm(result);
          this.loaded = true;
        },
        error => console.error(error));
    } else {
      this.loaded = true;
    }


  }
  onSubmit() {
    console.log(this.employeeForm.value);
  }

  addDependent() {
    this.dependents.push(this.buildDependentForm(new Dependent()));
  }

  removeDependent(i:number) {
    this.dependents.removeAt(i);
  }
}
