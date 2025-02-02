
export class Employee {

  employeeID: number = 0;
  firstName: string = '';
  lastName: string = '';
  dependents: Dependent[] = [];
  individualBenefitCost: BenefitCost = new BenefitCost();
  totalBenefitCost: BenefitCost = new BenefitCost();
}

export class Dependent {

  firstName: string = '';
  lastName: string = '';
  individualBenefitCost: BenefitCost = new BenefitCost();
}

export class BenefitCost {
  annualBenefitCost: number = 0;
  paycheckBenefitCost: number = 0;
}

