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
				var tables = div.Descendants("table").ToList();
				foreach (var table in tables)
				{
					var tableData = table.Descendants("td").ToList();

					//foreach (var data in tableData)
					//{
					//	Console.WriteLine(data.InnerText.Trim().Length);
					//	if (data.InnerText.Trim().Length > 75)
					//	{
					//		tableData.IndexOf(data);
					//		tableData.RemoveAt(tableData.IndexOf(data));
					//	}
					//	//Console.WriteLine("DATA: " + data.InnerText.Trim());
					//}

					foreach (var data in tableData)
					{
						Console.WriteLine("DATA: " + data.InnerText.Trim());
					}
					//var tableData1 = table.Descendants("td")
					//	.Where(node => node.GetAttributeValue("class", "").Equals("Prop-TD-1")).ToList();
					//var tableData2 = table.Descendants("td")
					//	.Where(node => node.GetAttributeValue("class", "").Equals("Prop-TD-2")).ToList();

					
				}
			}
		}
	}
}
