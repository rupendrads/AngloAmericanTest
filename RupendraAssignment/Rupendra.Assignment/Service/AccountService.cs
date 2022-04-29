using Microsoft.EntityFrameworkCore;
using Rupendra.Assignment.Common;
using Rupendra.Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Rupendra.Assignment.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAddressService _addressService;        
        private readonly AccountContext _accountContext;
        private IBalanceChecker _balanceChecker;

        public AccountService(IAddressService addressService, AccountContext accountContext)
        {
            _accountContext = accountContext;
            _addressService = addressService;            
        }

        public async Task<IList<Account>> GetAccounts()
        {                       
            var accounts = _accountContext.Accounts.ToList();
            var address = await _addressService.GetAddress();
            accounts.ForEach(add =>
            {
                add.Address = address.City + ' ' + address.PostCode;
            });

            return accounts;            
        }

        public async Task<Account> CreateAccount(Account account)
        {            
            ValidateAccount(account);

            _balanceChecker = new BalanceChecker((EnumAccountTypes)account.AccountTypeId);
            bool result = _balanceChecker.Process(account.Balance);

            if (result)
            {
                await _accountContext.Accounts.AddAsync(account);
                await _accountContext.SaveChangesAsync();
            }

            return account;                  
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            if (account.Id<0 || string.IsNullOrWhiteSpace(account.FirstName) ||
                    string.IsNullOrWhiteSpace(account.LastName) ||
                    (account.AccountTypeId < 1 || account.AccountTypeId > 3) ||
                    account.Balance <= 0)
            {
                throw new ArgumentException("Invalid data.Please provide valid data.");
            }

            var exisitngAccount = new Account();
            _balanceChecker = new BalanceChecker((EnumAccountTypes)account.AccountTypeId);
            bool result = _balanceChecker.Process(account.Balance);
            if (result)
            {
                exisitngAccount = _accountContext.Accounts.SingleOrDefault(x => x.Id == account.Id);
                if (exisitngAccount != null)
                {
                    exisitngAccount.FirstName = account.FirstName;
                    exisitngAccount.LastName = account.LastName;
                    exisitngAccount.AccountTypeId = account.AccountTypeId;
                    exisitngAccount.Balance = account.Balance;
                    _accountContext.Update(exisitngAccount);
                    await _accountContext.SaveChangesAsync();
                }
            }

            return exisitngAccount;
        }
            
        public async Task<IList<AccountType>> GetAccountTypes()
        {
            return await _accountContext.AccountTypes.ToListAsync();
        }

        private void ValidateAccount(Account account)
        {
            if (string.IsNullOrWhiteSpace(account.FirstName))
            {
                throw new ArgumentException("Invalid data. Please provide valid First name.");
            }
            if (string.IsNullOrWhiteSpace(account.LastName))
            {
                throw new ArgumentException("Invalid data. Please provide valid Last name.");
            }
            if (account.AccountTypeId < 1 || account.AccountTypeId > 3)

            {
                throw new ArgumentException("Invalid data. Please provide valid Account type.");
            }
            if (account.Balance <= 0)
            {
                throw new ArgumentException("Invalid data. Please provide valid Balance.");
            }
        }
    }
}
