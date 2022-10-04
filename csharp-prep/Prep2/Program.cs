using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 2");

            Console.Write("Your percentage: ");
            string userPercentage = Console.ReadLine();
            int number = int.Parse(userPercentage);

            string sign = "";
            if (number < 97 && number > 60)
            {
                int lastDigit = number % 10;

                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            string letter = "";
            if (number >= 90)
            {
                letter = "A";
            }
            else if (number >= 80)
            {
                letter = "B";
            }
            else if (number >= 70)
            {
                letter = "C";
            }
            else if (number >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            Console.WriteLine($"{letter}{sign}");

            if (number >= 70)
            {
                Console.WriteLine("Congrats! You pass the class!");
            }
            else
            {
                Console.WriteLine("Is not enough. Keet trying!!");
            }
        }
    }
}
