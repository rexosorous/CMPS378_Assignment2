using System;



namespace Assignment2
{
    class ChangeCalculator
    {
        /* Handles all the calculation to determine how much change to dispense */
        public float changeValue {get; set;}
        public bool useFifties {get; set;}
        public int fifties {get; set;}
        public int quarters {get; set;}
        public int dimes {get; set;}
        public int nickels {get; set;}
        public int pennies {get; set;}

        public ChangeCalculator(float changeAmount, bool use50c = true)
        {
            changeValue = changeAmount;
            useFifties = use50c;
            fifties = 0;
            quarters = 0;
            dimes = 0;
            nickels = 0;
            pennies = 0;
        }

        public bool calculate()
        {
            /* Calculates the amount of each coin denomination needed to give the least amount of coins as change

            Returns:
                (bool): false if there is any change to be given out, true otherwise
            */
            if (changeValue > 0) {   // if the customer paid more than the price (ie. they didn't give exact change or underpay)
                // determine the amount of each denomination of coin to be used
                if (useFifties) {
                    fifties = CalcCoinAmt(0.5F);
                }
                quarters = CalcCoinAmt(0.25F);
                dimes = CalcCoinAmt(0.1F);
                nickels = CalcCoinAmt(0.05F);
                pennies = CalcCoinAmt(0.01F);
                return true;
            }
            return false;
        }

        private int CalcCoinAmt(float coinValue)
        {
            /* Calculates the maximum amount of one coin type that can be used without going over the price
            and also lowers the price for every coin used.

            Args:
                coinValue (float): the value of the coin denomination (ie. quarters should be 0.25f)

            Returns:
                coinCount (int): the number of coins used
            */
            int coinCount = 0;
            while (changeValue >= coinValue) {
                coinCount++;
                changeValue -= coinValue;
            }
            return coinCount;
        }
    }
}