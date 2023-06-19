using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Topic
{
    public class AlgebraTopic
    {
        private List<string> id;
        private List<string> title;
        private List<string> description;
        private List<string> path;

        public AlgebraTopic()
        {
            string pathToHtmlFile = "~/Assets/Basic Math Course Topics/";

            id = new List<string>()
            {
                "0", "1", "2", "3", "4", "5", "6"
            };

            title = new List<string>()
            {
                "Finding Greatest Common Factor", "Quadratic Equation", "Difference of Squares", "Perfect Square Trinomials", "Factoring by Grouping", "Solve for X", "Multiplying Expressions"
            };

            description = new List<string>()
            {
                "Identify the largest factor that divides evenly into all the terms of the expression and divide each term by this factor.", "For quadratic expressions of the form ax^2 + bx + c, factor the expression into two binomials (expressions with two terms) of the form (px + q)(rx + s), where p, q, r, and s are constants.", "For expressions of the form a^2 - b^2, factor the expression as (a + b)(a - b).", "For expressions of the form a^2 + 2ab + b^2 or a^2 - 2ab + b^2, factor the expression as (a + b)^2 or (a - b)^2, respectively.", "For expressions with four or more terms, group the terms into pairs and factor out a common factor from each pair. Then, factor out a common binomial factor.", "To solve it, simply use multiplication, division, addition, and subtraction when necessary to isolate the variable and solve for \"x\".", "Multiply the coefficients of the terms, add the powers of the variables with the same base, and obtain the algebraic sum of the like and unlike terms."
            };

            path = new List<string>()
            {
                pathToHtmlFile + "Algebra_GCF.html", pathToHtmlFile + "Algebra_Quadratic.html", pathToHtmlFile + "Algebra_Squares.html", pathToHtmlFile + "Algebra_Trinomials.html", pathToHtmlFile + "Algebra_Grouping.html", pathToHtmlFile + "Algebra_Solve_For_X.html", pathToHtmlFile + "Multiplying_Algebraic_Expressions.html"
            };
        }

        public List<List<string>> GetTopic()
        {
            return new List<List<string>>() { id, title, description, path };
        }
    }
}