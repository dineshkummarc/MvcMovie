using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace MvcMovie.App.Models
{
    public class Customer : DynamicModel
    {

        public Customer()
            : base("ApplicationConnectionString", "Customer", "ID")
        {
            //Test check-ins
        }

    }
}