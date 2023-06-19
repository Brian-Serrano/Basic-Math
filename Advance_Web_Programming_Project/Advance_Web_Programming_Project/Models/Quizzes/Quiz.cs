using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Quiz
    {
        public List<int> Id { get; set; }
        public List<string> Input { get; set; }
        public List<List<string>> Components { get; set; }
    }
}