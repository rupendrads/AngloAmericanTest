import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { AccountService } from '../services/account.service';
import { Account } from '../models/account.model';
import { AccountType } from '../models/accounttype.model';

@Component({
    selector: 'app-new-account',
    templateUrl: './new-account.component.html',
    styleUrls: ['./new-account.component.css']
})

export class NewAccountComponent implements OnInit {
    @ViewChild('f', { static: false }) signupForm: NgForm;
    
    defaultAccountType = 0;

    accountTypes: AccountType[] = [];

    account: Account = {
        firstName: '',
        lastName: '',
        accountTypeId: 0,
        balance: 0,
        address: ''
    };

    submitted = false;
    isLoading = false;
    isError = false;
    errorMessage: string = '';    

    constructor(private accountService: AccountService, private router: Router){}

    ngOnInit() {
        this.accountService.getAllAccountTypes().subscribe(result =>{
            result.map(acType => {
              this.accountTypes.push({id:acType.id,name:acType.name});
            })
          });
    }

    onSubmit() {
        this.isError = false;
        this.errorMessage = '';
        this.submitted = true;

        this.account.firstName = this.signupForm.value.firstName;
        this.account.lastName = this.signupForm.value.lastName;
        this.account.accountTypeId = +this.signupForm.value.AccountTypeId;
        this.account.balance = +this.signupForm.value.balance;
        this.account.address = ''; // this will come from service

        this.isLoading= true;

        this.accountService.createAccount(this.account).subscribe(
            result => {
                this.isLoading = false;
                
                if (result.id > 0) {                    
                    alert('Account Created Successfully.');

                    this.router.navigateByUrl('/');
                }
            },
            error => {                
                this.errorMessage = error.error.Message;
                this.isError = true;
                this.isLoading = false;
            }            
        )        
      }

      onReset() {
        this.signupForm.reset();
      }

      onBack() {
        this.router.navigateByUrl('/');
      }
}