///
/// author: Sarah Eubank
/// class: CIS 297, Winter Semester 2022
/// creation date: 2/5/2022
/// last modified: 2/9/2022
/// purpose:
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
        /// <summary>
        /// author: Sarah Eubank
        /// creation date: 2/5/2022
        /// last modified: 2/9/2022
        /// base class for SavingsAccount and CheckingAccount
        /// </summary>
        public class Account
        {
            private decimal balance = 0.00M; 

            /// <summary>
            /// author: Sarah Eubank
            /// creation date: 2/5/2022
            /// last modified: 2/9/2022
            /// constructor for Account; requires balance be greater than 0.00 otherwise throws exception.
            /// </summary>
            /// <param name="balance"></param>
            public Account()
            {
                Console.Write("Enter in the starting balance: ");
                balance += Convert.ToDecimal(Console.ReadLine());

                //itital balance must be greater than 0.00
                while (balance <= 0.00M)
                {
                    Console.WriteLine("ERROR: Starting balance must be greater than 0.00");
                    Console.WriteLine("Enter in the starting balance: ");
                    balance += Convert.ToDecimal(Console.ReadLine());
                }

                Console.Write("\r\nYour account balance is " + balance);
                Console.ReadLine();
            }
            /// <summary>
            /// author: Sarah Eubank
            /// creation date: 2/9/2022
            /// last modified: 2/9/2022
            /// getter function for private variable balance
            /// </summary>
            public decimal Balance { get { return balance; } }

            /// <summary>
            /// author: Sarah Eubank
            /// creation date: 2/5/2022
            /// last modified: 2/9/2022
            /// method to allow user to add money to account balance
            /// </summary>
            /// <param name="balance"></param>
            public void Credit()
            {
                Console.Write("Enter deposit amount: ");
                decimal credit = Convert.ToDecimal(Console.ReadLine());

                balance += credit;

                Console.Write("\r\nNew balance is " + balance);
                Console.ReadLine();
            }

            /// <summary>
            /// author: Sarah Eubank
            /// creation date: 2/5/2022
            /// last modified: 2/9/2022
            /// method that allows user to take money out of their account
            /// if amount being withdrawn is greater than the balance, gives error
            /// </summary>
            /// <param name="balance"></param>
            public void Debit()
            {
                Console.Write("Enter withdrawl amount: ");
                decimal debit = Convert.ToDecimal(Console.ReadLine());

                //cannot withdrawl more than the balance 
                while (debit > balance)
                {
                    Console.WriteLine("Debit amount exceeded amount balance.");
                    Console.WriteLine("\r\nEnter withdrawl amount: ");
                    debit = Convert.ToDecimal(Console.ReadLine());
                }

                 balance -= debit;
                 Console.Write("\r\nNew balance is " + balance);
                 Console.ReadLine();
            }
        }
       
        /// <summary>
        /// author: Sarah Eubank
        /// creation date: 2/9/2022
        /// last modified: 2/9/2022
        /// child class of Account. Can calculate the interest of an Account(5%)
        /// </summary>
        public class SavingsAccount : Account
        {
            decimal interestRate = 0.05M;

            /// <summary>
            /// author: Sarah Eubank
            /// creation date" 2/9/2022
            /// last modified: 2/9/2022
            /// constructor for derived class SavingsAccount
            /// </summary>
            public SavingsAccount()
            {
                decimal balance = Balance;
            }

            /// <summary>
            /// author: Sarah Eubank
            /// creation date: 2/9/2022
            /// last modified: 2/9/2022
            /// function that calculates the interest of a savings account
            /// </summary>
            public void CalculateInterest()
            {
                decimal interest = Balance * interestRate;
                decimal total = interest + Balance;

                Console.WriteLine("\r\nInterest gain for account is: " + interest);
                Console.Write("Balance plus interest is: " + total);
                Console.ReadLine();
            }
        }

        public class CheckingAccount : Account
        {

        }

        static void Main(string[] args)
        {
            /*Console.WriteLine("Creating new account...");
            var test = new Account();
            test.Credit();
            test.Debit();*/

            Console.WriteLine("Creating a Savings Account...");
            var test2 = new SavingsAccount();
            test2.Credit();
            test2.CalculateInterest();
            
        }
    }
}
