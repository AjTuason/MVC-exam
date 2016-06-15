using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlatPlanet.DataLayer;

namespace FlatPlanet.Controllers
{
    public class HomeController : Controller
    {
        public int lastctr;

        public ActionResult Index()
        {
            ViewBag.Message = string.Empty;

            FlatPlanet.Models.FlatPlanet result = new Models.FlatPlanet();

            //READ LAST DATA FROM DATABASE
            lastctr = DL_FlatPlanet.ReadData();
            result.Counter = lastctr.ToString();

            if (lastctr < 10)
            {                               
                lastctr++;

                //INSERT TO DATABASE
                bool successadd =  DL_FlatPlanet.AddData(lastctr);                  
            }
            else 
            {
                ViewBag.Message = string.Format("EXCEEDS LIMIT! Current Ctr{0}", lastctr.ToString());       
            }

            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}
