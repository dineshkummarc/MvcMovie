using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace MvcMovie.App.Models
{
    /**/
    public class Customer : DynamicModel
    {

        public Customer()
            : base("ApplicationConnectionString", "Customer", "Id")
        {
            //Test check-ins
        }

    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string IpAddress { get; set; }
        public string Session { get; set; }
        public System.DateTime UpdatedAt { get; set; }

    }

}