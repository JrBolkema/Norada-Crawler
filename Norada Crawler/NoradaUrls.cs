using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norada_Crawler
{
	public class NoradaUrls
	{
		public string Location { get; set; }
		public string PurchasePrice { get; set; }
		public string RentalIncome { get; set; }
		public string BedRooms { get; set; }
		public string Bathrooms { get; set; }
		public string Size { get; set; }
		public string PricePerSqFoot { get; set; }
		public string YearBuilt { get; set; }
		public string Parking { get; set; }
		public string Neighborhood { get; set; }
		public string PropertyTax { get; set; }
		public string InsuranceOrHOA { get; set; }
		public string PropertyManagement { get; set; }
		public string CashFlow { get; set; }
		public string CapRate { get; set; }
		public string RentValueRatio { get; set; }
		public string DealGrader { get; set; }

		public NoradaUrls(int listingNumber)
		{
			Location = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/h4";
			PurchasePrice = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[2]/div[1]/div/h3";
			RentalIncome = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[2]/div[2]/div/h3";
			YearBuilt = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[3]/div[1]/div/h3";
										//*[@id="owl-carousel-new"]/div[1]/div/div[2]/div[3]/div[1]/div/h3
			PricePerSqFoot = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[3]/div[2]/div/h3";
									         //*[@id="owl-carousel-new"]/div[1]/div/div[2]/div[3]/div[2]/div/h3
			RentValueRatio = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[4]/div[1]/div/h3";
										     //*[@id="owl-carousel-new"]/div[1]/div/div[2]/div[4]/div[1]/div/h3
			Neighborhood = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[4]/div[2]/div/h3/span";
										   //*[@id="owl-carousel-new"]/div[1]/div/div[2]/div[4]/div[2]/div/h3/span
			CapRate =  $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[5]/div[1]/div/h3";
			CashFlow = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[5]/div[2]/div/h3";
			BedRooms = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[1]/div[1]/div[1]";
			Bathrooms = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[1]/div[2]/div[1]";
			Size = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[1]/div[1]/div[2]";
			Parking = $"//*[@id='owl-carousel-new']/div[{listingNumber}]/div/div[2]/div[1]/div[2]/div[2]";

		}
		public void WriteProperties()
		{
			Console.WriteLine(Location);
			Console.WriteLine(PurchasePrice);
			Console.WriteLine(RentalIncome);
			Console.WriteLine(YearBuilt);
			Console.WriteLine(PricePerSqFoot);
			Console.WriteLine(RentValueRatio);
			Console.WriteLine(Neighborhood);
			Console.WriteLine(CapRate);
			Console.WriteLine(CashFlow);

		}

	}
	
}
