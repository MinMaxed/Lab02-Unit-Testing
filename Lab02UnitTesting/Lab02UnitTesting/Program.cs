using System;

namespace Lab02UnitTesting
{
    public class Program
    {

        // field variable that all methods are dependant on
        public static double Balance = 5000;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my bank!");

            // Main UI, set to stay active until the user decides they want to exit the application. 
            bool active = true;
            while (active)
            {
                Console.WriteLine("What would you like to do? (1, 2, 3, 4)");
                Console.WriteLine("1) See Balance");
                Console.WriteLine("2) Withdraw");
                Console.WriteLine("3) Deposit");
                Console.WriteLine("4) Exit");

                //reads users choice for the associated switch choice. 
                Int32.TryParse(Console.ReadLine(), out int choice);

                double userAmount;
                switch (choice)
                {
                    //see current balance only, no changes to values
                    case 1:
                        SeeBalance();
                        Console.WriteLine($"You have ${Balance} in your account.");
                        break;

                    //Withdraw an amount between 0 and the current balance
                    case 2:
                        Console.WriteLine("How much would you like to withdraw?");
                        Double.TryParse(Console.ReadLine(), out userAmount);
                        Withdraw(userAmount);
                        Console.WriteLine($"Your current balance is ${Balance}.");
                        break;

                    //Deposit a positive amount of money
                    case 3:
                        Console.WriteLine("How much would you like to deposit?");
                        Double.TryParse(Console.ReadLine(), out userAmount);
                        Deposit(userAmount);
                        Console.WriteLine($"Your current balance is ${Balance}.");
                        break;

                    //exits the application
                    case 4:
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine("Would you like to make another transaction? yes/no");
                string response = Console.ReadLine();
                response = response.ToLower();
                if (response == "" || response == "no")
                {
                    active = false;
                }
                Console.Clear();
            }
        }

        public static string SeeBalance()
        {
            return $"You have ${Balance} in your account.";
        }

        //withdraw a positive amount of money that's less than the current balance
        public static string Withdraw(double amount)
        {
            try
            {

            if (amount < Balance && amount > 0)
            {
                Balance -= amount;
            }

            if (amount >= Balance || amount <= 0)
            {
                return "You don't have that much in your account";
            }

            return "withdrawal complete";
            }
            //catching for invalid input, could not find a more specific exception type
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //deposit a non-negative amount of money

       
        public static string Deposit(double amount)
        {
            try
            {
                if (amount > 0)
                {
                    Balance += amount;
                }
                if (amount <= 0)
                {
                    return "Does not compute";
                }
                return "Funds successfully added to your account";
                }

            //catching for invalid input, could not find a more specific exception type
            catch (Exception e)
            {
               return e.Message;
            }
        }
    
    }
}
