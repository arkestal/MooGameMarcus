using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameMarcus
{
    class ConsoleIO : IUserInterface
    {
        public string Input(bool isName)
        {
            if (isName)
            {
                return FirstLetterUpperCase(Console.ReadLine());
            }
            return Console.ReadLine();
        }

        public void Output(string s)
        {
            Console.WriteLine(s);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void Clear()
        {
            Console.Clear();
        }
        private string FirstLetterUpperCase(string playerName)
        {
            return char.ToUpper(playerName[0]) + playerName.Substring(1);
        }
    }
}
