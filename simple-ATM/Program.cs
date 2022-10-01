using System;
using System.Collections.Generic;
using System.Linq;

namespace simpleATM
{

    public class cardHolder
    {
        //variables
        string cardNum;

        int pin;

        string firstName;

        string lastName;

        double balance;

        //constructor
        public cardHolder(
            string cardNum,
            int pin,
            string firstName,
            string lastName,
            double balance
        )
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        //getter
        public string getNum()
        {
            return cardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        //setters
        public void setNum(string newCardNum)
        {
            //set the cardNum to the newCardNum
            cardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(string[] args)
        {

            // help functions
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            //cardHolder is custom type
            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much would you like to deposit: ");
                //ReadLine returns a string, need to parse to double
                double deposit = Double.Parse(Console.ReadLine());

                //call the setBalance()
                currentUser.setBalance(deposit + currentUser.getBalance());
                Console.WriteLine("Your new balance is " + currentUser.getBalance());
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much would you like to withdraw: ");
                double withdrawl = Double.Parse(Console.ReadLine());

                //check if user have enough money in the balance
                if (currentUser.getBalance() < withdrawl)
                {
                    Console.WriteLine("Sorry insufficient fund.");
                }
                else
                {

                    //update the new balance, round up to 2 decimal place
                    currentUser.setBalance(Math.Round(currentUser.getBalance() - withdrawl, 2));
                    Console.WriteLine("Thank you, take your money!");
                }

            }

            void balance(cardHolder currentUser)
            {
                //get the current balance;
                Console.WriteLine("Current balance $" + currentUser.getBalance());
            }

            //define a list of cardHolders
            List<cardHolder> cardHolders = new List<cardHolder>();

            //add card list information
            cardHolders.Add(new cardHolder("4203485747677391", 1234, "Mia", "Jones", 180.15));
            cardHolders.Add(new cardHolder("4203495747675396", 2234, "Mia", "Yuan", 190.15));
            cardHolders.Add(new cardHolder("4303485787677395", 1034, "Mei", "Joes", 380.15));
            cardHolders.Add(new cardHolder("4903487747677392", 7890, "Sophia", "Brown", 580.15));

            //prompt user
            Console.WriteLine("Welcome to Simple ATM");
            Console.WriteLine("Please insert your debit card: ");
            //initial variables
            string debitCardNum = " ";
            int userPin = 0;
            cardHolder currentUser;

            //start the ATM
            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    //check if currentUser debit card is the same as database card number

                    //Use the FirstorDefault() method to return the first element of a sequence 
                    //or a default value if element isn't there.
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    //if the match is good, then break out the loop
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized, Please try again! "); }

                }
                catch
                {
                    Console.WriteLine("Card not recognized, Please try again! ");
                }

            }
            Console.WriteLine("Please enter your pin: ");

            //check the pin once insert the valid card

            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //if the pin is correct,then break out the loop
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect Pin, Please try again! "); }
                }
                catch
                {
                    Console.WriteLine("Incorrect Pin, Please try again! ");
                }
            }

            //print out thier first name if everything is correct
            Console.WriteLine("Welcome " + currentUser.getFirstName());

            //choose the options
            int option = 0;

            //do while loop will run at least once
            do
            {
                //print the options for the user
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { Console.WriteLine("Please choose an option"); }
                //call the deposit function
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; } //break out the loop
                else { option = 0; } //go back the inital loop


            } while (option != 4); //option 4 is exit
            Console.WriteLine("Thank you for visit the Simple ATM!");


        }
    }
}