using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace MvcMovie.Models
{
    public class Log : DynamicModel
    {
        public Log()
            : base("ApplicationConnectionString")
        {
            //Test check-ins
        }
    }

}