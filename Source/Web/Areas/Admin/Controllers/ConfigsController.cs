using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.Models;
using Web.Controllers;

namespace MvcMovie.Areas.Admin.Controllers
{
    public class ConfigsController : CruddyController 
    {
        public ConfigsController(ITokenHandler tokenStore) : base(tokenStore)
        {
            _table = new Config();
            ViewBag.Table = _table;
        }

        protected override dynamic Get()
        { 
            var ret = HttpRuntime.Cache["Config"]; 
            if (ret == null)
            {
                ret = _table.All(); ;
                HttpRuntime.Cache["Config"]  = ret;
            }
            return ret; 
        }

        protected override dynamic Get(int id)
        {
            return _table.Get(ID: id);
        }




    }
}

