using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Norada_Crawler
{
	public class Crawler
	{
		public bool loopShouldContinue = true;
		public async void StartCrawlerAsync()
		{
			List<PropertyListing> allProperties = new List<PropertyListing>();
			var j = 1;
			while (loopShouldContinue == true)
			{
				var i = 1;




				var url = $"https://www.noradarealestate.com/real-estate-investments?paged={j}";
				var httpClient = new HttpClient();
				var html = await httpClient.GetStringAsync(url);
				var htmlDocument = new HtmlDocument();
				htmlDocument.LoadHtml(html);

				while (loopShouldContinue == true)
				//for (int i = 1; i < 10; i++)
				{
					NoradaUrls noradaUrls = new NoradaUrls(i);
					PropertyListing listing = MapToProperyListing(htmlDocument, noradaUrls);
					listing.ListingPageURL = url;
					allProperties.Add(listing);
					if (loopShouldContinue == false || i == 10)
					{
						break;
					}

					i++;
				}
				Console.WriteLine($"Page {j} Complete!");

				if (loopShouldContinue == false)
				{
					break;
				}
				j++;
			}
				var sortedListings = from listing in allProperties
									 where listing.RentValueRatio >= 1
									 orderby listing.RentValueRatio descending, listing.PurchasePrice descending, listing.YearBuilt
									 select listing;
			var emailSender = new EmailSender(sortedListings.ToList());
			emailSender.SendEmail();
			
		}
		public PropertyListing MapToProperyListing(HtmlDocument htmlDocument, NoradaUrls noradaUrls)
		{
			PropertyListing listing = new PropertyListing();

			try
			{
				listing.Location = SelectInnerText(htmlDocument, noradaUrls.Location) ?? null;
			}
			catch (NullReferenceException ex)
			{
				setContinueToFalse();
				return new PropertyListing {Location = "Last Listing"};
			}

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

		private void setContinueToFalse()
		{
			loopShouldContinue = false;
		}

		public static string SelectInnerText(HtmlDocument htmlDocument, string path)
		{
			return htmlDocument.DocumentNode
				.SelectSingleNode(path)
				.InnerText;
		}
	}
}

