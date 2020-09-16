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
			using (var connection = new SqliteConnection("Data Source=Norada.db"))
			{
				connection.Open();
				//string dropTable = "drop table if exists listings";
				//SqliteCommand command2 = new SqliteCommand(dropTable, connection);
				//command2.ExecuteNonQuery();
				//string sql = "create table if not exists listings ( " +
				//	"location text," +
				//	"purchasePrice text," +
				//	"rentValueRatio real," +
				//	"yearBuilt text)";
				//SqliteCommand command = new SqliteCommand(sql, connection);
				//command.ExecuteNonQuery();
				//sql = "insert into listings (location, purchasePrice,rentValueRatio,yearBuilt) values ('test', '1000', 1.2, '2010')";
				//command = new SqliteCommand(sql, connection);
				//command.ExecuteNonQuery();
				string queryTable = "select all location, purchasePrice, rentValueRatio, yearBuilt from listings";
				SqliteCommand queryCommand = new SqliteCommand(queryTable, connection);
				SqliteDataReader reader = queryCommand.ExecuteReader();
				while (reader.Read())
				{
					Console.WriteLine($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetDouble(2)} {reader.GetString(3)}");
				}
				connection.Close();

			}

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


