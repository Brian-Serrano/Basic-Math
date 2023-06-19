using Advance_Web_Programming_Project.Models.Others;
using Advance_Web_Programming_Project.Models.Quizzes;
using Advance_Web_Programming_Project.Models.Topic;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Advance_Web_Programming_Project.Controllers
{
    public class CourseController : BaseController
    {
        public ActionResult Dashboard(int Id)
        {
            if (ViewBag.Data.Levels[Id] == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(Id);
        }

        public ActionResult StartTopic(int Id)
        {
            if (ViewBag.Data.Levels[Id] == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            Topic topic = new Topic
            {
                Id = Id,
                TopicId = ComponentGetter.GetTopic(Id, 0),
                TopicTitle = ComponentGetter.GetTopic(Id, 1),
                TopicDescription = ComponentGetter.GetTopic(Id, 2)
            };
            return View(topic);
        }

        public ActionResult Topic(int Id, int Topics)
        {
            if (ViewBag.Data.Levels[Id] == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            TopicDescription topicDescription = new TopicDescription
            {
                Id = Id,
                TopicId = Topics,
                TopicAmount = ComponentGetter.GetTopic(Id, 0).Count,
                TopicTitle = ComponentGetter.GetTopic(Id, 1)[Topics],
                TopicPath = ComponentGetter.GetTopic(Id, 3)[Topics]
            };
            return View(topicDescription);
        }

        public ActionResult TrackTime(int timeSpent, int topicId, int lessonId)
        {
            if(timeSpent >= 30000)
            {
                // Save Topics Read to Data

                Data data = Session["Data"] as Data;

                data.TopicsRead[topicId][lessonId] = 1;

                Database.SaveData(data, Database.GetUserIdByUsername(data.Username));

                Session["Data"] = data;
            }

            return Json(new { success = true });
        }

        public ActionResult StartQuiz(int Id)
        {
            if (ViewBag.Data.Levels[Id] == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(Id);
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Quiz(int Id)
        {
            if (ViewBag.Data.Levels[Id] == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            Data data = Session["Data"] as Data;
            Quiz quiz = new Quiz();
            List<List<string>> components = new List<List<string>>();
            List<int> courseId = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                components.Add(ComponentGetter.GetQuiz(Id, random, data.Levels[Id]));
                courseId.Add(Id);
            }
            quiz.Components = components;
            quiz.Id = courseId;
            return View(quiz);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Quiz(Quiz quiz)
        {
            TempData["Quiz"] = quiz;

            // Save Quiz to Data

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
                data.Levels[quiz.Id[0]]++;
                data.CourseScore[quiz.Id[0]] += sum;
                if (data.Levels[quiz.Id[0]] >= 20 && data.CollectedCertificate[quiz.Id[0]] == 0)
                {
                    data.CollectedCertificate[quiz.Id[0]] = 1;
                }
            }
            else
            {
                data.CourseScore[quiz.Id[0]] += sum;
                TempData["Status"] = "Failed";
                data.QuizFailed++;
            }

            TempData["Achievement"] = AchievementManager.ProcessAchievements(data, new float[66]);

            Database.SaveData(data, Database.GetUserIdByUsername(data.Username));

            Session["Data"] = data;

            return RedirectToAction("QuizSubmit", new { id = quiz.Id[0] });
        }

        public ActionResult QuizSubmit(int Id)
        {
            Quiz quiz = TempData["Quiz"] as Quiz;
            if (quiz == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ViewBag.Data.Levels[quiz.Id[0]] == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            List<int> achievement = TempData["Achievement"] as List<int>;
            ViewBag.Status = TempData["Status"].ToString();
            ViewBag.Achievement = ComponentGetter.GetAchievement(new Achievement(), achievement);
            return View(quiz);
        }

        public ActionResult Leaderboard(int Id)
        {
            string[] tableColumnNames = new string[]
            {
                "AriLevel", "RouLevel", "NumLevel", "ProLevel", "LcmLevel", "PerLevel", "AreLevel", "VolLevel", "FraLevel", "FacLevel", "SetLevel", "StaLevel"
            };
            if (ViewBag.Data.Levels[Id] == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            Data data = Session["Data"] as Data;

            if (Database.SetLeaderboardScore(tableColumnNames[Id], data.Levels[Id], Database.GetUserIdByUsername(data.Username)))
            {
                LeaderboardUser users = Database.GetLeaderboardUsers(tableColumnNames[Id], Id);
                return View(users);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}