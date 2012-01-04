﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
namespace MvcMovie.Controllers{
    public class UsersController : CruddyController {
        public UsersController(ITokenHandler tokenStore):base(tokenStore) {
            _table = new Users();
            ViewBag.Table = _table;
        }
         
    }
}

