using System;
using System.Collections.Generic;
using System.Text;
using BankObjects.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankObjects
{
    class UtilitiesBank
    {
        public static void AddBank(string bankName, string bic)
        {
            //Add Bank

            var context = new BankdbContext();
            var newBank = new Bank
            {
                Name = bankName,
                Bic = bic
            };

            context.Bank.Add(newBank);
            context.SaveChanges();
            return;
        }

        public static void UpdateBank(string cBankName, string uBankName, string cBic, string uBic)
        {
            //Update Bank
            var context = new BankdbContext();
            var bank = context.Bank
            .Where(b => b.Name == cBankName)
            .FirstOrDefault();

            bank.Name = uBankName;
            bank.Bic = uBic;
            context.Bank.Update(bank);
            context.SaveChanges();
            return;
        }
            public static void DeleteBank(string bankName, string bic)
            {    
                //Delete Bank
                var context = new BankdbContext();
                var bank = context.Bank
                .Where(b => b.Name == bankName)
                .FirstOrDefault();

                //bank.Name = bankName;
                //bank.Bic = bic;
                context.Bank.Remove(bank);
                context.SaveChanges();
                return;

            }

    }
}
