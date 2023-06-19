using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class ProbabilityTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public ProbabilityTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1", "2", "3", "4", "5"
            };

            title = new List<string>()
            {
                "Introduction", "Basic Properties", "Addition Rule", "Multiplication Rule", "Permutation", "Combination"
            };

            description = new List<string>()
            {
                "Read the introduction about probabilities", "Learn the basic properties of probabilities", "Learn the addition rule of probabilities", "Learn the multiplication rule of probabilities", "Learn about permutations in probabilities", "Learn about combinations in probabilities"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Probabilities_Intro.html", pathToHtmlFile + "Probabilities_Properties.html", pathToHtmlFile + "Probabilities_Addition_Rule.html", pathToHtmlFile + "Probabilities_Multiplication_Rule.html", pathToHtmlFile + "Probabilities_Permutation.html", pathToHtmlFile + "Probabilities_Combination.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}