using System;
using BankObjects.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace BankObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var context = new BankdbContext();
            /*
            // Add Bank
            string name = "XYZ PANKKI";
            string bic = "XYZHAAB";
            //UtilitiesBank.AddBank (name, bic);
            */
            //
            /*
            // Update Bank
            string cName = "DKanske";
            string cBic = "DABAFIHX";
            string uName = "DANSKE2";
            string uBic = "DADBAYZ";
            UtilitiesBank.UpdateBank(cName, uName, cBic, uBic);
            */
            //
            /*
            // Delete Bank
            string bankName = "HANDELSBANK";
            string bic = "OKOHIff";
            UtilitiesBank.DeleteBank(bankName, bic);
            */
            /*
            // New Customer
            string firstName = "Niiko";
            string lastName = "Niili";
            int bankId = 3;
            UtilitiesCustomer.AddCustomer(firstName, lastName, bankId);
            */
            // New Account for a Customer "LastName"
            string lastName = "Niili";
            string iban = "FI0250004640001555 ";
            string aName = "Saving Account";
            int bankId = 1;
            int customerId = 4;
            decimal balance = 15;
            UtilitiesCustomer.AddBankAccount(lastName, iban, aName, bankId, customerId, balance);

        
            var banks = context.Bank
            .Where(b => b.Id == 0)
            .Include(b => b.Customer)
            .Include(b => b.BankAccount)
            .FirstOrDefault();
        
            Console.ReadLine();
        }
    }
}
