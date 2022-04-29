import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Account } from '../models/account.model';
import { AccountType } from '../models/accounttype.model';

@Injectable({providedIn: 'root'})
export class AccountService {

    public accoutType: number = 0;
    private subject = new Subject<number>();

    constructor(private http: HttpClient) { }

    setAccountType(accountType: number) {
        this.accoutType = accountType;
        this.subject.next(this.accoutType);
    }    

    getAccountType() {
        return this.subject.asObservable();
    }

    createAccount(account: Account): Observable<any> {
        return this.http.post<Account>('api/accounts/createaccount', account)
        .pipe(          
            catchError(this.handleError<Account[]>('createaccount', []))
        );
    }

    getAccounts(): Observable<any> {
        return this.http.get('api/accounts/GetAccounts')
        .pipe(
            catchError(this.handleError<any>('GetAccounts', []))
        );
    }

    getAllAccountTypes(): Observable<AccountType[]> {
        return this.http.get<AccountType[]>('api/accounts/GetAccountTypes')
        .pipe(
            catchError(this.handleError<any>('GetAccountTypes', []))
        );
    }

      private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
    
          console.error(error);

          this.log(`${operation} failed: ${error.message}`);
    
          return throwError(error);
        };
      }
    
      private log(message: string) {
        console.log(`Account Service: ${message}`); 
      }
}
