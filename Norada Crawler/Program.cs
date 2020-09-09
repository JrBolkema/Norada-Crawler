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
			try
			{
				StartCrawlerAsync();
			}
			catch (Exception e)
			{

				throw e;
			}
			

			Console.ReadLine();
	

		}

		private static async Task StartCrawlerAsync()
		{
			for (int j = 1; j < 14; j++)
			{


				var url = $"https://www.noradarealestate.com/real-estate-investments?paged={j}";
				var httpClient = new HttpClient();
				var html = await httpClient.GetStringAsync(url);
				var htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(html);

				for (int i = 1; i < 10; i++)
				{
					NoradaUrls noradaUrls = new NoradaUrls(i);
					PropertyListing listing = new PropertyListing();

					listing.Location = SelectInnerText(htmlDocument, noradaUrls.Location);
					listing.PurchasePrice = SelectInnerText(htmlDocument, noradaUrls.PurchasePrice);
					listing.RentalIncome = SelectInnerText(htmlDocument, noradaUrls.RentalIncome);
					listing.YearBuilt = SelectInnerText(htmlDocument, noradaUrls.YearBuilt);
					listing.PricePerSqFoot = SelectInnerText(htmlDocument, noradaUrls.PricePerSqFoot);
					listing.RentValueRatio = Convert.ToDouble(SelectInnerText(htmlDocument, noradaUrls.RentValueRatio).TrimEnd('%'));
					listing.Neighborhood = SelectInnerText(htmlDocument, noradaUrls.Neighborhood);
					listing.CapRate = SelectInnerText(htmlDocument, noradaUrls.CapRate);
					listing.CashFlow = SelectInnerText(htmlDocument, noradaUrls.CashFlow);
					listing.BedRooms = SelectInnerText(htmlDocument, noradaUrls.BedRooms);
					listing.Bathrooms = SelectInnerText(htmlDocument, noradaUrls.Bathrooms);
					listing.Size = SelectInnerText(htmlDocument, noradaUrls.Size);
					listing.Parking = SelectInnerText(htmlDocument, noradaUrls.Parking);
					if (listing.RentValueRatio >=1 )
					{
						Console.WriteLine("Page " + j);
						Console.WriteLine("Purchase Price: " + listing.PurchasePrice);
						Console.WriteLine("RVR " + listing.RentValueRatio);
					}
					
				}
				

			}

		}

		public static string SelectInnerText(HtmlDocument htmlDocument, string path)
		{
			return htmlDocument.DocumentNode
				.SelectSingleNode(path)
				.InnerText;
		}
	}
	}

