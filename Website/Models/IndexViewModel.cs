using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class IndexViewModel
    {
      public List<Website.Controllers.User> myList { get; set; }
      public double average { get; set; }
      public List<Website.Controllers.BreadList> breadList { get; set; }
    }
}