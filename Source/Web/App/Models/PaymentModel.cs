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
    public class PersonalModel : Validatable
    { 
        public string Name { get; set; } 
        public string Email { get; set; }

        public override void Validate(dynamic item)
        {
            if (this.ValidatesPresenceOf(item.Name, "Name is required"))
            { 
                if (((String)item.Name).Length > 5)
                {
                    Errors.Add("name is too long (less than 5 chars please!");
                }
            }

        }

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