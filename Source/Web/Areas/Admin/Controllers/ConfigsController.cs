using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Web.Models;
using Web.Infrastructure;
using MvcMovie.Models;
using Web.Controllers;
using System.Text;

namespace MvcMovie.Areas.Admin.Controllers
{
    public class ConfigsController : CruddyController 
    {
        public ConfigsController(ITokenHandler tokenStore) : base(tokenStore)
        {
            _table = new Config();
            ViewBag.Table = _table;
        }

          
        public ActionResult About()
        {
            return View();
        }



        protected override dynamic Get()
        { 
            var ret = HttpRuntime.Cache["Config"]; 
            if (ret == null)
            {
                ret = _table.All();
                HttpRuntime.Cache.Add("Config", ret, null, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration,
                                      CacheItemPriority.Low,
                                      RemovedCallback);
            }
            return ret; 
        }

        

        public static void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            var s = string.Format("Key: {0}   Object: {1}    Reason: {2}     ", k, v.ToString(), r); 

        }


        protected override dynamic Get(int id)
        {
            return _table.Get(ID: id);
        }




    }
}

