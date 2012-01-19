using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Massive; 
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{

    


    public class Users:DynamicModel {

        public Users() : base("ApplicationConnectionString", "Users", "ID", "UserName") { }
          
    }
}
