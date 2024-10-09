using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//Programmer:Luvo Tsholoba
//Date:07 October 2024
//Purpose: Purpose of this program is to showcase my understanding of classes in C#
//       :The program is about the bankAccount where the user can widthdraw,deposit and check their balances.


namespace BankAccount
{

    internal class Program
    {

        static void Main(string[] args)
        {
            ATM aTM = new ATM();
            aTM.LOGIN();
            //Was able to access this with the use of polymorphism;
        }
    }
    public  class Account
    {
        
        //Current money in the bank account;
        public double TotalMoney { get; set; } 
        public double deposite { get; set; }
        public double total { get; set; }
        public int pin { get;} = 2434;



        public Account()
        {
            total = 1200;
        }
        public void  Deposit()
        {
            Console.WriteLine("How much do you want to deposit ?");

             deposite = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine( "");

            Console.WriteLine($"Are you sure do you want to deposit {deposite:C} ? y/n");//Confirmation of the transaction.
            char Confirmation = Convert.ToChar(Console.ReadLine());

            if(Confirmation != 'n' && Confirmation != 'y')
            {
                Console.WriteLine( "Incorrect ! Please enter a correct word" );
                Deposit();
            }
            else if(Confirmation == 'n')
            {
                Console.WriteLine("The transaction is cancelled"); 
                
            }
            else
            {
                Console.Beep();
                double total1 = total + deposite;
                Console.WriteLine($"+{total1:C}");
                Console.ReadKey();
                Console.WriteLine( "Press any key to go back");
            }

           

        }
        public void Balance()
        {
            //This method just display the total money in the account
            Console.WriteLine($"Your Balance is: {total+deposite:C} " );

            Console.WriteLine("");
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
            
        }
        public void Widthdraw()
        {
            double current;
            double widthdraw;
            
            Console.WriteLine( "How much do you want to widthdraw?");
            widthdraw = Convert.ToDouble(Console.ReadLine());

            //Check if the widthdrawal is greater than the total number in the bank account
            if(widthdraw>=total)
            {
                Console.Beep();
                Console.WriteLine( "Insufficient Funds to withdraw!!");
                Console.ReadKey();
                Widthdraw();
            }
            else
            {
                Console.Clear();
                Console.Beep();
                
                Console.WriteLine($"-R{widthdraw-total:C} from the saving account.");

                Console.WriteLine();
                Console.WriteLine($"Total Amount in the Bank: {total:C}");
                Console.WriteLine( "");
               
            }

            current = TotalMoney;
            Console.ReadKey();

            

           
        }


    }
    public class ATM : Account
    {
        public ATM()
        {
           

        }
       
        //This class will handle all the user interface and interaction;
        public void LOGIN()
        {
            Console.Beep();
            Console.WriteLine("Please enter correct 4 digit pin");
            int password = Convert.ToInt16(Console.ReadLine());

            if(password != pin)
            {
                Console.WriteLine("Incorrect Pin !! Please try again");
                Console.ReadKey();
                LOGIN();

            }
            else
            {
                StartScreen();
            }
        }

        public void StartScreen()
        {
            Console.Clear();

            Console.WriteLine( "-------------------------------------------------");
            Console.WriteLine("          WELCOME TO OUR SYSYTEM");
            Console.WriteLine("-------------------------------------------------");
            
            Console.WriteLine( "");
            Console.WriteLine("1.Deposit Money");
            Console.WriteLine("2.Check balance");
            Console.WriteLine("3.Withdraw Money");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            //Check for user Error
            if(userChoice<=0 && userChoice >3)
            {
                Console.Beep();
                Console.WriteLine("Incorrect Value..Please try again");
                StartScreen();

            }
            else
            {
                //will use switch statement to go to the preferred method
                switch (userChoice)
                {
                    case 1:
                        base.Deposit();
                        StartScreen();
                        break;

                    case 2:
                        base.Balance();
                        StartScreen();
                        break;
                    case 3:
                        base.Widthdraw();
                        StartScreen();
                        break;
                
                
                }

            }
            Console.ReadKey();






        }





    }


}
