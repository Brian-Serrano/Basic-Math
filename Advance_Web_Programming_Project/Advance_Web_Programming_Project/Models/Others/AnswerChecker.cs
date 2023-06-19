using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advance_Web_Programming_Project.Models.Others
{
    public static class AnswerChecker
    {
        // multiplying expressions doesnt have parenthesis add perenthesis after removing spaces
        // gcf factor doesnt have parenthesis on the first token add parenthesis after removing spaces
        // squares is in correct format (a^2 + b)(a^2 + b)
        // trinomials have ^2 on last check if there is then double the expression
        // quadratic is in correct format (a^2 + b)(a^2 + b)
        // solve for x should seperate by , not + or -
        // in sets remove { from start and } from end

        public static bool CheckAnswer(string input, string answer, int id)
        {
            try
            {
                List<string[][]> pairs = new List<string[][]>();
                switch (id)
                {
                    case 9: // Algebra
                        pairs = CheckAlgebraAnswer(input, answer);
                        break;
                    case 10: // Sets
                        pairs = CheckSetsAnswer(input, answer);
                        break;
                    default:
                        return Equals(input.Trim(), answer);
                }

                if (pairs[0].Length != pairs[1].Length) return false;

                for (int i = 0; i < pairs[1].Length; i++)
                {
                    if (!pairs[0][i].SequenceEqual(pairs[1][i])) return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static List<string[][]> CheckAlgebraAnswer(string input, string answer)
        {
            return (new string[] { input, answer }).Select(inp =>
            {
                string removeSpace = new Regex(@"[^()]+").Replace(inp.Replace(" ", ""), match => "(" + match.Value + ")").Replace("((", "(").Replace("))", ")");

                string[] substrings = Regex.Matches(removeSpace, @"\((.*?)\)").Cast<Match>().Select(m => m.Groups[1].Value).ToArray();

                string[][] subsubstrings = substrings.Select((m, i) => m.Split(new[] { '+', '-', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => substrings[i].Contains("-" + t) ? "-" + t : t).ToArray()).ToArray();

                string[][] checkExp = subsubstrings.Select((m, j) => m.Any(n => Equals(n, "^2")) ? subsubstrings[j - 1] : m).ToArray();

                return checkExp.Select(row => row.OrderBy(element => element).ToArray()).OrderBy(row => row.Length).ThenBy(row => string.Join("", row)).ToArray();
            }).ToList();
        }

        private static List<string[][]> CheckSetsAnswer(string input, string answer)
        {
            return (new string[] { input, answer }).Select(inp =>
            {
                return Regex.Matches(inp.Replace(" ", "").Replace("{{", "{").Replace("}}", "}"), "\\{(.*?)\\}").Cast<Match>().Select(m => m.Groups[1].Value).Select(m => m.Split(',')).Select(row => row.OrderBy(element => element).ToArray()).OrderBy(row => row.Length).ThenBy(row => string.Join("", row)).ToArray();
            }).ToList();
        }
    }
}