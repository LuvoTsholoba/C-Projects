using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Programmer:Luvo Tsholoba
//Date:07 October 2024
//The purpose: The purpose of this programm is to play a little game called Rock ,Paper and Scissor whereby the user will play with the computer and its won generated answers .The user will have put a correct word or else the progran will beep;

namespace Rock_Paper_Scissor
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string[] computer = { "Rock", "Paper", "Scissor" };
            
            Random ramGame = new Random();
            bool playAgain = true;
            int computerChoice;
            string computerIndex;
            string userChoice;
            string results;



            Console.WriteLine("-------------------------------------");
            Console.WriteLine( "       WELCOME TO OUR GAME OF ROCK ,PAPER AND SCISSOR");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");

            while(playAgain)
            {
                Console.WriteLine("Choose one from the following Rock,paper ,scissor");
                userChoice = Console.ReadLine();
                userChoice.ToLower();

                if(userChoice != "rock" &&  userChoice != "paper" && userChoice != "scissor")
                {
                    Console.Beep();
                    Console.WriteLine("Enter a correct word");
                }
                else
                {
                    //Letting the computer choose its random word
                     computerChoice = ramGame.Next(computer.Length);
                     computerIndex = computer[computerChoice];
                    Console.WriteLine($"Computer choose: {computerChoice}");

                    //Determine the winner
                     results = Winner(userChoice, computerIndex);

                    Console.WriteLine(results);

                    //asking the user

                    Console.WriteLine(  "You want to continue with the game ? Y or N");
                    string userchoice1 = Console.ReadLine();
                    Console.WriteLine( "");


                    if (userchoice1 == "N")
                    {
                        Console.WriteLine( "Thank you for playing our game.");
                        Console.ReadKey();
                        playAgain = false;
                        
                    }
                    else if(userchoice1 == "Y")
                    {
                        Console.Clear();
                        //Letting the computer choose its random word
                        // if the user wants to play again
                        Console.WriteLine("Choose one from the following Rock,paper ,scissor");
                        userChoice = Console.ReadLine();
                        //userChoice.ToLower();

                        if (userChoice != "rock" && userChoice != "paper" && userChoice != "scissor")
                        {
                            Console.Beep();
                            Console.WriteLine("Enter a correct word");
                        }

                        playAgain = true;
                    }

                }

                Console.ReadKey();

            }
        }
         static public string Winner( string player,string  computer)
        {
            //This method is about determining if computer won or the player won.
            if(player == computer)
            {
                return "Its a tie";
            }
            else if (player == "scissor" && computer == "Rock"  || player == "Rock" && computer == "paper"  || player == "scissor" && computer == "Rock")
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Blue;
                return "You win";
            }

            else
            {
                return "Computer wins";
            }
            
                    
        }
    }
}
