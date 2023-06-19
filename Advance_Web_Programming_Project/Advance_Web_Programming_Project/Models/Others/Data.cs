using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Others
{
    public class Data
    {
        public string Username { get; set; }
        public int[] Levels { get; set; }
        public int[] CourseScore { get; set; }
        public List<List<int>> TopicsRead { get; set; }
        public int TotalScore { get; set; }
        public int Score { get; set; }
        public int[] CompletedAchievements { get; set; }
        public int[] CollectedCertificate { get; set; }
        public int QuizTaken { get; set; }
        public int QuizCompleted { get; set; }
        public int QuizFailed { get; set; }
    }
}