using Odysseus.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore gamecore = new GameCore(50);

            do
            {
                Console.Clear();
                if(gamecore.PlayerShip.IsAlive)
                {
                    gamecore.GenerateNextDestinations();

                    Console.WriteLine(gamecore.PlayerShip);
                    if(gamecore.PlayerShip.Orbiting.Feature.Active)
                    {
                        Console.WriteLine(gamecore.PlayerShip.Orbiting.Feature.Display);
                        for (int i = 0; i < gamecore.PlayerShip.Orbiting.Feature.Choices.Length; i++)
                        {
                            Console.WriteLine($"{i}. {gamecore.PlayerShip.Orbiting.Feature.Choices[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine(gamecore.PlayerShip.Orbiting.Feature.Result);


                        Console.WriteLine($"\n 1. {gamecore.NextLeft}");
                        Console.WriteLine($" 2. {gamecore.NextRight}");
                        Console.Write("jump to : ");
                    }

                    string answer = Console.ReadLine();

                    if (gamecore.PlayerShip.Orbiting.Feature.Active)
                    {
                        if (int.TryParse(answer, out int intParsed)) gamecore.PlayerShip.Orbiting.Feature.Answer(intParsed);
                        else { gamecore.PlayerShip.Orbiting.Feature.Answer(-1); }
                    }
                    else
                    {
                        switch (answer)
                        {
                            case "1":                               
                                gamecore.WarpShipTo(gamecore.NextLeft);
                                break;
                            case "2":
                                gamecore.WarpShipTo(gamecore.NextRight);
                                break;
                            default:
                                break;
                        }
                    }

                    gamecore.PlayerShip.UpdateGameTurn();
                }
                else
                {
                    Console.WriteLine("Game Over");
                    Console.ReadLine();
                }



            } while (true);

        }
    }
}
