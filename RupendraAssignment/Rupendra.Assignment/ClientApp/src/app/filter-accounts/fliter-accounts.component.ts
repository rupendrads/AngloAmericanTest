import { Component, Input } from '@angular/core';

import { AccountType } from '../models/accounttype.model';
import { AccountService } from '../services/account.service';

@Component({
    selector: 'app-filter-accounts',
    templateUrl: './filter-accounts.component.html',
    styleUrls: ['./filter-accounts.component.css']
})

export class FilterAccountsComponent {     
  @Input() accountTypes: AccountType[] = [];
  
  constructor(private accountService: AccountService){
  }
  
  ngOnInit(): void {       
  }

  onAccountTypeChange(event) {
    this.accountService.setAccountType(event.value);
  }
}