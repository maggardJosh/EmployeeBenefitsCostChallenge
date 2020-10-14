import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { IEmployee } from '../shared/interfaces';

@Component({
  selector: 'employees-edit',
  templateUrl: './employees-edit.component.html'
})
export class EmployeesEditComponent {
  public employee: IEmployee = {
    firstName: '',
    lastName: '',
    dependentData: []
  }


  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private route: ActivatedRoute) {

  }
  
  ngOnInit() {
    let id = this.route.snapshot.params['id'];
    if (id !== '0') {
      this.http.get<IEmployee>(this.baseUrl + 'api/employee/' + id).subscribe(result => {
        this.employee = result;
      }, error => console.error(error));
    }
    
  }
}
