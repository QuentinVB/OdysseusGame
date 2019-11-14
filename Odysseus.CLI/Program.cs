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
                        Console.WriteLine(gamecore.PlayerShip.Orbiting.Feature.Choices);
                    }
                    else
                    {
                        Console.WriteLine($" 1. {gamecore.NextLeft}");
                        Console.WriteLine($" 2. {gamecore.NextRight}");
                        Console.Write("jump to : ");
                    }

                    string answer = Console.ReadLine();

                    if (gamecore.PlayerShip.Orbiting.Feature.Active)
                    {
                        gamecore.PlayerShip.Orbiting.Feature.Answer(answer);
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
