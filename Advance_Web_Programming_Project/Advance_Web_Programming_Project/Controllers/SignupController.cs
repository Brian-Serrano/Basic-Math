using Advance_Web_Programming_Project.Models.Others;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Advance_Web_Programming_Project.Controllers
{
    public class SignupController : Controller
    {
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Login()
        {
            if (Session["Data"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Register()
        {
            if (Session["Data"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser login)
        {
            if(Database.AuthenticateUser(login.Username, Database.HashPassword(login.Password)))
            {
                Session["data"] = Database.LoadData(Database.GetUserIdByUsername(login.Username));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Cannot Authenticate User";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Register(RegisterUser register)
        {
            if (Database.IsEmailExists(register.Email) || Database.IsUsernameExists(register.Username))
            {
                ViewBag.Message = "Username or email already exists";
                return View();
            }
            else
            {
                if (Database.SaveUser(register.Username, register.Email, Database.HashPassword(register.Password)))
                {
                    Data data = new Data
                    {
                        Username = register.Username,
                        Levels = new int[]
                        {
                            1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                        },
                        CourseScore = new int[]
                        {
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                        },
                        TopicsRead = new List<List<int>>()
                        {
                            new List<int>(){ 0, 0, 0, 0, 0 },
                            new List<int>(){ 0, 0, 0 },
                            new List<int>(){ 0, 0, 0, 0, 0 },
                            new List<int>(){ 0, 0, 0, 0, 0, 0 },
                            new List<int>(){ 0, 0 },
                            new List<int>(){ 0, 0, 0, 0 },
                            new List<int>(){ 0, 0, 0, 0 },
                            new List<int>(){ 0, 0 },
                            new List<int>(){ 0, 0 },
                            new List<int>(){ 0, 0, 0, 0, 0, 0, 0 },
                            new List<int>(){ 0, 0 },
                            new List<int>(){ 0, 0, 0, 0, 0, 0, 0, 0 }

                        },
                        TotalScore = 0,
                        Score = 0,
                        CompletedAchievements = new int[]
                        {
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                        },
                        CollectedCertificate = new int[]
                        {
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                        },
                        QuizTaken = 0,
                        QuizCompleted = 0,
                        QuizFailed = 0
                    };
                    int id = Database.GetUserIdByUsername(register.Username);
                    Database.SaveData(data, id);
                    Session["data"] = Database.LoadData(id);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Cannot Register User";
                    return View();
                }
            }
        }
    }
}