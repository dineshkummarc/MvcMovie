using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Models;

namespace MvcMovie.Models
{

    public class PaymentModel
    {
        [Required]
        public string Number { get; set; }
         
        public string NameOnCard { get; set; }
        public string Ccv { get; set; }
        public string Issuer { get; set; } // ex Visa, Mastercard, American Express
        public string ExpirationDate { get; set; }

         
    }

     
    //public class BaseClass
    //{
    //    public IList<string> Errors = new List<string>();
    //    public bool IsValid()
    //    {
    //        Errors.Clear();
    //        Validate(this);
    //        return Errors.Count == 0;
    //    }

    //    public virtual void Validate(dynamic item) { } 

    //    //validation methods
    //    public virtual bool ValidatesPresenceOf(object value, string message = "Required")
    //    {
    //        if (value == null)
    //            Errors.Add(message);
    //        if (String.IsNullOrEmpty(value.ToString()))
    //        {
    //            Errors.Add(message);
    //            return false;
    //        }
    //        return true;
    //    } 
    //}

     
}