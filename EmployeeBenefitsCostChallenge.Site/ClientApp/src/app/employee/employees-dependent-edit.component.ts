import { Component, Input } from '@angular/core';
import { IPerson } from '../shared/interfaces';
import { AbstractControl, FormArray, FormGroup, FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'employees-dependent-edit',
  templateUrl: './employees-dependent-edit.component.html'
})
export class EmployeesDependentEditComponent {
  private _dependents: IPerson[] = [];
  @Input()
  set dependents(value: IPerson[]) {
    this._dependents = value;
    this.buildForm();
  }

  dependentForm: FormGroup;

  addDependent() {
    const dArray = this.dependentForm.controls.dependentsArr as FormArray;
    dArray.push(this.formBuilder.group({ firstName: '', lastName: '' }));
  }

  deleteDependent(i) {
    const dArray = this.dependentForm.controls.dependentsArr as FormArray;
    dArray.removeAt(i);
  }
  buildForm() {
    this.dependentForm = this.formBuilder.group({
      dependentsArr: this.formBuilder.array(this._dependents.map(d => this.formBuilder.group({firstName: d.firstName, lastName: d.lastName})))
    });
  }

  trackByFn(index: any, item: any) {
    return index;
  }

  constructor(private formBuilder: FormBuilder) {
    this.buildForm();
  }

}
