/*
 ```.net
bowlingGame.roll(noOfPins);
bowlingGame.score();
```
 */

using System;

namespace Bowling_Game
{
    class Bowling_Game
    {
        static void Main(string[] args)
        {    
            var bowlingGame = new BowlingGame();
            /*
           bowlingGame.Roll(5);
           bowlingGame.Roll(4);

           for (var i = 0; i < 14; i++)
           {
               bowlingGame.Roll(5);
           }

           bowlingGame.Roll(5);
           bowlingGame.Roll(4);
           bowlingGame.Roll(10);

           bowlingGame.Score(); */

            //10x strike
            for (var i = 0; i < 12; i++)
            { 
                bowlingGame.Roll(10);     
            }
            bowlingGame.Score();
        }
    }

    public class BowlingGame
    {
        private int[] rolls = new int[21]; // array for the score record
        private int tryRoll = 0; 

        public void Score()
        {
                var score = 0; // total score
                var i = 0;
                for (var frame = 0; frame < 10; frame++) // loop for 10 frames
                {

                    if (rolls[i] == 10) // if strike
                    {
                        if (frame != 9) 
                        {
                            score += rolls[i] + rolls[i + 1] + rolls[i + 2];
                            Console.WriteLine("({0})", rolls[i]);
                            Console.WriteLine(score + "\n");
                            i++;
                        }
                        else // last game for strike
                        {
                            score += rolls[i] + rolls[i + 1] + rolls[i + 2];
                            Console.WriteLine("({0}, {1}, {2})", rolls[i], rolls[i + 1], rolls[i + 2]);
                            Console.WriteLine(score + "\n");
                            i++;
                        }
                    }
                    else if (rolls[i] + rolls[i + 1] == 10) // if spare
                    {
                        score += rolls[i] + rolls[i + 1] + rolls[i + 2];
                        Console.WriteLine("({0}, {1}, {2})", rolls[i], rolls[i + 1], rolls[i + 2]);
                        Console.WriteLine(score + "\n");
                        i += 2;
                    }
                    else // general score
                    {
                        score += rolls[i] + rolls[i + 1];
                        Console.WriteLine("({0}, {1})", rolls[i], rolls[i + 1]);
                        Console.WriteLine(score + "\n");
                        i += 2;
                    }                 
                }
                Console.WriteLine("Your game score {0}", score);
                Console.ReadLine();
        }

        public void Roll(int noOfPins)
        {
           rolls[tryRoll++] = noOfPins;
        }           
     }
}

