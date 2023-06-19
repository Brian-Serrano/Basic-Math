using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class NumberSystemTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public NumberSystemTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1", "2", "3", "4"
            };

            title = new List<string>()
            {
                "Introduction", "Decimal", "Binary", "Octal", "Hexadecimal"
            };

            description = new List<string>()
            {
                "Read the introduction of number systems", "Learn to convert from decimal to other base system", "Learn to convert from binary to other base system", "Learn to convert from octal to other base system", "Learn to convert from hexadecimal to other base system"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Number_System_Intro.html", pathToHtmlFile + "Number_System_Decimal.html", pathToHtmlFile + "Number_System_Binary.html", pathToHtmlFile + "Number_System_Octal.html", pathToHtmlFile + "Number_System_Hexadecimal.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}