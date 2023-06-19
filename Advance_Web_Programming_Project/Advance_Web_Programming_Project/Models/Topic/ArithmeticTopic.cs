using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class ArithmeticTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public ArithmeticTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1", "2", "3", "4"
            };

            title = new List<string>()
            {
                "Addition", "Subtraction", "Multiplication", "Division", "PEMDAS Rule"
            };

            description = new List<string>()
            {
                "Learn how to add numbers", "Learn how to subtract numbers", "Learn how to multiply numbers", "Learn how to divide numbers", "Know what operation you should evaluate first"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Arithmetic_Addition.html", pathToHtmlFile + "Arithmetic_Subtraction.html", pathToHtmlFile + "Arithmetic_Multiplication.html", pathToHtmlFile + "Arithmetic_Division.html", pathToHtmlFile + "Arithmetic_PEMDAS.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}