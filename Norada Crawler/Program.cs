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
			var url = "https://www.noradarealestate.com/real-estate-investments?paged=1";
			var httpClient = new HttpClient();
			var html = await httpClient.GetStringAsync(url);
			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(html);
			//Console.WriteLine(htmlDocument.Text);
			//var contentDiv = htmlDocument.DocumentNode.Descendants("div")
			//	.Where(node => node.GetAttributeValue("class", "").Equals("card-body carousel_featured")).ToList();
			
		
			
			for (int i = 1; i < 11; i++)
			{
				var name = htmlDocument.DocumentNode
				.SelectSingleNode($"//*[@id='owl-carousel-new']/div[{i}]/div/div[2]/div[2]/div[1]/div/h3")
				.InnerText;
				Console.WriteLine(name);
			}
			

			
			//*[@id="owl-carousel-new"]/div[1]/div/div[2]/div[2]/div[1]/div/h3

			//*[@id="owl-carousel-new"]/div[2]/div/div[2]/div[2]/div[1]/div/h3
			//*[@id="owl-carousel-new"]/div[1]/div/div[2]/div[2]/div[1]/div/h3
			//*[@id="owl-carousel-new"]/div[1]/div/div[2]/div[2]/div[1]/div/h3
			//*[@id="owl-carousel-new"]/div[7]/div/div[2]/div[2]/div[1]/div/h3

			//foreach (var div in contentDiv)
			//{
			//	Console.WriteLine(div);


			//	}
		}
	}
	}

