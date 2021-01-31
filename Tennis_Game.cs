/*
 The interface should look something like this in .Net:
```
  Match match = new Match("player 1", "player 2");
  match.pointWonBy("player 1");
  match.pointWonBy("player 2");
  // this will return "0-0, 15-15"
  match.score();
  match.pointWonBy("player 1");
  match.pointWonBy("player 1");
  // this will return "0-0, 40-15"
  match.score();
  match.pointWonBy("player 2");
  match.pointWonBy("player 2");
  // this will return "0-0, Deuce"
  match.score();
  match.pointWonBy("player 1");
  // this will return "0-0, Advantage player 1"
  match.score();
  match.pointWonBy("player 1");
  // this will return "1-0"
  match.score();
```
 */

using System;

namespace Tennis_game
{
    public class Match
    {
        static void Main(string[] args)
        {
            Match match = new Match("player 1", "player 2");

            match.pointWonBy("player 1");
            match.pointWonBy("player 2");
            // this will return "0-0, 15-15"
            match.score();

            match.pointWonBy("player 1");
            match.pointWonBy("player 1");
            // this will return "0-0, 40-15"
            match.score();
            
            match.pointWonBy("player 2");
            match.pointWonBy("player 2");
            // this will return "0-0, Deuce"
            match.score();

            match.pointWonBy("player 1");
            // this will return "0-0, Advantage player 1"
            match.score();

            match.pointWonBy("player 1");
            // this will return "1-0"
            match.score();
            
            Console.ReadLine();

        }

        private int scorePly1 = 0;
        private int scorePly2 = 0;
        private int setPly1 = 0;
        private int setPly2 = 0;
        private bool deuce = false;
        private bool tieBreak = false;
        private bool gameEnd = false;
        private string gameResult;

        public void score() // scoring function
        {            
            //  convert score
            if (scorePly1 == 45 & scorePly2 != 45)
            {
                scorePly1 = 40;
     
            }
            else if (scorePly2 == 45 & scorePly1 != 45)
            {
                scorePly2 = 40;
            }
            // deuce scoring
            if (scorePly1 == 40 & scorePly2 == 40 & deuce == false)
            {
                gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + ", Deuce";
                deuce = true;
            }
            else if (scorePly1 == 55 & scorePly2 == 40 & deuce == true)
            {
                gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + ", Advantage player 1";
            }
            else if (scorePly2 == 55 & scorePly1 == 40 & deuce == true)
            {
                gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + ", Advantage player 2";
            }
            else if (scorePly1 == 70 & scorePly2 == 40 & deuce == true) // game final score for deuce
            {
                setPly1 += 1;
                gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + "\n";
                deuce = false;
                scorePly1 = 0;
                scorePly2 = 0;
            }
            else if (scorePly2 == 70 & scorePly1 == 40 & deuce == true)
            {
                setPly2 += 1;
                gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + "\n";
                deuce = false;
                scorePly1 = 0;
                scorePly2 = 0;
            }
            else if (scorePly1 == 55 & scorePly2 == 55 & deuce == true) // back to duece
            {
                gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + ", Deuce";
                scorePly1 = 40;
                scorePly2 = 40;
            }
            else if (deuce == false) // general scoring
            {
                if (scorePly1 == 55 & scorePly2 != 40 & deuce == false) // player1 wins the game
                {
                    setPly1 += 1;
                    gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + "\n";
                    scorePly1 = 0;
                    scorePly2 = 0;
                }
                else if (scorePly2 == 55 & scorePly1 != 40 & deuce == false) // player2 wins the game
                {
                    setPly2 += 1;
                    gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + "\n";
                    scorePly1 = 0;
                    scorePly2 = 0;
                }
                else if (gameEnd == false)
                {
                    gameResult = Convert.ToString(setPly1) + "-" + Convert.ToString(setPly2) + ", " + Convert.ToString(scorePly1) + "-" + Convert.ToString(scorePly2);
                }
            }

            // tie-break scoring
            if (tieBreak == true & gameEnd == false)
            {
                if (scorePly1 == 3 & scorePly2 == 3 & deuce == false) // deuce
                {
                    gameResult = "Tie-break, Deuce";
                    deuce = true;
                }
                else if (scorePly1 == 4 & scorePly2 == 3 & deuce == true)
                {
                    gameResult = "Tie-break, Advantage player 1";
                }
                else if (scorePly2 == 4 & scorePly1 == 3 & deuce == true)
                {
                    gameResult = "Tie-break, Advantage player 2";
                }
                else if (scorePly1 == 5 & scorePly2 == 3) // game final score for deuce
                {
                    gameResult = "\nPlayer 1 Wins!!\n";
                    deuce = false;
                    scorePly1 = 0;
                    scorePly2 = 0;
                }
                else if (scorePly2 == 5 & scorePly1 == 3)
                {
                    gameResult = "\nPlayer 2 Wins!!\n";
                    deuce = false;
                    scorePly1 = 0;
                    scorePly2 = 0;
                }
                else if (scorePly1 == 4 & scorePly2 == 4 & deuce == true) // back to duece
                {
                    gameResult = "\nTie-break, Deuce";
                    scorePly1 = 3;
                    scorePly2 = 3;
                }
                else if (deuce == false) // general scoring
                {
                    if (scorePly1 == 4 & scorePly2 != 3 & deuce == false) // player1 wins the game
                    {
                        gameResult = "\nPlayer 1 Wins!!";
                        scorePly1 = 0;
                        scorePly2 = 0;
                        gameEnd = true;
                    }
                    else if (scorePly2 == 4 & scorePly1 != 3 & deuce == false) // player2 wins the game
                    {
                        gameResult = "\nPlayer 2 Wins!!";
                        scorePly1 = 0;
                        scorePly2 = 0;
                        gameEnd = true;
                    }
                    else if (gameEnd == false)
                    {
                        gameResult = "Tie-break, " + Convert.ToString(scorePly1) + "-" + Convert.ToString(scorePly2);
                    }
                }
            }
            Console.WriteLine(gameResult);
            setResult(); // print result of the match
        }

        public void pointWonBy(string player) // adding score to players function
        {
            if (setPly1 >= 6 & setPly2 >= 6)
            {
                if (setPly1 == setPly2)
                {
                    tieBreak = true;
                    if (player == "player 1")
                    {
                        scorePly1 += 1;
                    }
                    else
                    {
                        scorePly2 += 1;
                    }
                }
                else
                {
                    tieBreak = false;
                    if (player == "player 1")
                    {
                        scorePly1 += 15;
                    }
                    else
                    {
                        scorePly2 += 15;
                    }
                }
            }
            else
            {
                tieBreak = false;
                if ((setPly1 >= 6 & setPly2 <= 6) & (setPly1 - setPly2 >= 2))
                {
                    gameResult = "...";
                    gameEnd = true;
                }
                else if ((setPly2 >= 6 & setPly1 <= 6) & (setPly2 - setPly1 >= 2))
                {
                    gameResult = "...";
                    gameEnd = true;
                }
                else
                {
                    if (player == "player 1")
                    {
                        scorePly1 += 15;
                    }
                    else
                    {
                        scorePly2 += 15;
                    }
                }
            }
        }
        public Match(string player1, string player2)
        {
        }
        public void setResult() // generate result of the match function
        {
            if (setPly1 >= 6 | setPly2 >= 6)
            {
                if (setPly1 - setPly2 >= 2) //player1 wins the game
                {
                    Console.WriteLine("\nPlayer 1 Win!");
                }
                else if (setPly2 - setPly1 >= 2) // player2 wins the game
                {
                    Console.WriteLine("\nPlayer 2 Win!");
                }
            }
        }
    }
}
