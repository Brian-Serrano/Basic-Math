using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class LcmAndGcfTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public LcmAndGcfTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1"
            };

            title = new List<string>()
            {
                "Greatest Common Factor", "Least Common Multiple"
            };

            description = new List<string>()
            {
                "Learn how to find the greatest common factors of two or more numbers", "Learn how to find the least common multiple of two or more numbers"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Greatest_Common_Factor.html", pathToHtmlFile + "Least_Common_Multiple.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}