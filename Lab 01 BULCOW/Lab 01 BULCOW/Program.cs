// Created by Andy E. Wold and Miranda Motter
// CS 176 -- Windows Desktop Development
// Lab #1 [BULCOW Game]
// Date 13 May 2016

using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01_BULCOW
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random rnd = new Random();

            // Initialize victory number
            int checkNum = 0;
            string solutionNum = "";
            string exitQuit = "";

            // Generate a 5-digit number with unique 
            while (solutionNum.Length < 5)
            {
            TryAgain:
                // Reassign number to random int
                checkNum = rnd.Next(1, 9);

                // Check number for duplicates
                if (solutionNum.Contains(Convert.ToString(checkNum)))
                    goto TryAgain;
                solutionNum = solutionNum + Convert.ToString(checkNum);

                //Test
                WriteLine("solutionNum is now: " + solutionNum);
            }

            //Test
            WriteLine("solutionNum is: " + solutionNum);
            WriteLine();

            // Display rules to player
            WriteLine("You will need to guess the 5-digit number I am thinking of. ");
            WriteLine();
            WriteLine("All 5 digits must be unique, and be between 1-9.");
            WriteLine();
            WriteLine("You will get one Bull for each correct digit in the correct place.");
            WriteLine("You will get one Cow for each correct digit that is NOT in the correct place.");
            WriteLine();

            // Initialize game variables
            string userGuess = "";
            int countBull = 0;
            int countCows = 0;

            // Loop through until user guesses the correct number
            // Once the number is correctly guessed, it will exit the WHILE loop
            while (solutionNum != userGuess)
            {
                invalidGuess:

                // Get guess from user
                Write("Please enter your guess or \"00000\" to quit: ");
                userGuess = ReadLine();

                // Check if the user wants to quit
                //Test                WriteLine(userGuess);
                if (userGuess == "00000")
                {
                    exitQuit = "Y";
                    userGuess = solutionNum;
                }
                else if (userGuess.Length != 5)
                {
                    WriteLine("Guess contains wrong number of digits. Please try again.");
                    goto invalidGuess;
                }

                // Test Note:  Work on number checks after logic is finished 
                // Confirm that guessed number digits are from 1 to 9
                string validNumbers = "123456789";

                for (int i = 0; i < 5; i++)
                {
                    if (validNumbers.Contains(Convert.ToString(userGuess[i])))
                        continue;
                    else
                    {
                        WriteLine("You did not enter numbers between 1 and 9.");
                        goto invalidGuess;
                    }
                }

                // Check the last digit of the guess against the remaining digits
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i != j && userGuess[i] == userGuess[j])
                        {
                            WriteLine("Your guess contains duplicate digits.");
                            goto invalidGuess;
                        }
                    }
                }

                // Determine the number of Bulls
                for (int i = 0; i < 5; i++)
                {
                    if (solutionNum[i] == userGuess[i])
                        countBull++;
                }
                Write("Bulls: " + countBull);

                // Determine the number of Cows
                for (int i = 0; i < 5; i++)
                {
                    if (solutionNum.Contains(userGuess[i]))
                        countCows++;
                }
                countCows = countCows - countBull;
                WriteLine("  Cows: " + countCows);
                countBull = 0;
                countCows = 0;
            }

            if (exitQuit == "Y")
            {
                // When the user quits
                WriteLine();
                WriteLine("You have quit the game.  You should have guessed " + solutionNum + ", loser.  ;)");
                WriteLine();
                Write("Please press a key to continue.");
                int gameEnd = Read();
            }
            else
            {
                // When the user's guess matches the computer's number
                WriteLine();
                WriteLine("CONGRATULATIONS!  You guessed my number: " + solutionNum);
                WriteLine();
                Console.Write("Press <Enter> to exit... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            }
        }
    }
}
