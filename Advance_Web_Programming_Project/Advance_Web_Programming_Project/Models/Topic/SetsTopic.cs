using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class SetsTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public SetsTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1"
            };

            title = new List<string>()
            {
                "Methods to Describe Sets", "Set Operations"
            };

            description = new List<string>()
            {
                "Learn the three methods that describe sets", "Learn the six different operations of sets"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Sets_Methods_To_Describe.html", pathToHtmlFile + "Sets_Operations.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}