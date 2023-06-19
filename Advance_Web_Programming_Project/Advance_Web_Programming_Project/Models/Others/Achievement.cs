using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Others
{
    public class Achievement
    {
        private List<string> title;
        private List<string> description;
        private List<string> imagePath;
        private List<string> textImage;
        private float[] progress;

        public Achievement()
        {
            progress = new float[66];
            Init();
        }

        public Achievement(float[] progress)
        {
            this.progress = progress;
            Init();
        }

        public void Init()
        {
            string badge1 = "~/Assets/badge_1.png";
            string badge2 = "~/Assets/badge_2.png";
            string badge3 = "~/Assets/badge_3.png";
            string badge4 = "~/Assets/badge_4.png";

            title = new List<string>()
            {
                "Novice Adder",
                "Skilled Calculator",
                "Math Whiz",
                "Arithmetic Master",
                "Number Navigator",
                "Mathematical Explorer",
                "Problem Solver Extraordinaire",
                "Mathematics Maestro",
                "Number Explorer",
                "Number Detective",
                "Number Expert",
                "Number Guru",
                "Probability Beginner",
                "Probability Enthusiast",
                "Probability Master",
                "Probability Prodigy",
                "LCM and GCF Novice",
                "LCM and GCF Apprentice",
                "LCM and GCF Expert",
                "LCM and GCF Champion",
                "Perimeter Explorer",
                "Perimeter Apprentice",
                "Perimeter Expert",
                "Perimeter Master",
                "Area Discoverer",
                "Area Enthusiast",
                "Area Expert",
                "Area Maestro",
                "Volume Rookie",
                "Volume Enthusiast",
                "Volume Expert",
                "Volume Maestro",
                "Fraction Novice",
                "Fraction Apprentice",
                "Fraction Expert",
                "Fraction Master",
                "Algebra Rookie",
                "Algebra Apprentice",
                "Algebra Expert",
                "Algebra Master",
                "Sets Novice",
                "Sets Apprentice",
                "Sets Expert",
                "Sets Master",
                "Deviation Beginner",
                "Deviation Enthusiast",
                "Deviation Expert",
                "Deviation Master",
                "Course Shopper",
                "Course Collector",
                "Course Connoisseur",
                "Certificate Beginner",
                "Certificate Collector",
                "Certificate Champion",
                "Quiz Taker",
                "Quiz Enthusiast",
                "Quiz Master",
                "Quiz Legend",
                "Quiz Apprentice",
                "Quiz Expert",
                "Quiz Champion",
                "Quiz Maestro",
                "Quiz Fumbler",
                "Quiz Struggler",
                "Quiz Challenger",
                "Quiz Survivor"
            };

            description = new List<string>()
            {
                "Complete 2 levels in arithmetic operations course",
                "Complete 5 levels in arithmetic operations course",
                "Complete 10 levels in arithmetic operations course",
                "Complete 50 levels in arithmetic operations course",
                "Complete 2 levels in other math fundamentals course",
                "Complete 5 levels in other math fundamentals course",
                "Complete 10 levels in other math fundamentals course",
                "Complete 50 levels in other math fundamentals course",
                "Complete 2 levels in number systems course",
                "Complete 5 levels in number systems course",
                "Complete 10 levels in number systems course",
                "Complete 50 levels in number systems course",
                "Complete 2 levels in probabilities course",
                "Complete 5 levels in probabilities course",
                "Complete 10 levels in probabilities course",
                "Complete 50 levels in probabilities course",
                "Complete 2 levels in finding LCM and GCF course",
                "Complete 5 levels in finding LCM and GCF course",
                "Complete 10 levels in finding LCM and GCF course",
                "Complete 50 levels in finding LCM and GCF course",
                "Complete 2 levels in perimeter course",
                "Complete 5 levels in perimeter course",
                "Complete 10 levels in perimeter course",
                "Complete 50 levels in perimeter course",
                "Complete 2 levels in area course",
                "Complete 5 levels in area course",
                "Complete 10 levels in area course",
                "Complete 50 levels in area course",
                "Complete 2 levels in volume course",
                "Complete 5 levels in volume course",
                "Complete 10 levels in volume course",
                "Complete 50 levels in volume course",
                "Complete 2 levels in fraction course",
                "Complete 5 levels in fraction course",
                "Complete 10 levels in fraction course",
                "Complete 50 levels in fraction course",
                "Complete 2 levels in algebra course",
                "Complete 5 levels in algebra course",
                "Complete 10 levels in algebra course",
                "Complete 50 levels in algebra course",
                "Complete 2 levels in sets course",
                "Complete 5 levels in sets course",
                "Complete 10 levels in sets course",
                "Complete 50 levels in sets course",
                "Complete 2 levels in standard deviation course",
                "Complete 5 levels in standard deviation course",
                "Complete 10 levels in standard deviation course",
                "Complete 50 levels in standard deviation course",
                "Buy 2 courses",
                "Buy 5 courses",
                "Buy all courses",
                "Collect 2 certificates",
                "Collect 5 certificates",
                "Collect all certificates",
                "Take 20 quizzes",
                "Take 50 quizzes",
                "Take 100 quizzes",
                "Take 200 quizzes",
                "Complete 15 quizzes",
                "Complete 30 quizzes",
                "Complete 50 quizzes",
                "Complete 100 quizzes",
                "Fail on 5 quizzes",
                "Fail on 10 quizzes",
                "Fail on 15 quizzes",
                "Fail on 30 quizzes"
            };

            imagePath = new List<string>()
            {
                badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge2, badge3, badge4, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4, badge1, badge2, badge3, badge4
            };

            textImage = new List<string>()
            {
                "Arithmetic Operations", "Arithmetic Operations", "Arithmetic Operations", "Arithmetic Operations", "Rounding Numbers", "Rounding Numbers", "Rounding Numbers", "Rounding Numbers", "Number Systems", "Number Systems", "Number Systems", "Number Systems", "Probabilities", "Probabilities", "Probabilities", "Probabilities", "LCM and GCF", "LCM and GCF", "LCM and GCF", "LCM and GCF", "Perimeter", "Perimeter", "Perimeter", "Perimeter", "Area", "Area", "Area", "Area", "Volume", "Volume", "Volume", "Volume", "Fraction", "Fraction", "Fraction", "Fraction", "Algebra", "Algebra", "Algebra", "Algebra", "Sets", "Sets", "Sets", "Sets", "Standard Deviation", "Standard Deviation", "Standard Deviation", "Standard Deviation", "Course Purchase", "Course Purchase", "Course Purchase", "Certificate Collection", "Certificate Collection", "Certificate Collection", "Quiz Completion", "Quiz Completion", "Quiz Completion","Quiz Completion", "Quiz Success", "Quiz Success", "Quiz Success", "Quiz Success", "Quiz Failure", "Quiz Failure", "Quiz Failure", "Quiz Failure"
            };
        }

        public List<string> GetTitle() => title;

        public List<string> GetDescription() => description;

        public List<string> GetImagePath() => imagePath;

        public List<string> GetImageText() => textImage;

        public float[] GetProgress() => progress;
    }
}