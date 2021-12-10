using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameMarcus
{
    public interface IFileRepository
    {
        void WriteToFile(string name, int numberOfGuesses, string game);
        string ShowTopList(string game);
        List<PlayerData> ReadFromFile(string game);
    }
}
