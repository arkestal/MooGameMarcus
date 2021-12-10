using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameMarcus
{
    public class FileRepository : IFileRepository
    {
        public void WriteToFile(string name, int numberOfGuesses, string game)
        {
            StreamWriter output = game == "Numbers 00-99" ? new StreamWriter("result.number", append: true) : new StreamWriter("result.moo", append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }

		public string ShowTopList(string game)
		{
			List<PlayerData> results = ReadFromFile(game);
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			string topList = $"{game}\nPlayer   Games Average\n";
			foreach (PlayerData p in results)
			{
				topList = topList + string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()) + "\n";
			}
			return topList;
		}

		public List<PlayerData> ReadFromFile(string game)
        {
			StreamReader input = game == "Numbers 00-99" ? new StreamReader("result.number") : new StreamReader("result.moo");
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData pd = new PlayerData(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}
			}
			input.Close();

			return results;
		}
	}
}
