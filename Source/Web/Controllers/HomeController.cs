using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Braintree;
using System.Text;
using System.Configuration;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }




        [HttpGet]
        public virtual ActionResult ThankYou()
        { 
            return View();
        }

        [HttpGet]
        public virtual ActionResult PersonalInfo()
        {
            this.FlashWarning("about to test the Braintree sandbox"); 
            var payment = new Payment { Number = "4111111111111111", ExpirationDate = "05/2012" }  ;
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PersonalInfo(FormCollection collection)
        { 
            var payment = new Payment
            {
                Number = collection["Card Number"],
                ExpirationDate = collection["Exp Date"]
            };
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = ConfigurationManager.AppSettings["BrainTree-MerchantId"],
                PublicKey = ConfigurationManager.AppSettings["BrainTree-PublicKey"],
                PrivateKey = ConfigurationManager.AppSettings["BrainTree-PrivateKey"]
            };

            var request = new TransactionRequest
            {
                Amount = 0.10M,
                CreditCard = new TransactionCreditCardRequest
                {
                    Number = payment.Number,        
                    ExpirationDate = payment.ExpirationDate   
                }
            }; 
            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                Transaction transaction = result.Target;
                this.FlashInfo("Success!: " + transaction.Id);
                return RedirectToAction("ThankYou");
            }
            else if (result.Transaction != null)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("Message:  {0}", result.Message);
                Transaction transaction = result.Transaction;
                sb.AppendFormat("Error processing transaction:");
                sb.AppendFormat("  Status:  {0}", transaction.Status);
                sb.AppendFormat("  Code:  {0}", transaction.ProcessorResponseCode);
                sb.AppendFormat("  Text:  {0}", transaction.ProcessorResponseText);
                this.FlashError(sb.ToString());
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendFormat("Message: {0}", result.Message);
                foreach (ValidationError error in result.Errors.DeepAll())
                {
                    sb.AppendFormat("Attribute: {0}", error.Attribute);
                    sb.AppendFormat("  Code: {0}", error.Code);
                    sb.AppendFormat("  Message: {0}", error.Message);
                }
                var errorMessage = sb.ToString();
                this.FlashError("Error");
            }
            return View(payment); 
        }



        [HttpGet]
        public ActionResult PaymentInfo()
        {
            this.FlashError("Error");
            //throw new Exception("asdfasdfasdf");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentInfo(FormCollection collection)
        {
            return View();
        }
    }
}
