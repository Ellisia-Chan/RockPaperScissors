using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("  Welcome to Rock Paper Scissors!");
                Console.WriteLine();
                Console.WriteLine(" Select Score:");
                Console.WriteLine("  1 - 5 Score");
                Console.WriteLine("  2 - 10 Score");
                Console.WriteLine("  3 - 15 Score");
                Console.WriteLine("  4 - 20 Score");
                Console.WriteLine("  5 - Exit");
                Console.WriteLine();
                Console.Write("  > ");

                string option = Console.ReadLine();

                if (option != "1" &&
                    option != "2" &&
                    option != "3" &&
                    option != "4" &&
                    option != "5")
                {
                    Console.WriteLine("  Please Enter a Valid Option.");
                    Thread.Sleep(1000);
                    continue;
                }

                if (option == "5")
                {
                    Console.WriteLine();
                    Console.Write("Exiting Program");
                    Thread.Sleep(500);
                    Console.Write(".");
                    Thread.Sleep(500);
                    Console.Write(".");
                    Thread.Sleep(500);
                    Console.Write(".");
                    Thread.Sleep(500);
                    break;
                }

                Game(RoundScore(option));
            }
        }

        static void Game(int Score)
        {
            int scoreDecision = 0;
            int playerScore = 0;
            int enemyScore = 0;

            Console.WriteLine($"  Score to Win: {Score}");
            while (true)
            {
                Console.WriteLine($"  Player Score - {playerScore}  Enemy Score - {enemyScore}");
                Console.WriteLine("  Select Actions: r - Rock  p - Paper  s - Scissors");

                Console.Write(" > ");
                string playerAction = Console.ReadLine();
                Console.WriteLine();

                if (playerAction.ToLower() != "r" && playerAction.ToLower() != "p" && playerAction.ToLower() != "s")
                {
                    Console.WriteLine("  Invalid Action! Please Try Again.");
                    continue;
                }

                scoreDecision = MechanicsCondition(playerAction, EnemyRoll());

                if (scoreDecision == 1)
                {
                    playerScore += 1;
                }

                if (scoreDecision == -1)
                {
                    enemyScore += 1;
                }

                if (playerScore == Score)
                {
                    Console.WriteLine("  You Win the Game!");
                    break;
                }

                if (enemyScore == Score)
                {
                    Console.WriteLine("  You Lose the Game!");
                    break;
                }
            }
        }

        static int RoundScore(string option)
        {
            switch (option)
            {
                case "1":
                    return 5;
                case "2":
                    return 10;
                case "3":
                    return 15;
                case "4":
                    return 20;
                default:
                    return 0;
            }
        }

        static int MechanicsCondition(string playerAction, int enemyActionNum)
        {
            string enemyAction = "";
            string enemyActionString = "";

            switch (enemyActionNum)
            {
                case 0:
                    {
                        enemyAction = "r";
                        enemyActionString = "Rock!";
                        break;
                    }
                case 1:
                    {
                        enemyAction = "p";
                        enemyActionString = "Paper!";
                        break;
                    }
                case 2:
                    {
                        enemyAction = "s";
                        enemyActionString = "Scissors!";
                        break;
                    }
            }

            Console.Write("  Enemy Choose");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");

            Console.Write($" {enemyActionString}");
            Console.WriteLine();

            if (playerAction.ToLower() == "r" || playerAction.ToLower() == "p" || playerAction.ToLower() == "s")
            {
                switch (playerAction.ToLower())
                {
                    case "r":
                        {
                            if (enemyAction == "r")
                            {
                                Console.WriteLine("  Tie!");
                                Console.WriteLine();
                                return 0;
                            }

                            if (enemyAction == "s")
                            {
                                Console.WriteLine("  You Win!");
                                Console.WriteLine();
                                return 1;
                            }

                            if (enemyAction == "p")
                            {
                                Console.WriteLine("  You Lose!");
                                Console.WriteLine();
                                return -1;
                            }
                            break;
                        }

                    case "p":
                        {
                            if (enemyAction == "p")
                            {
                                Console.WriteLine("  Tie!");
                                Console.WriteLine();
                                return 0;
                            }

                            if (enemyAction == "r")
                            {
                                Console.WriteLine("  You Win!");
                                Console.WriteLine();
                                return 1;
                            }

                            if (enemyAction == "s")
                            {
                                Console.WriteLine("  You Lose!");
                                Console.WriteLine();
                                return -1;
                            }
                            break;
                        }

                    case "s":
                        {
                            if (enemyAction == "s")
                            {
                                Console.WriteLine("  Tie!");
                                Console.WriteLine();
                                return 0;
                            }

                            if (enemyAction == "p")
                            {
                                Console.WriteLine("  You Win!");
                                Console.WriteLine();
                                return 1;
                            }

                            if (enemyAction == "r")
                            {
                                Console.WriteLine("  You Lose!");
                                Console.WriteLine();
                                return -1;
                            }
                            break;
                        }
                }
            }
            return 0;
        }

        static int EnemyRoll()
        {
            Random enemyNum = new Random();
            return enemyNum.Next(0, 3);
        }
    }
}
