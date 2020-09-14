using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Norada_Crawler
{
	class EmailSender
	{
		public string SenderEmail { get; set; } = "jonsautoemail@gmail.com";
		public string Password { get; set; } = "rH%O@#7NH48qX7D";
		public string Recipient { get; set; } = "jrbolkema@gmail.com";
		public List<PropertyListing> desiredListings {get; set ;}
		public SmtpClient smtpClient { get; set; }

		public EmailSender(List<PropertyListing> desiredListing)
		{
		smtpClient = new SmtpClient("smtp.gmail.com")
		{
			Port = 587,
			Credentials = new NetworkCredential(SenderEmail,Password),
			EnableSsl = true,
		};
			desiredListings = desiredListing;

		}

		public MailMessage MessageCreator()
		{

			var mailMessage = new MailMessage
			{
				From = new MailAddress(SenderEmail),
				Subject = $"Weekly Norada Update for {DateTimeOffset.Now.Date.ToString("MMMM dd")}",
				Body = BodyCreator(),
				IsBodyHtml = true,
			};
			mailMessage.To.Add(Recipient);
			return mailMessage;

		}

		public string BodyCreator()
		{

			string body = "";
			foreach (var listing in desiredListings)
			{

				var formattedListing = 
					$@"<table style='width: 350px; color:black'>
						<th style='width: 350px;' colspan='2'>
							<a href={listing.ListingPageURL}>
							{listing.Location}
							</a>

						</th>
						<tr>
							<td style='width: 50%;' >{listing.BedRooms}</td>
							<td style='text-align: right;'>{listing.Bathrooms}</td>
						</tr>
						<tr>
							<td style='width: 50%;'>{listing.Size}</td>
							<td style='text-align: right;'>{listing.Parking}</td>
						</tr>
						<tr>
							<td style='width: 50%;'><b>Purchase Price</b></td>
							<td style='text-align: right;'><b>Rental Income</b></td>
						</tr>
						<tr>
							<td style='width: 50%;'>{listing.PurchasePrice}</td>
							<td style='text-align: right;'>{listing.RentalIncome}</td>
						</tr>
						<tr>
							<td style='width: 50%;'><b>Year Built</b></td>
							<td style='text-align: right;'><b>Price Per Sq Foot</b></td>
						</tr>
						<tr>
							<td style='width: 50%;'>{listing.YearBuilt}</td>
							<td style='text-align: right;'>{listing.PricePerSqFoot}</td>
						</tr>
						<tr>
							<td style='width: 50%;'>
								<b>Rent to Value Ratio</b>
							</td>
							<td style='text-align: right;'><b>Neighborhood</b></td>
						</tr>
						<tr>
							<td style='width: 50%;'>{listing.RentValueRatio}%</td>
							<td style='text-align: right;'>{listing.Neighborhood}</td>
						</tr>
						<tr>
							<td style='width: 50%;'>
								<b>Cap Rate</b>
							</td>
							<td style='text-align: right;'><b>Cash Flow</b></td>
						</tr>
						<tr>
							<td style='width: 50%;'>{listing.CapRate}</td>
							<td style='text-align: right;'>{listing.CashFlow}</td>
						</tr>
					</table>
					<br>
					<br>";
				body += formattedListing;
			}
			return body;

		}
		public void SendEmail()
		{
			var message = MessageCreator();
			smtpClient.Send(message);
			Console.WriteLine("Email Sent!");
		}

		//smtpClient.Send(email, "jofergy250@gmail.com", body, "  ");
	}
}
