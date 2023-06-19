using Advance_Web_Programming_Project.Models.Others;
using Advance_Web_Programming_Project.Models.Quizzes;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Advance_Web_Programming_Project.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        public ActionResult Achievement()
        {
            Data data = Session["Data"] as Data;
            float[] progress = new float[66];
            AchievementManager.ProcessAchievements(data, progress);
            return View(new Achievement(progress));
        }

        public ActionResult BuyCourses() => View();

        public ActionResult ProfileStats() => View();

        public ActionResult Logout()
        {
            Session["Data"] = null;
            return RedirectToAction("Login", "Signup");
        }

        public ActionResult Buy(int Id)
        {
            Data data = Session["Data"] as Data;
            List<Courses> courses = (List<Courses>)ViewBag.Courses;

            if(data.Score >= courses[Id].Cost)
            {
                data.Score -= courses[Id].Cost;
                if (data.Levels[Id] == 0)
                    data.Levels[Id]++;

                List<CompletedAchievement> achievements = ComponentGetter.GetAchievement(new Achievement(), AchievementManager.ProcessAchievements(data, new float[66]));

                // Save Bought Courses to Data

                Database.SaveData(data, Database.GetUserIdByUsername(data.Username));

                Session["Data"] = data;

                return Json(new { success = true, achievement = achievements });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public ActionResult Collections() => View(new Achievement());

        public ActionResult Test() => View();

        [HttpPost]
        public ActionResult Test(Test test)
        {
            TempData["Test"] = test;

            return RedirectToAction("TestQuiz");
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult TestQuiz()
        {
            Test test = TempData["Test"] as Test;
            if (test == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int[] levels = new int[] { 1, 6, 11, 21, 51, 101 };
            List<int> courses = new List<int>();
            for(int i = 0; i < test.Topics.Length; i++)
            {
                if (test.Topics[i])
                {
                    courses.Add(i);
                }
            }

            Random random = new Random();
            Quiz quiz = new Quiz();
            List<List<string>> components = new List<List<string>>();
            List<int> courseId = new List<int>();
            for(int i = 0; i < test.Items; i++)
            {
                int course = courses[random.Next(0, courses.Count)];
                components.Add(ComponentGetter.GetQuiz(course, random, levels[test.Difficulty - 1]));
                courseId.Add(course);
            }
            quiz.Components = components;
            quiz.Id = courseId;

            return View(quiz);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult TestQuiz(Quiz quiz)
        {
            TempData["Quiz"] = quiz;

            // Save quiz to Data

            Data data = Session["Data"] as Data;

            int sum = 0;
            for (int i = 0; i < quiz.Input.Count; i++)
            {
                if (AnswerChecker.CheckAnswer(quiz.Input[i], quiz.Components[i][2], quiz.Id[i]))
                {
                    sum++;
                }
            }

            data.TotalScore += sum;
            data.Score += sum;
            data.QuizTaken++;
            if (sum >= Math.Floor(quiz.Input.Count * 0.75))
            {
                TempData["Status"] = "Passed";
                data.QuizCompleted++;
            }
            else
            {
                TempData["Status"] = "Failed";
                data.QuizFailed++;
            }

            TempData["Achievement"] = AchievementManager.ProcessAchievements(data, new float[66]);

            Database.SaveData(data, Database.GetUserIdByUsername(data.Username));

            Session["Data"] = data;

            return RedirectToAction("TestQuizSubmit");
        }

        public ActionResult TestQuizSubmit()
        {
            Quiz quiz = TempData["Quiz"] as Quiz;
            if (quiz == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<int> achievement = TempData["Achievement"] as List<int>;
            ViewBag.Status = TempData["Status"].ToString();
            ViewBag.Achievement = ComponentGetter.GetAchievement(new Achievement(), achievement);
            return View(quiz);
        }
    }
}