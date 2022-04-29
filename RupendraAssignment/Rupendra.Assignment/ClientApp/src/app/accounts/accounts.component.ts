import { Component, OnInit } from '@angular/core';

import { AccountService } from '../services/account.service';
import { Account } from '../models/account.model';
import { AccountType } from '../models/accounttype.model';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})
export class AccountsComponent implements OnInit {

  dataSource: Account[];

  showLoader : boolean = false;

  accountTypes: AccountType[] = [];

  constructor(private accountService: AccountService) {
  }

  ngOnInit() {
    this.showLoader = true;
   
    this.accountService.getAllAccountTypes().subscribe(result =>{

      result.map(acType => {
        this.accountTypes.push({ id:acType.id, name:acType.name });
      })            
    }); 
    
    this.accountService.getAccounts().subscribe(accounts => {
      
      this.showLoader = true;      
      this.dataSource = accounts;

      this.accountService.getAccountType().subscribe(accountTypeId => { 

        this.dataSource = accounts;

        if(accountTypeId > 0) {
            this.dataSource = this.dataSource.filter( data => data.accountTypeId === accountTypeId);      
        }                     
      })

      this.showLoader = false; 
    })    
  }

  getAccountTypeName(id) {
      const index = this.accountTypes.findIndex(ac => ac.id === id);            
      return this.accountTypes[index].name;
  }
}