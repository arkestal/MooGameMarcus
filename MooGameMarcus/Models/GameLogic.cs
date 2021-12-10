using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameMarcus
{
    public class GameLogic : IGameLogic
    {
		public string CreateGoalNumber(int difficulty)
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < difficulty; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit) && difficulty != 2)
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal += randomDigit;
			}
			return goal;
		}

		public string CheckGuess(string goal, string guess, int difficulty)
		{
            if (guess.ToLower() == "q")
            {
				return guess;
            }
			int cows = 0, bulls = 0;
			if (difficulty != 2)
			{
				guess += difficulty == 6 ? "      " : "    ";     // if player entered less than 6 or 4 chars depending on difficulty
				for (int i = 0; i < difficulty; i++)
				{
					for (int j = 0; j < difficulty; j++)
					{
						if (goal[i] == guess[j])
						{
							_ = i == j ? bulls++ : cows++;
						}
					}
				}
				return _ = difficulty == 6 ? "BBBBBB".Substring(0, bulls) + "," + "CCCCCC".Substring(0, cows) : "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
			}
            else
            {
				return _ = guess == goal ? "Win!" : int.Parse(guess) > int.Parse(goal) ? "Goal number is lower!" : "Goal number is higher!"; 

			}
		}
	}
}
