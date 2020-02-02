using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCL_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace CCL_WEB.Controllers
{
    public class ContactController : Controller
    {
        private readonly CCLdbContext context;

        public ContactController(CCLdbContext context)
        {
            this.context = context;

        }

        public IActionResult ContactUs(string[] listing)
        {
            ViewBag.Id = listing[0];
            ViewBag.dealerName = listing[1];
            ViewBag.dealerUrl = listing[2];
            ViewBag.stockNumber = listing[3];
            ViewBag.year = listing[4];
            ViewBag.Make = listing[5];
            ViewBag.Model = listing[6];

            return View();
        }

        [HttpPost]
        public IActionResult RequestInfo(string[] listing)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Id = listing[0];
                ViewBag.dealerName = listing[1];
                ViewBag.dealerUrl = listing[2];
                ViewBag.stockNumber = listing[3];
                ViewBag.year = listing[4];
                ViewBag.Make = listing[5];
                ViewBag.Model = listing[6];

                Dealer dealer = new Dealer();
                dealer.ListingId = listing[0];
                dealer.DealerName = listing[1];
                dealer.DealerUrl = listing[2];
                dealer.StockNumber = listing[3];
                dealer.DateVisited = DateTime.Now;

                //context.Add(dealer);
                //context.SaveChanges();
                SendMail(listing[7], listing[8], listing[9], listing);

                return View(nameof(Success));
            }
            return View(nameof(Failure));
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Failure()
        {
            return View();
        }

        private void SendMail(string name, string mailTo, string mailMessage, string[] listing)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Classic Car Leads", "leads@classiccarleads.com"));
            message.To.Add(new MailboxAddress("Classic Car Leads", "leads@classiccarleads.com"));
            message.Bcc.Add(new MailboxAddress("Classic Car Leads", "tplwesco@aol.com"));
            message.Subject = (string.Format("New Sales Lead: {0} {1} {2}", listing[4], listing[5], listing[6]));
            message.Body = new TextPart("plain")
            {
                Text = mailMessage + "\r\n" +
                        "\r\nStock #:" + listing[3] + 
                        "\r\nDealer: " + listing[1] +
                        "\r\nDealer Url:" + listing[2] +
                        "\r\nYear: " + listing[4] +
                        "\r\nMake: " + listing[5] +
                        "\r\nModel: " + listing[6] +
                        "\r\nName: " + name +
                        "\r\nEmail: "+ mailTo +
                        "\r\n\r\n(ref # " + listing[0] + ")"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("mail.classiccarleads.com", 25, false);
                client.Authenticate("leads@classiccarleads.com", "451145_Gl");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}