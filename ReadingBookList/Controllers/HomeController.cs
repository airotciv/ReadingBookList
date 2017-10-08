using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadingBookList.Controllers
{
    /// <summary>
    /// HomeController provides the  control for the home page
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index - Returns to the Home index or Books Index
        /// </summary>
        /// <returns>typeof(View)</returns>
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Books");
            }
            return View();
        }

        /// <summary>
        /// About - Returns to the About page
        /// </summary>
        /// <returns>typeof(View)</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        /// <summary>
        /// Contact - Returns to the Contact page
        /// </summary>
        /// <returns>typeof(View)</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}