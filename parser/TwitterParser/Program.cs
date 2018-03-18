using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitterParser
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		private static void ReadJsonFromFile()
		{
			string createText = "";


			string jsonFile = "";
			List<Twitts> twitts = new List<Twitts>();
			using (StreamReader sr = new StreamReader("../../../python/spam/bruno/musk.json"))
			{
				jsonFile = sr.ReadToEnd();
			}
			twitts = JsonConvert.DeserializeObject<List<Twitts>>(jsonFile);

			foreach (Twitts i in twitts)
			{
				createText += i.full_text.ToString().Replace(",", " ").Replace("'", "").Replace("\"", "").Replace("\n", "").Replace("\r", "") + "," + i.created_at + ",jimmyfallon" + Environment.NewLine;
			}
			File.WriteAllText("../../../python/spam/bruno/musk.txt", createText);
		}
	}
}
