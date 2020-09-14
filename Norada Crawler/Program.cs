using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using Microsoft.Data.Sqlite;

namespace Norada_Crawler
{
	class Program
	{

		


		static void Main(string[] args)
		{
			//using (var connection = new SqliteConnection("Norada.db"))
			//{
			//	connection.Open();
			//	connection.Close();
			//}

			var crawler = new Crawler();
			crawler.StartCrawlerAsync();
			Console.ReadLine();


		}
		// todo: swtich to while loops, go until null
		// set it up to email
		// maybe save the desirable listings and dont resend them?
		// or maybe save all the listings and add new ones
		// figure out if i can run this on .net core and my pi
		// set up the file to run periodically, pi or pc
	}
	}


