using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Models
{
    public class AvalonViewModel : Controller
    {
        public List<Website.Controllers.AvalonUser> avalonList { get; set; }
        public int intPlayers { get; set; }
        

        //public ActionResult Index()
        //{
        //    return View();
        //}


        public List<string> LastSelected { get; set; }
    }
}
