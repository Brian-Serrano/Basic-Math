using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class StatisticsTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public StatisticsTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1", "2", "3", "4", "5", "6", "7"
            };

            title = new List<string>()
            {
                "Measures of Central Tendency", "Measures of Variability", "Probability Distribution", "Binomial Distribution", "Poisson Distribution", "Normal Distribution", "Exponential Distribution", "Normal Distribution Table"
            };

            description = new List<string>()
            {
                "Learn how to find mean, median and mode of group of numbers.", "Learn how to find range, variance and standard deviation of group of numbers.", "Know what is probability distribution and its different types", "Learn how to find the binomial distribution of a problem", "Learn how to find poisson distribution of a problem", "Learn how to find normal distribution of a problem", "Learn how to find exponential distribution of a problem", "Find the equivalent normal distribution base on Z Score"
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Measures_Of_Central_Tendency.html", pathToHtmlFile + "Measures_Of_Variability.html", pathToHtmlFile + "Probability_Distribution.html", pathToHtmlFile + "Binomial_Distribution.html", pathToHtmlFile + "Poisson_Distribution.html", pathToHtmlFile + "Normal_Distribution.html", pathToHtmlFile + "Exponential_Distribution.html", pathToHtmlFile + "Normal_Distribution_Table.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}