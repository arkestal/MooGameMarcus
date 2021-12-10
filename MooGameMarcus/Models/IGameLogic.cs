using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameMarcus
{
    public interface IGameLogic
    {
        string CreateGoalNumber(int difficulty);
        string CheckGuess(string goal, string guess, int diffculty);
    }
}
