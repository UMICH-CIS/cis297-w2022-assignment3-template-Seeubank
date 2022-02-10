///
/// author: Sarah Eubank
/// class: CIS 297, Winter Semester 2022
/// creation date: 2/5/2022
/// last modified: 2/10/2022
/// purpose: program is desinged to handles different types of bank accounts
/// allows debit and credit to the accounts, checks to make sure the accounts are not emptied by debit, calculates interest,
/// and subtracts checking fees
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
        /// last modified: 2/10/2022
        /// base class for SavingsAccount and CheckingAccount
        /// </summary>
        class Account
        {
            private decimal balance = 0.00M;

            /// <summary>
            /// creation date: 2/5/2022
            /// last modified: 2/10/2022
            /// public instance of private variable balance
            /// </summary>
            public decimal Balance
            {
                get { return balance; }

                set
                {
                    if (value >= 0.00M)
                    {
                        balance = value;
                    }
                    else
                    {
                        balance = 0.00M;
                        Console.Write("ERROR: Initial Account balance must be greater than $0.00");
                        Console.ReadLine();
                    }
                }
            }

            /// <summary>
            /// creation date: 2/5/2022
            /// last modified: 2/10/2022
            /// constructor for class Account
            /// </summary>
            /// <param name="balance"></param>
            public Account(decimal balance)
            {
                Balance = balance;
            }

            /// <summary>
            /// creation date: 2/5/2022
            /// last modified: 2/10/2022
            /// method to credit(deposit) funds into existing Account
            /// </summary>
            public virtual void Credit(decimal credit)
            {
                Balance += credit;
                Console.Write("New Account balance is: " + Balance);
                Console.ReadLine();
            }

            /// <summary>
            /// creation date: 2/5/2022
            /// last modified: 2/10/2022
            /// method to debit(withdrawl) money from exisiting Account; balance may not go below 0.00
            /// </summary>
            /// <param name="debit"></param>
            public virtual bool Debit(decimal debit)
            {
                if((Balance - debit) <= 0.00M)
                {
                    Console.Write("Debit amount exceeded account balance.");
                    Console.ReadLine();

                    return (false);
                }
                else
                {
                    Balance -= debit;
                    Console.Write("New Account balance is: " + Balance);
                    Console.ReadLine();

                    return (true);
                }
            }

        }

        /// <summary>
        /// author: Sarah Eubank
        /// creation date: 2/5/2022
        /// last modified: 2/10/2022
        /// derived class from Account. SavingsAccount handle interest rates
        /// </summary>
        class SavingsAccount : Account
        {
            decimal interestRate;

            /// <summary>
            /// creation date: 2/5/2022
            /// last modified: 2/10/2022
            /// constructor for derived class SavingsAccount
            /// </summary>
            /// <param name="balance"></param>
            /// <param name="interestRate"></param>
            public SavingsAccount(decimal Balance, decimal interestRate) : base(Balance)
            {
                this.interestRate = interestRate;
            }

            /// <summary>
            /// creation date: 2/5/2022
            /// last modified: 2/10/2022
            /// method to calculate the interest on an exisiting SavingsAccount
            /// </summary>
            /// <returns></returns>
            public decimal CalculateInterest()
            {
                decimal interest = Balance * (interestRate / 100M);

                Console.Write("Interest on SavingsAccount is: " + interest);
                Console.ReadLine();

                return (interest);
            }
        }

        /// <summary>
        /// author: Sarah Eubank
        /// creation date: 2/5/2022
        /// last modified: 2/10/2022
        /// derived class of Account. Handles accounts with checking fees
        /// </summary>
        class CheckingAccount : Account
        {
            decimal checkingFee;

            /// <summary>
            /// creation date: 2/5/2022
            /// last modified: 2/10/2022
            /// constructor for CheckingAccount
            /// </summary>
            /// <param name="balance"></param>
            /// <param name="checkingFee"></param>
            public CheckingAccount(decimal balance, decimal checkingFee) : base(balance)
            {
                this.checkingFee = checkingFee;
            }

            /// <summary>
            /// creation date: 2/9/2022
            /// last modified: 2/10/2022
            /// method Credit; override from Account.Credit() to include checking fees
            /// </summary>
            /// <param name="credit"></param>
            public override void Credit(decimal credit)
            {
                base.Credit(credit);
                Balance -= checkingFee;

                Console.Write("New balance on Checking Account after checking fee is: " + Balance);
                Console.ReadLine();
            }

            /// <summary>
            /// creationd date: 2/9/2022
            /// last modified: 2/10/2022
            /// method Debit; override from Account.Debit() to include checking fees
            /// </summary>
            /// <param name="debit"></param>
            public override bool Debit(decimal debit)
            {
              if (base.Debit(debit))
                {
                    Balance -= checkingFee;
                    Console.Write("New balance on Checking Account after checking fee is: " + Balance);
                    Console.ReadLine();

                    return (true);
                }
              else
                {
                    return (false);
                }
            }
        }

        static void Main(string[] args)
        {
            /*
            var test = new Account(5);
            test.Credit(5);
            test.Debit(10);

            var test2 = new SavingsAccount(5, 2);
            test2.Credit(10);
            test2.Debit(5);
            test2.CalculateInterest();*/

            var test3 = new CheckingAccount(15, 3);
            test3.Debit(10);
        }
    }
}