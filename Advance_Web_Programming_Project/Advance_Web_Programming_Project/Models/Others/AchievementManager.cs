using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Others
{
    public static class AchievementManager
    {
        public static List<int> ProcessAchievements(Data data, float[] achievementProgress)
        {
            ProcessLevels(data, achievementProgress, 0, 2, 0);
            ProcessLevels(data, achievementProgress, 0, 5, 1);
            ProcessLevels(data, achievementProgress, 0, 10, 2);
            ProcessLevels(data, achievementProgress, 0, 50, 3);
            ProcessLevels(data, achievementProgress, 1, 2, 4);
            ProcessLevels(data, achievementProgress, 1, 5, 5);
            ProcessLevels(data, achievementProgress, 1, 10, 6);
            ProcessLevels(data, achievementProgress, 1, 50, 7);
            ProcessLevels(data, achievementProgress, 2, 2, 8);
            ProcessLevels(data, achievementProgress, 2, 5, 9);
            ProcessLevels(data, achievementProgress, 2, 10, 10);
            ProcessLevels(data, achievementProgress, 2, 50, 11);
            ProcessLevels(data, achievementProgress, 3, 2, 12);
            ProcessLevels(data, achievementProgress, 3, 5, 13);
            ProcessLevels(data, achievementProgress, 3, 10, 14);
            ProcessLevels(data, achievementProgress, 3, 50, 15);
            ProcessLevels(data, achievementProgress, 4, 2, 16);
            ProcessLevels(data, achievementProgress, 4, 5, 17);
            ProcessLevels(data, achievementProgress, 4, 10, 18);
            ProcessLevels(data, achievementProgress, 4, 50, 19);
            ProcessLevels(data, achievementProgress, 5, 2, 20);
            ProcessLevels(data, achievementProgress, 5, 5, 21);
            ProcessLevels(data, achievementProgress, 5, 10, 22);
            ProcessLevels(data, achievementProgress, 5, 50, 23);
            ProcessLevels(data, achievementProgress, 6, 2, 24);
            ProcessLevels(data, achievementProgress, 6, 5, 25);
            ProcessLevels(data, achievementProgress, 6, 10, 26);
            ProcessLevels(data, achievementProgress, 6, 50, 27);
            ProcessLevels(data, achievementProgress, 7, 2, 28);
            ProcessLevels(data, achievementProgress, 7, 5, 29);
            ProcessLevels(data, achievementProgress, 7, 10, 30);
            ProcessLevels(data, achievementProgress, 7, 50, 31);
            ProcessLevels(data, achievementProgress, 8, 2, 32);
            ProcessLevels(data, achievementProgress, 8, 5, 33);
            ProcessLevels(data, achievementProgress, 8, 10, 34);
            ProcessLevels(data, achievementProgress, 8, 50, 35);
            ProcessLevels(data, achievementProgress, 9, 2, 36);
            ProcessLevels(data, achievementProgress, 9, 5, 37);
            ProcessLevels(data, achievementProgress, 9, 10, 38);
            ProcessLevels(data, achievementProgress, 9, 50, 39);
            ProcessLevels(data, achievementProgress, 10, 2, 40);
            ProcessLevels(data, achievementProgress, 10, 5, 41);
            ProcessLevels(data, achievementProgress, 10, 10, 42);
            ProcessLevels(data, achievementProgress, 10, 50, 43);
            ProcessLevels(data, achievementProgress, 11, 2, 44);
            ProcessLevels(data, achievementProgress, 11, 5, 45);
            ProcessLevels(data, achievementProgress, 11, 10, 46);
            ProcessLevels(data, achievementProgress, 11, 50, 47);
            ProcessCourseBought(data, achievementProgress, 2, 48);
            ProcessCourseBought(data, achievementProgress, 5, 49);
            ProcessCourseBought(data, achievementProgress, 10, 50);
            ProcessCertificates(data, achievementProgress, 2, 51);
            ProcessCertificates(data, achievementProgress, 5, 52);
            ProcessCertificates(data, achievementProgress, 12, 53);
            ProcessTakenQuiz(data, achievementProgress, 20, 54);
            ProcessTakenQuiz(data, achievementProgress, 50, 55);
            ProcessTakenQuiz(data, achievementProgress, 100, 56);
            ProcessTakenQuiz(data, achievementProgress, 200, 57);
            ProcessCompletedQuiz(data, achievementProgress, 15, 58);
            ProcessCompletedQuiz(data, achievementProgress, 30, 59);
            ProcessCompletedQuiz(data, achievementProgress, 50, 60);
            ProcessCompletedQuiz(data, achievementProgress, 100, 61);
            ProcessFailedQuiz(data, achievementProgress, 5, 62);
            ProcessFailedQuiz(data, achievementProgress, 10, 63);
            ProcessFailedQuiz(data, achievementProgress, 15, 64);
            ProcessFailedQuiz(data, achievementProgress, 30, 65);

            return CheckCompletedAchievement(data, achievementProgress);
        }

        public static void ProcessLevels(Data data, float[] achievementProgress, int courseId, int level, int achievementId)
        {
            int num = data.Levels[courseId] == 0 ? 0 : 1;
            achievementProgress[achievementId] = ((float)(data.Levels[courseId] - num) / level) * 100;
        }

        public static void ProcessCourseBought(Data data, float[] achievementProgress, int bought, int achievementId)
        {
            achievementProgress[achievementId] = ((float)(Array.FindAll(data.Levels, element => element != 0).Length - 2) / bought) * 100;
        }

        public static void ProcessCertificates(Data data, float[] achievementProgress, int collected, int achievementId)
        {
            achievementProgress[achievementId] = ((float)Array.FindAll(data.CollectedCertificate, element => element == 1).Length / collected) * 100;
        }

        public static void ProcessTakenQuiz(Data data, float[] achievementProgress, int amount, int achievementId)
        {
            achievementProgress[achievementId] = ((float)data.QuizTaken / amount) * 100;
        }

        public static void ProcessCompletedQuiz(Data data, float[] achievementProgress, int amount, int achievementId)
        {
            achievementProgress[achievementId] = ((float)data.QuizCompleted / amount) * 100;
        }

        public static void ProcessFailedQuiz(Data data, float[] achievementProgress, int amount, int achievementId)
        {
            achievementProgress[achievementId] = ((float)data.QuizFailed / amount) * 100;
        }

        public static List<int> CheckCompletedAchievement(Data data, float[] achievementProgress)
        {
            List<int> completedAchievementId = new List<int>();
            for(int i = 0; i < achievementProgress.Length; i++)
            {
                if (achievementProgress[i] >= 100 && data.CompletedAchievements[i] == 0)
                {
                    data.CompletedAchievements[i] = 1;
                    completedAchievementId.Add(i);
                }
            }
            return completedAchievementId;
        }
    }
}