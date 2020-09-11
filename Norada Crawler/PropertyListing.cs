using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norada_Crawler
{
	public class PropertyListing
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
		public double RentValueRatio { get; set; }
		public string DealGrader { get; set; }
		public string ListingPageURL { get; set; }


		public void WriteListing()
		{
			Console.WriteLine("*****************************************************************");
			Console.WriteLine($"Address:  { Location}");			
			Console.WriteLine($"{BedRooms, -30} {Bathrooms,30}");
			Console.WriteLine($"{Size, -30} {Parking,30}");
			Console.WriteLine("{0, -30} {1,30}","Purchase Price", "Rental Income");
			Console.WriteLine($"{PurchasePrice,-30} {RentalIncome,30}");
			Console.WriteLine("{0, -30} {1,30}", "Year Built", "Price Per Sq Foot");
			Console.WriteLine($"{YearBuilt,-30} {PricePerSqFoot,30}");
			Console.WriteLine("{0, -30} {1,30}", "Rent to Value Ratio", "Neighborhood");
			Console.WriteLine($"{RentValueRatio}%{"",-26} {Neighborhood,30}");
			Console.WriteLine("{0, -30} {1,30}", "Cap Rate", "Cash Flow");
			Console.WriteLine($"{CapRate,-30} {CashFlow,30}");
			Console.WriteLine($"{ListingPageURL}");
			Console.WriteLine("*****************************************************************");

		}
	}

}
