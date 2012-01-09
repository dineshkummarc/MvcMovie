using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Payment
    {


        public string Number { get; set; }
         
        public string NameOnCard { get; set; }
        public string Ccv { get; set; }
        public string Issuer { get; set; } // ex Visa, Mastercard, American Express
        public string ExpirationDate { get; set; }

         
    }
     
}