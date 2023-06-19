using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class AreaTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public AreaTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1", "2", "3"
            };

            title = new List<string>()
            {
                "Four Sided Shapes", "Three Sided Shapes", "More Sided Shapes", "Circle"
            };

            description = new List<string>()
            {
                "Learn how to find the area of four sided shapes", "Learn how to find the area of three sided shapes", "Learn how to find area of regular pentagon, hexagon and octagon", "Learn how to find the area of a circle"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Area_Four_Sides.html", pathToHtmlFile + "Area_Three_Sides.html", pathToHtmlFile + "Area_More_Sides.html", pathToHtmlFile + "Area_Circle.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}