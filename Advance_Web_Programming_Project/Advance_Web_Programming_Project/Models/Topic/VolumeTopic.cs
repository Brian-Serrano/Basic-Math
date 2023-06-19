using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class VolumeTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public VolumeTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1"
            };

            title = new List<string>()
            {
                "Cube, Rectangular Prism and Pyramid", "Cylinder, Sphere and Cone"
            };

            description = new List<string>()
            {
                "Learn how to find the volume of cube, rectangular prism and pyramid.", "Learn how to find the volume of cylinder, sphere and cone."
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Volume_Without_PI.html", pathToHtmlFile + "Volume_With_PI.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}