
export class Employee {

  id?: number;
  firstName: string = '';
  lastName: string = '';
  dependents: Dependent[] = [];
}

export class Dependent {
  

  firstName: string = '';
  lastName: string = '';
}

