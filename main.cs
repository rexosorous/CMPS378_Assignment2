using System;

/*
Author: J-Zach Loke
Class: CMPS-378
Due Date: 09/23/2021
Description:
    This program determines the most efficient way (least amount of coins) to dispense change from a transaction.
    Has an option on whether or not to 50c coins should be dispensed.
*/

namespace Assignment2
{
    class MainClass
    {
        /* The root / driver of the program.
        Handles user input and output. */
        static void Main(string[] args)
        {
            // collect inputs of the user
            Console.WriteLine("This program will determine the least amount of coins to dispense as change from a purchase.");
            Console.Write("Enter the product price without the \"$\": ");
            var price = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the amount the customer paid without the \"$\": ");
            var paid = Convert.ToSingle(Console.ReadLine());
            Console.Write("Should we use 50c coins (y/n)? ");
            var use_50c = Console.ReadLine();

            price = (paid - price) % 1;    // don't hand out coins when bills can be used
            Console.WriteLine($"After handing out dollar bills, the value of the change is ${price}");  // show the value of the change needed to be dispensed
            ChangeCalculator calculator;
            if (use_50c == "y") {
                calculator = new ChangeCalculator(price);
            }
            else {
                calculator = new ChangeCalculator(price, false);
            }
            if (calculator.calculate()) {
                // output results
                Console.WriteLine("The change that should be dispensed is:");
                Console.WriteLine($"\t50c    : {calculator.fifties}");
                Console.WriteLine($"\tquarter: {calculator.quarters}");
                Console.WriteLine($"\tdime   : {calculator.dimes}");
                Console.WriteLine($"\tnickel : {calculator.nickels}");
                Console.WriteLine($"\tpenny  : {calculator.pennies}");
            }
            else {
                Console.WriteLine("Customer did not give enough money to pay for this transaction or they paid with exact change.");
            }
            Console.ReadKey();
        }
    }
}