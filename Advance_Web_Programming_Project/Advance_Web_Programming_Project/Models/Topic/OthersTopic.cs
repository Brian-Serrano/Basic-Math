using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class OthersTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public OthersTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1", "2"
            };

            title = new List<string>()
            {
                "Rounding Numbers", "Writing Numbers in Words", "Percentage"
            };

            description = new List<string>()
            {
                "Learn how to round different numbers.", "Learn how to write numbers into words.", "Learn about percentage."
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Round.html", pathToHtmlFile + "Write_Numbers_In_Words.html", pathToHtmlFile + "Percentage.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}