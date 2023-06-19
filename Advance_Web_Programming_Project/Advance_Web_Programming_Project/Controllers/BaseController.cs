using Advance_Web_Programming_Project.Models.Others;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Advance_Web_Programming_Project.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Courses = new List<Courses>()
            {
                new Courses
                {
                    Id = 0, Display = "Arithmetic Operations", TagLine = "From Addition to Division: Our Arithmetic Operation Course Has You Covered", Cost = 0
                },
                new Courses
                {
                    Id = 1, Display = "Other Math Fundamentals", TagLine = "Unlock the Power of Numbers: Mastering the Basics of Mathematics!", Cost = 0
                },
                new Courses
                {
                    Id = 2, Display = "Number Systems", TagLine = "Unlock the secrets of numbers with our comprehensive number system course.", Cost = 180
                },
                new Courses
                {
                    Id = 3, Display = "Probabilities", TagLine = "Discover the power of probability in our comprehensive course.", Cost = 260
                },
                new Courses
                {
                    Id = 4, Display = "Finding LCM and GCF", TagLine = "Get ahead in math with our LCM and GCF course: Join now and discover the possibilities!", Cost = 140
                },
                new Courses
                {
                    Id = 5, Display = "Perimeter", TagLine = "From polygons to circles: Our course covers all shapes and sizes.", Cost = 100
                },
                new Courses
                {
                    Id = 6, Display = "Area", TagLine = "Become a master of shapes with our comprehensive area course.", Cost = 160
                },
                new Courses
                {
                    Id = 7, Display = "Volume", TagLine = "Become a 3D math wizard with our comprehensive volume course.", Cost = 180
                },
                new Courses
                {
                    Id = 8, Display = "Fraction", TagLine = "Simplify fractions and make math easy with our expert-led course.", Cost = 120
                },
                new Courses
                {
                    Id = 9, Display = "Algebra", TagLine = "Simplify algebraic equations and excel in math: Join our algebra course today!", Cost = 300
                },
                new Courses
                {
                    Id = 10, Display = "Sets", TagLine = "Unlock the power of set theory with our expert-led course.", Cost = 200
                },
                new Courses
                {
                    Id = 11, Display = "Statistics", TagLine = "Master probability distribution and unlock the world of statistics: Join our course today!", Cost = 240
                }
            };

            ViewBag.Website = "Basic Math";

            if (Session["Data"] != null)
            {
                ViewBag.Data = Session["Data"] as Data;
            }
            else
            {
                filterContext.Result = RedirectToAction("Login", "Signup");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}