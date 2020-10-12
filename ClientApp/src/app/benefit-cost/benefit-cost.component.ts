import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-benefit-cost',
  templateUrl: './benefit-cost.component.html'
})
export class BenefitCostComponent {
  public benefitCosts: BenefitCost[];
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<BenefitCost[]>(baseUrl + 'api/benefitcost').subscribe(result => {
      this.benefitCosts = result;
    }, error => console.error(error));
  }
}

interface BenefitCost {
  name: string;
  benefitCost: number;
  paycheckBenefitCost: number;
  dependentCostData: BenefitCost[];
}
