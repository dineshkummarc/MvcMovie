using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Braintree;
using System.Text;

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
        public virtual ActionResult PersonalInfo()
        {
            this.FlashInfo("Hi");
            return View( );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PersonalInfo(FormCollection collection)
        { 
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "the_merchant_id",
                PublicKey = "a_public_key",
                PrivateKey = "a_private_key"
            };

            var request = new TransactionRequest
            {
                Amount = 1000M,
                CreditCard = new TransactionCreditCardRequest
                {
                    Number = collection["Card Number"],       // "4111111111111111",
                    ExpirationDate = collection["Exp Date"]   // "05/2012"
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                Transaction transaction = result.Target;
                this.FlashInfo("Success!: " + transaction.Id);
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
                this.FlashInfo(sb.ToString());
            }
             
            return View( );


            //var model = _table.CreateFrom(collection);
            //try
            //{
            //    // TODO: Add update logic here
            //    _table.Update(model, id);
            //    return RedirectToAction("Index");
            //}
            //catch (Exception x)
            //{
            //    TempData["Error"] = "There was a problem editing this record";
            //    ModelState.AddModelError(string.Empty, x.Message);
            //    return View(model);
            //}
        }



        [HttpGet]
        public ActionResult PaymentInfo()
        {
            this.FlashInfo("hello");
            throw new Exception("asdfasdfasdf");
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
