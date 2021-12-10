using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameMarcus
{
    public interface IUserInterface
    {
        string Input(bool isName);
        void Output(string s);
        void Exit();
        void Clear();
    }
}
