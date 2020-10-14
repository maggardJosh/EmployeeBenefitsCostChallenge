
export interface IEmployee extends IPerson {
  dependentData: IPerson[];
  id?: number;
}

export interface IPerson {
  firstName: string;
  lastName: string;
  benefitCost?: IBenefitCostResult;
}

export interface IBenefitCostResult {
  annualBenefitCost: number;
  paycheckBenefitCost: number;
}
