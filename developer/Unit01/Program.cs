using System;

namespace Unit01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nLet's Play Tic-Tac-Toe!\n");

            int play = 9;
            bool playerWin = false;

            string s1 = "1";
            string s2 = "2";
            string s3 = "3";
            string s4 = "4";
            string s5 = "5";
            string s6 = "6";
            string s7 = "7";
            string s8 = "8";
            string s9 = "9";

            string turn = "o";

            do
            {
                turn = ChangeTurn(turn);

                Console.WriteLine($"\n{s1}|{s2}|{s3}\n-+-+-\n{s4}|{s5}|{s6}\n-+-+-\n{s7}|{s8}|{s9}");                

                bool used = false;
                do
                {
                    Console.Write($"\n{turn}'s turn to choose a square (1-9): ");
                    string userChoice = Console.ReadLine();

                    if (userChoice == s1 && CanBeUsed(s1))
                    {
                        s1 = turn;
                        used = false;
                    }
                    else if (userChoice == s2 && CanBeUsed(s2))
                    {
                        s2 = turn;
                        used = false;
                    }
                    else if (userChoice == s3 && CanBeUsed(s3))
                    {
                        s3 = turn;
                        used = false;
                    }
                    else if (userChoice == s4 && CanBeUsed(s4))
                    {
                        s4 = turn;
                        used = false;
                    }
                    else if (userChoice == s5 && CanBeUsed(s5))
                    {
                        s5 = turn;
                        used = false;
                    }
                    else if (userChoice == s6 && CanBeUsed(s6))
                    {
                        s6 = turn;
                        used = false;
                    }
                    else if (userChoice == s7 && CanBeUsed(s7))
                    {
                        s7 = turn;
                        used = false;
                    }
                    else if (userChoice == s8 && CanBeUsed(s8))
                    {
                        s8 = turn;
                        used = false;
                    }
                    else if (userChoice == s9 && CanBeUsed(s9))
                    {
                        s9 = turn;
                        used = false;
                    }
                    else
                    {
                        used = true;
                        Console.WriteLine("That square was alredy used, please chose another.");
                    }
                } while (used);

                playerWin = DidSomeoneWin(s1, s2, s3, s4, s5, s6, s7, s8, s9);
                play --;

            } while (play != 0 && playerWin == false);
        
            Console.WriteLine($"\n{s1}|{s2}|{s3}\n-+-+-\n{s4}|{s5}|{s6}\n-+-+-\n{s7}|{s8}|{s9}");
            
            if (playerWin)
            {
                Console.WriteLine($"\n{turn} won! Congratulations!");
            }
            else
            {
                Console.WriteLine("\nNobody won. Good luck next time!");
            }

                Console.WriteLine("\nThanks for play Tic Tac Toe!\n");

        }

        static bool CanBeUsed(string squareNumber)
        {
            bool used = false;
            if (squareNumber != "x" && squareNumber != "o")
            {
                used = true;
            }

            return used;
        }

        static string ChangeTurn(string actualTurn)
        {
            if (actualTurn == "x")
            {
                actualTurn = "o";
            }
            else
            {
                actualTurn = "x";
            }
            
            return actualTurn;
        }

        static bool DidSomeoneWin(string n1, string n2,string n3, string n4, string n5, string n6, string n7, string n8, string n9)
        {
            bool win = false;
            if ((n1 == n2 && n1 == n3) || (n4 == n5 && n4 == n6) || (n7 == n8 && n7 == n9))
            {
                win = true;
            }
            else if ((n1 == n4 && n1 == n7) || (n2 == n5 && n2 == n8) || (n3 == n6 && n3 == n9))
            {
                win = true;
            }
            else if ((n1 == n5 && n1 == n9) || (n3 == n5 && n3 == n7))
            {
                win = true;
            }
            else
            {
                win = false;
            }

            return win;
        }
    }
}
