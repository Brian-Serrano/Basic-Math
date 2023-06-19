using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class FractionTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public FractionTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1"
            };

            title = new List<string>()
            {
                "Improper and Mixed Fractions", "Simplifying Fractions"
            };

            description = new List<string>()
            {
                "Learn how to convert improper to mixed fractions and mixed to improper fractions.", "Learn how to convert fraction to simplest form"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Fraction_Conversion.html", pathToHtmlFile + "Fraction_Simplifying.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}