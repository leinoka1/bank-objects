using System;
using System.Collections.Generic;
using System.Text;
using BankObjects.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankObjects
{
    class UtilitiesCustomer
    {
        public static void AddCustomer(string firstName, string lastName, int bankId)
        {
            var context = new BankdbContext();
            var newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                BankId = bankId
            };

            context.Customer.Add(newCustomer);
            context.SaveChanges();
            return;
        }
        public static int SearchCustomer(string lastName, int bankId)
        {
            //
            var context = new BankdbContext();
            var customer = context.Customer
            .Where(c => c.LastName == lastName)
            .FirstOrDefault();
            //
            
            return customer.Id;
        }
        public static void AddBankAccount(string lastName, string iban, string aName, int bankId, int customerId, decimal balance)
        {
            int customerId2 = SearchCustomer(lastName, bankId);
            var context = new BankdbContext();
            var newAccount = new BankAccount
            {
                Iban = iban,
                Name = aName,
                BankId = bankId,
                CustomerId = customerId2,
                Balance = balance
            };

            context.BankAccount.Add(newAccount);
            context.SaveChanges();
            return;
        }
    }
}
