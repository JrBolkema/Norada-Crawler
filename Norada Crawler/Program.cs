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
			List<PropertyListing> desirableProperties = new List<PropertyListing>();
			for (int j = 1; j < 13; j++)
			{

				// todo: swtich to while loops, go until null
				// set it up to email
				// maybe save the desirable listings and dont resend them?
				// or maybe save all the listings and add new ones
				// figure out if i can run this on .net core and my pi
				// set up the file to run periodically, pi or pc
				var url = $"https://www.noradarealestate.com/real-estate-investments?paged={j}";
				var httpClient = new HttpClient();
				var html = await httpClient.GetStringAsync(url);
				var htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(html);
				

				for (int i = 1; i < 10; i++)
				{
					NoradaUrls noradaUrls = new NoradaUrls(i);
					PropertyListing listing = MapToProperyListing(htmlDocument, noradaUrls);
					listing.ListingPageURL = url;
					if (listing.RentValueRatio >= 1)
					{
						Console.WriteLine("Added a property!");
						desirableProperties.Add(listing);
					}
				}
				Console.WriteLine($"Page {j} Complete!");
			}
			foreach (var listing in desirableProperties)
			{
				listing.WriteListing();
			}

		}

		private static PropertyListing MapToProperyListing(HtmlDocument htmlDocument, NoradaUrls noradaUrls)
		{
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
			listing.BedRooms = SelectInnerText(htmlDocument, noradaUrls.BedRooms).Trim();
			listing.Bathrooms = SelectInnerText(htmlDocument, noradaUrls.Bathrooms).Trim();
			listing.Size = SelectInnerText(htmlDocument, noradaUrls.Size).Trim();
			listing.Parking = SelectInnerText(htmlDocument, noradaUrls.Parking).Trim();
			
			return listing;
		}

		public static string SelectInnerText(HtmlDocument htmlDocument, string path)
		{
			return htmlDocument.DocumentNode
				.SelectSingleNode(path)
				.InnerText ?? "99";
		}
	}
	}

