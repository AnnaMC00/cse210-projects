using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 3");

            string again = "yes";
            do
            {

                Random num = new Random();
                int randomNumber = num.Next(1,100);

                Console.WriteLine("I have the magic number..");

                int attempts = 0;
                bool play = true;
                while (play == true)
                {
                    Console.Write("What is your guess? ");
                    string input = Console.ReadLine();
                    int guess = int.Parse(input);

                    if (guess > randomNumber)
                    {
                        Console.WriteLine("Lower");
                        play = true;
                    }
                    else if (guess < randomNumber)
                    {
                        Console.WriteLine("Higher");
                        play = true;
                    }
                    else
                    {
                        play = false;
                    }
                    attempts ++;
                }

                Console.WriteLine($"You guessed it!\nYou did it in {attempts} attempts.");
                
                Console.Write("Do you want to play again (yes/no)? ");
                again = Console.ReadLine();

            } while (again == "yes");

            Console.WriteLine("Thanks for playing!");
        }
    }
}
