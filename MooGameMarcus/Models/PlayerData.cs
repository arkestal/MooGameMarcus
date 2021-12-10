using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameMarcus
{
	public class PlayerData
	{
		public string Name { get; set; }
		public int NumberOfGames { get; set; }
		int totalGuess;


		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NumberOfGames = 1;
			totalGuess = guesses;
		}

        public void Update(int guesses)
		{
			totalGuess += guesses;
			NumberOfGames++;
		}

		public double Average()
		{
			return (double)totalGuess / NumberOfGames;
		}


		public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
