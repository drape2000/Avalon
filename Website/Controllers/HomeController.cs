using DataEntryApplication;
using Avalon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteWindageFormula;

namespace Website.Controllers
{
    public class User
    {
        public string Name { get; set; }
        public int? Total { get; set; }
        public double? Average { get; set; }
        //string name { get; set; }
        public string userName { get; set; }
        public string daysRead { get; set; }
        public DateTime date { get; set; }

    }

    public class BreadList
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ParentEmail { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Thu";
                       
            return View(GetViewModel());
        }

        public ActionResult Assignments()
        {
            ViewBag.Message = "Weekly Assignment";
            return View("Assignments",GetAssignmentsModel());
        }

        public ActionResult Apps()
        {
            return View("apps");
        }

        public ActionResult AssignmentsAction(string BreadList, string name1, string name2)
        {
            string name = User.Identity.Name;
            name = name.ToLower();

            if (name != "moroni" && name != "thummim" && name != "ammon")
            {
                ViewBag.Message = "You are not an Admin";

                return View("Assignments"); 
            }

            if (BreadList != "")
            {
                DataEntryApplication.Assignments.InsertBread(BreadList);

                ViewBag.Message = "Bread Entered";
                return View("Assignments", GetAssignmentsModel());
            }
            if (name1 != "" && name2 != "")
            {
                DataEntryApplication.Assignments.InsertUshers(name1, name2);

                ViewBag.Message = "Usher/s entered";
                return View("Assignments", GetAssignmentsModel());
            }else             


            ViewBag.Message = "please enter both ushers";
            return View("Assignments");
        }

        private static Website.Models.AssignmentsModel GetAssignmentsModel()
        {
            //var list = Program.ReturnBreadList.ConvertAll(x => new BreadList
            //{
            //    Name = x.Name,
            //});
 

            DataEntryApplication.Assignments.Bread bread = DataEntryApplication.Assignments.ReturnBread();
            string name1 = DataEntryApplication.Assignments.ReturnUsher1();
            string name2 = DataEntryApplication.Assignments.ReturnUsher2();

            Website.Models.AssignmentsModel model = new Website.Models.AssignmentsModel();
            model.bread = bread.Name;
            model.insertDate = bread.InsertDate;
            model.name1 = name1;
            model.name2 = name2;

            return model;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SubmitResults(string daysRead, string userName)
        {
            int daysReadInt;
            string name;

            if (User.Identity.Name == "moroni" || User.Identity.Name == "Moroni")
            {
                 name = userName;
            }
            else
            {
                 name = User.Identity.Name;
            }

           // DateTime? date = Program.ReturnTwoDayValue(name);
            
            if (name == "")
            {
                ViewBag.Message = "Please log in!";
                ViewBag.Color = "#ff3232";
                
                return View("Index", GetViewModel());
            }

            DateTime? date = Program.ReturnTwoDayValue(name);

            if (daysRead == "0" || daysRead == "1" || daysRead == "2" || daysRead == "3" || daysRead == "4" || daysRead == "5" || daysRead == "6" || daysRead == "7")
            {
                daysReadInt = int.Parse(daysRead);
            }
            else
            {
                ViewBag.Message = "Please Enter a number between 0 - 7!";
                ViewBag.Color = "#ff3232";

                return View("Index", GetViewModel());

            }

            //if (daysReadInt >= 0 && daysReadInt <= 7)
            //{
            //}
            //else
            //{
            //    ViewBag.Message = "Please Enter a number between 0 and 7!";
            //    ViewBag.Color = "#f00";

            //    return View("Index", GetViewModel());
 
            //}

            DateTime now = DateTime.Now;

            if ((now.DayOfWeek == DayOfWeek.Saturday) || (now.DayOfWeek == DayOfWeek.Sunday))
            {
            }else
            {
                ViewBag.Message = "Numbers only entered on Saturday and Sunday";
                ViewBag.Color = "#ff3232";

                return View("Index", GetViewModel());
            }
           
            if (date < DateTime.Now.AddHours(-48) || date == null)
            {
                Program.InsertDaysRead(name, daysReadInt);

                ViewBag.Message = "Number entered successfully";
                ViewBag.Color = "#003300";

                return View("Index", GetViewModel()); 
            }else

            ViewBag.Message = "Sorry you have already entered a number for this week!";
            ViewBag.Color = "#ff3232";

            return View("Index", GetViewModel());
        }

      
        private static Website.Models.IndexViewModel GetViewModel()
        {
            var list = Program.ReturnAllUsers().ConvertAll(x => new User
            {
                Name = x.Name,
                Total = x.Total,
                Average = x.Average,
                daysRead = x.DaysRead.ToString(),
              
            });

            double average = Program.GetAllUsersAverageDaysRead();

            Website.Models.IndexViewModel model = new Website.Models.IndexViewModel();
            model.myList = list;
            model.average = average;

            return model;
        }

        private static Website.Models.IndexViewModel GetWeeklyNumbers()
        {
            var list = Program.DaysReadThisWeek().ConvertAll(x => new User
            {
                userName = x.userName,
                daysRead = x.daysRead.ToString(),
                date = x.date,

            });

          //  double average = Program.GetAllUsersAverageDaysRead();

            Website.Models.IndexViewModel model = new Website.Models.IndexViewModel();
            model.myList = list;
          //  model.average = average;

            return model;
 
        }

       

       

        public ActionResult ErrorPage()
        {
            return View();
        }

        public ActionResult SuccessPage()
        {
            return View();
        }

        public ActionResult DaysReadThisWeekPage()
        {


            return View("DaysReadPage", GetWeeklyNumbers());
        }

    }
}
