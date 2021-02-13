using System;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.IO;

namespace LC951mail
{
	public class Program
	{
		public static void Main()
		{
			Console.Write("Enter the SMTP address you want to send from: ");
			string SmtpAddress = Console.ReadLine();

			Console.Write("Enter your email address: ");
			string EmailAddress = Console.ReadLine();

			Console.Write("Enter who you want to send your message to: ");
			string Recipient = Console.ReadLine();

			Console.Write("Enter your password: ");
			string EmailPassword = Console.ReadLine();

			Console.Write("Enter the message subject: ");
			string Subject = Console.ReadLine();

			Console.Write("Enter the path to a text file containing the message you want to send: ");
			string ContentToSend = Console.ReadLine();

			List<string> ToSend = new List<string>();
			string FinishedToSend;
			using (StreamReader sr = File.OpenText(ContentToSend))
			{
				string ReadString;
				while ((ReadString = sr.ReadLine()) != null)
				{
					ToSend.Add(ReadString);
				}
				FinishedToSend = string.Join("\n", ToSend);
			}
					
			var MailClient = new SmtpClient(SmtpAddress)
			{
				Port = 587,
				Credentials = new NetworkCredential(EmailAddress, EmailPassword),
				EnableSsl = true,
			};	
			
			Console.WriteLine("Sending message...");
			MailClient.Send(EmailAddress, Recipient, Subject, FinishedToSend);
			Console.WriteLine("Message sent!");
		}	
	}
}	

