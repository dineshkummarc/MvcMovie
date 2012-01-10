using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace MvcMovie.Models
{
    public class Config : DynamicModel
    {
        public Config()
            : base("ApplicationConnectionString")
        {
            //Test check-ins
        }
    }

}