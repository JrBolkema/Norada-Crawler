using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;

namespace Norada_Crawler
{
	class Program
	{
		static void Main(string[] args)
		{
			StartCrawlerAsync();
			Console.ReadLine();
		}

		private static async Task StartCrawlerAsync()
		{
			var url = "http://www.noradarealestate.com/Real-Estate-Investments/Illinois/Chicago/";
			var httpClient = new HttpClient();
			var html = await httpClient.GetStringAsync(url);
			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(html);
			//Console.WriteLine(htmlDocument.Text);
			var contentDiv = htmlDocument.DocumentNode.Descendants("div")
				.Where(node => node.GetAttributeValue("id", "").Equals("view1")).ToList();

			foreach (var div in contentDiv)
			{
				Console.WriteLine(div.Descendants("table").ToString());
			}
		}
	}
}
