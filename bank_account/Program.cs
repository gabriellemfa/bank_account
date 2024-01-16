using bank_account;
using System;


//includes a bank account class with
//methods for deposit withdrawals and checking the balance.
//The program demonstrates in the Main methods creating account, preforming transactions and displaying the account 
//information.
namespace bank_account
{

class BankAccount
    { 
        //private declaration of variable for BankAccount Class
        private string accountHolder;
        private double balance;


        //The constructor that initializes the accountHolder and balance with the provided values
        public BankAccount(string accountHolder, double initialBalance)
        {
            this.accountHolder = accountHolder;
            this.balance = initialBalance;
        }


        //Deposit method
        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${balance}");
        }


        //Withdraw method
        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn ${amount}. New balance: ${balance}");
            }

            //Insufficient funds when amount withdrawn is more than account balance
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }


        //Check balance method
        public void CheckBalance()
        {
            Console.WriteLine($"Account Holder: {accountHolder}");
            Console.WriteLine($"Current Balance: ${balance}");
        }
    }

    class Program
    {
        static void Main()
        {

            //Asks the user for banking info:

            Console.Write("Enter account holder's name: ");
            string accountHolder = Console.ReadLine();

            Console.Write("Enter initial balance: $");
            double initialBalance;
            while (!double.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.Write("Invalid input. Please enter a valid initial balance: $");
            }

            //Declares the users name and initial balance in the parameters
            BankAccount userAccount = new BankAccount(accountHolder, initialBalance);

            //Choices for the user to input
            while (true) 
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit\n");

                int choice;
                //while choice not in choice
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }

                //while choices within range
                switch (choice)
                {
                    case 1:
                        //Deposit Choice
                        Console.Write("Enter deposit amount: $");
                        double depositAmount;
                        
                        //If user inputs invalid number
                        while (!double.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            Console.Write("Invalid input. Please enter a valid deposit amount: $");
                        }
                        userAccount.Deposit(depositAmount);
                        break;

                    case 2:
                        //Withdraw choice
                        Console.Write("Enter withdrawal amount: $");
                        double withdrawalAmount;

                        //If user inputs invalid number
                        while (!double.TryParse(Console.ReadLine(), out withdrawalAmount))
                        {
                            Console.Write("Invalid input. Please enter a valid withdrawal amount: $");
                        }
                        userAccount.Withdraw(withdrawalAmount);
                        break;

                    case 3:
                        //Check balance choice
                        userAccount.CheckBalance();
                        break;

                    case 4:
                        //Exit
                        Environment.Exit(0);
                        break;

                    //Displays user input error
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
    }
}
    