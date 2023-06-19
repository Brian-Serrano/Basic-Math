using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Algebra
    {
        private Random random;
        private int minlength, maxlength, minValue, maxValue, randomLetter;
        private string[,] letterProp;
        private int[] factorDifficulty;

        public Algebra(Random random, int level)
        {
            this.random = random;

            letterProp = new string[,]
            {
                { "x", "y" }, { "a", "b" }, { "f", "g" }, { "i", "j" }, { "k", "l" }, { "d", "e" }, { "y", "z" }, { "m", "n" }, { "p", "q" }, { "s", "t" }, { "u", "v" }
            };

            randomLetter = random.Next(0, 11);

            if (level <= 5)
            {
                minlength = 2;
                maxlength = 3;
                minValue = 2;
                maxValue = 4;

                factorDifficulty = new int[] // 2, 3, 0, 4, 1
                {
                    2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 4, 4, 1, 1
                };
            }
            else if (level > 5 && level <= 10)
            {
                minlength = 2;
                maxlength = 3;
                minValue = 2;
                maxValue = 4;

                factorDifficulty = new int[] // 2, 3, 0, 4, 1
                {
                    2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 0, 0, 0, 0, 4, 4, 4, 1, 1, 1
                };
            }
            else if (level > 10 && level <= 20)
            {
                minlength = 2;
                maxlength = 3;
                minValue = 1;
                maxValue = 4;

                factorDifficulty = new int[] // 2, 3, 0, 4, 1
                {
                    2, 2, 2, 2, 3, 3, 3, 3, 0, 0, 0, 0, 4, 4, 4, 4, 1, 1, 1, 1
                };
            }
            else if (level > 20 && level <= 50)
            {
                minlength = 2;
                maxlength = 4;
                minValue = 1;
                maxValue = 4;

                factorDifficulty = new int[] // 2, 3, 0, 4, 1
                {
                    2, 2, 2, 3, 3, 3, 3, 3, 0, 0, 0, 0, 4, 4, 4, 4, 4, 1, 1, 1
                };
            }
            else if (level > 50 && level <= 100)
            {
                minlength = 2;
                maxlength = 4;
                minValue = 1;
                maxValue = 5;

                factorDifficulty = new int[] // 2, 3, 0, 4, 1
                {
                    2, 2, 2, 3, 3, 3, 0, 0, 0, 0, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1
                };
            }
            else
            {
                minlength = 2;
                maxlength = 4;
                minValue = 1;
                maxValue = 5;

                factorDifficulty = new int[] // 2, 3, 0, 4, 1
                {
                    2, 2, 3, 3, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1
                };
            }
        }

        public List<string> GetComponent()
        {
            int randomTopic = random.Next(0, 3);

            string question = string.Empty;
            string solution = string.Empty;
            string answer = string.Empty;

            switch (randomTopic)
            {
                case 0: // Multiply
                    int parenthesisAmount = random.Next(minlength, maxlength);
                    List<int> tokenAmount = new List<int>();
                    for (int i = 0; i < parenthesisAmount; i++)
                    {
                        tokenAmount.Add(random.Next(minValue, maxValue));
                    }
                    List<List<int[]>> tokens = new List<List<int[]>>();
                    for (int i = 0; i < parenthesisAmount; i++)
                    {
                        List<int[]> token = new List<int[]>();
                        for (int j = 0; j < tokenAmount[i]; j++)
                        {
                            int[] letters = FindCommonPair(token);
                            token.Add(new int[] { GenerateNonZeroNumber(), letters[0], letters[1] });
                        }
                        tokens.Add(token);
                    }
                    question = "Multiply the following expression: " + ExpressionBuilder(tokens);
                    ArrayList res = MergeParenthesisByDistributive(tokens, "");
                    List<int[]> result = ((List<List<int[]>>)(res[0]))[0];
                    solution = res[1].ToString().Trim();
                    answer = ExpressionBuilder(new List<List<int[]>>() { EvaluateEqualLettersAndSort(result) });
                    answer = answer.Substring(1, answer.Length - 2);
                    break;
                case 1: // Factor
                    int factorType = factorDifficulty[random.Next(0, 20)];
                    switch (factorType)
                    {
                        case 0: // GCF
                            List<int[]> tokensGcf = new List<int[]>();
                            int tokenAmountGcf = random.Next(2, 5);
                            int tokenPusher = random.Next(2, 10);
                            for (int i = 0; i < tokenAmountGcf; i++)
                            {
                                int[] lettersGcf = FindCommonPair(tokensGcf);
                                tokensGcf.Add(new int[] { GenerateNonZeroNumber() * tokenPusher, lettersGcf[0], lettersGcf[1] });
                            }
                            question = ExpressionBuilder(new List<List<int[]>>() { tokensGcf });
                            question = "Factor the following expression: " + question.Substring(1, question.Length - 2);
                            string[] gcf = GetGcfAnswerAndSolution(tokensGcf);
                            solution = gcf[0];
                            answer = gcf[1];
                            break;
                        case 1: // Grouping
                            int[] numbersGro = GenerateSimplifiedNumbers();
                            List<int[]> letterGro = GenPairForGrouping();
                            string[] grouping = GetQuestionGrouping(numbersGro, letterGro);
                            question = "Factor the following expression: " + grouping[0];
                            solution = grouping[1];
                            answer = grouping[2];
                            break;
                        case 2: // Squares
                            int[] letter = new int[] { random.Next(1, 2), random.Next(0, 1) };
                            int[] number = new int[] { random.Next(1, 5), random.Next(2, 10) };
                            question = "Factor the following expression: " + GetSquareQuestion(letter, number);
                            answer = "(" + number[0] + GetLetter(letterProp[randomLetter, 0], letter[0]) + " + " + number[1] + GetLetter(letterProp[randomLetter, 1], letter[1]) + ")(" + number[0] + GetLetter(letterProp[randomLetter, 0], letter[0]) + " - " + number[1] + GetLetter(letterProp[randomLetter, 1], letter[1]) + ")";
                            solution = "Apply the Difference of Squares pattern:<br>" + question + " = " + answer;
                            break;
                        case 3: // Trinomials
                            bool isNegative = random.Next(0, 2) == 1;
                            int[] letterTri = new int[] { random.Next(1, 2), random.Next(0, 1) };
                            int[] numberTri = new int[] { random.Next(1, 5), isNegative ? -random.Next(2, 10) : random.Next(2, 10) };
                            answer = "(" + numberTri[0] + GetLetter(letterProp[randomLetter, 0], letterTri[0]) + IsNegative(numberTri[1]) + GetLetter(letterProp[randomLetter, 1], letterTri[1]) + ")^2";
                            string[] trinomials = GetTrinomialQuestion(letterTri, numberTri, answer);
                            question = "Factor the following expression: " + trinomials[0];
                            solution = trinomials[1];
                            break;
                        case 4: // Quadratic
                            int[] numbers = new int[] { random.Next(1, 10), random.Next(1, 10), GenerateNonZeroNumber(), GenerateNonZeroNumber() };
                            answer = "(" + numbers[0] + letterProp[randomLetter, 0] + IsNegative(numbers[2]) + ")(" + numbers[1] + letterProp[randomLetter, 0] + IsNegative(numbers[3]) + ")";
                            question = "Factor the following expression: " + GetQuadraticQuestion(numbers);
                            solution = "To factor this quadratic expression, we need to find two binomial expressions whose product equals the original expression. In this case, we can factor it as " + answer + ".";
                            break;
                    }
                    break;
                case 2: // Solve for x
                    string[] quadraticX = FindQuadraticEquationX();
                    question = quadraticX[0];
                    solution = quadraticX[1];
                    answer = quadraticX[2];
                    break;
            }

            return new List<string>() { question, solution, answer };
        }

        private static string IsNegative(int n) => n < 0 ? " - " + Math.Abs(n) : " + " + n;

        private string ExpressionBuilder(List<List<int[]>> tokens)
        {
            string expression = string.Empty;
            for (int i = 0; i < tokens.Count; i++)
            {
                expression += "(";
                for (int j = 0; j < tokens[i].Count; j++)
                {
                    if (j != 0)
                        expression += IsNegative(tokens[i][j][0]);
                    else
                        expression += tokens[i][j][0];
                    expression += GetLetter(letterProp[randomLetter, 0], tokens[i][j][1]) + GetLetter(letterProp[randomLetter, 1], tokens[i][j][2]);
                }
                expression += ")";
            }
            return expression;
        }

        private int GenerateNonZeroNumber()
        {
            int number = random.Next(-9, 10);
            if (number == 0) return GenerateNonZeroNumber();
            return number;
        }

        private ArrayList MergeParenthesisByDistributive(List<List<int[]>> pairs, string solution)
        {
            List<List<int[]>> tokens = new List<List<int[]>>(pairs);
            List<int[]> result = new List<int[]>();
            solution += "Multiply the numbers in the first parenthesis by the numbers in the second parenthesis by distributive property.<br>";
            for (int i = 0; i < tokens[0].Count; i++)
            {
                for (int j = 0; j < tokens[1].Count; j++)
                {
                    solution += "(" + tokens[0][i][0] + GetLetter(letterProp[randomLetter, 0], tokens[0][i][1]) + GetLetter(letterProp[randomLetter, 1], tokens[0][i][2]) + ")(" + tokens[1][j][0] + GetLetter(letterProp[randomLetter, 0], tokens[1][j][1]) + GetLetter(letterProp[randomLetter, 1], tokens[1][j][2]) + ")";
                    int numResult = tokens[0][i][0] * tokens[1][j][0];
                    int xResult = tokens[0][i][1] + tokens[1][j][1];
                    int yResult = tokens[0][i][2] + tokens[1][j][2];
                    int[] res = new int[] { numResult, xResult, yResult };
                    result.Add(res);
                    solution += " = " + numResult + GetLetter(letterProp[randomLetter, 0], xResult) + GetLetter(letterProp[randomLetter, 1], yResult) + "<br>";
                }
            }
            tokens.RemoveAt(0);
            tokens.RemoveAt(0);
            tokens.Insert(0, result);
            if (tokens.Count > 1)
            {
                return MergeParenthesisByDistributive(tokens, solution);
            }
            return new ArrayList() { tokens, solution };
        }

        private static string GetLetter(string letter, int amount)
        {
            string result = string.Empty;
            if (amount == 1)
            {
                result += letter;
            }
            else if (amount > 1)
            {
                result += letter + "^" + amount;
            }
            return result;
        }

        private int[] FindCommonPair(List<int[]> pairs)
        {
            int[] newPair = new int[] { random.Next(0, 3), random.Next(0, 3) };
            foreach (int[] pair in pairs)
            {
                if (newPair[0] == pair[1] && newPair[1] == pair[2])
                {
                    return FindCommonPair(pairs);
                }
            }
            return newPair;
        }

        private static List<int[]> EvaluateEqualLettersAndSort(List<int[]> pairs)
        {
            List<int[]> tokens = new List<int[]>(pairs);
            for (int i = 0; i < tokens.Count; i++)
            {
                for (int j = i + 1; j < tokens.Count; j++)
                {
                    if (tokens[i][1] == tokens[j][1] && tokens[i][2] == tokens[j][2])
                    {
                        tokens[i][0] += tokens[j][0];
                        tokens.RemoveAt(j);
                        i--;
                        break;
                    }
                }
            }

            tokens.Sort(new DescendingSumComparer());
            return tokens;
        }

        private string GetSquareQuestion(int[] letter, int[] number)
        {
            int[] resNum = new int[] { number[0] * number[0], number[1] * number[1] };
            int[] resLet = new int[] { letter[0] + letter[0], letter[1] + letter[1] };
            return resNum[0] + GetLetter(letterProp[randomLetter, 0], resLet[0]) + " - " + resNum[1] + GetLetter(letterProp[randomLetter, 1], resLet[1]);
        }

        private string[] GetTrinomialQuestion(int[] letter, int[] number, string answer)
        {
            List<int> resNum = new List<int>
            {
                number[0] * number[0],
                (number[0] * number[1]) * 2,
                number[1] * number[1]
            };
            List<string> resLet = new List<string>()
            {
                GetLetter(letterProp[randomLetter, 0], letter[0] * 2),
                GetLetter(letterProp[randomLetter, 0], letter[0]) + GetLetter(letterProp[randomLetter, 1], letter[1]),
                GetLetter(letterProp[randomLetter, 1], letter[1] * 2)
            };
            string question = resNum[0] + resLet[0] + IsNegative(resNum[1]) + resLet[1] + IsNegative(resNum[2]) + resLet[2];
            string solution = "Step 1: Check if the first and last terms are perfect squares:<br>" + resNum[0] + resLet[0] + " is the square of " + number[0] + GetLetter(letterProp[randomLetter, 0], letter[0]) + ", and " + resNum[2] + resLet[2] + " is the square of " + number[1] + GetLetter(letterProp[randomLetter, 1], letter[1]) + ".<br>Step 2: Check if the middle term is twice the product of the square roots of the first and last terms:<br>" + resNum[1] + resLet[1] + " is twice the product of " + number[0] + GetLetter(letterProp[randomLetter, 0], letter[0]) + " and " + number[1] + GetLetter(letterProp[randomLetter, 1], letter[1]) + ".<br>Step 3: Express the trinomial as the square of a binomial:<br>" + question + " = " + answer;
            return new string[] { question, solution };
        }

        private string[] GetGcfAnswerAndSolution(List<int[]> tokens)
        {
            string solution = "Step 1: Identify the terms: " + string.Join(", ", tokens.Select(t => t[0] + GetLetter(letterProp[randomLetter, 0], t[1]) + GetLetter(letterProp[randomLetter, 1], t[2])).ToList()) + "<br>Step 2: Determine the GCF: The common factors of the coefficients (" + string.Join(", ", tokens.Select(t => t[0])) + ") are ";
            List<List<int>> result = new List<List<int>>();
            List<int> mins = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                List<int> filteredToken = tokens.Select(t => t[i]).ToList();
                int min = i == 0 ? GCF(filteredToken) : filteredToken.Min();
                mins.Add(min);
                result.Add(i == 0 ? filteredToken.Select(t => t / min).ToList() : filteredToken.Select(t => t - min).ToList());
            }
            string letters = GetLetter(letterProp[randomLetter, 0], mins[1]) + GetLetter(letterProp[randomLetter, 1], mins[2]);
            string answer = mins[0] + letters + "(";
            solution += mins[0] + " and the common factors of the variables (" + string.Join(", ", tokens.Select(t => GetLetter(letterProp[randomLetter, 0], t[1]) + GetLetter(letterProp[randomLetter, 1], t[2])).ToList()) + ") is " + letters + "<br>GCF = " + mins[0] + letters + ".<br>Step 3: Write the GCF outside parentheses: " + mins[0] + letters + "<br>Step 4: Divide each term by the GCF and write the result inside the parentheses:";
            for (int i = 0; i < tokens.Count; i++)
            {
                if (i == 0)
                {
                    answer += result[0][i] + GetLetter(letterProp[randomLetter, 0], result[1][i]) + GetLetter(letterProp[randomLetter, 1], result[2][i]);
                }
                else
                {
                    answer += IsNegative(result[0][i]) + GetLetter(letterProp[randomLetter, 0], result[1][i]) + GetLetter(letterProp[randomLetter, 1], result[2][i]);
                }
            }
            for (int i = 0; i < tokens.Count; i++)
            {
                solution += "<br>" + tokens[i][0] + GetLetter(letterProp[randomLetter, 0], tokens[i][1]) + GetLetter(letterProp[randomLetter, 1], tokens[i][2]) + " ÷ (" + mins[0] + letters + ") = " + result[0][i] + GetLetter(letterProp[randomLetter, 0], result[1][i]) + GetLetter(letterProp[randomLetter, 1], result[2][i]);
            }
            answer += ")";

            return new string[] { solution, answer };
        }

        private string GetQuadraticQuestion(int[] numbers)
        {
            int temp1 = (numbers[0] * numbers[3]) + (numbers[1] * numbers[2]);
            int temp2 = numbers[2] * numbers[3];
            string token1 = (numbers[0] * numbers[1]) + GetLetter(letterProp[randomLetter, 0], 2);
            string token2 = temp1 == 0 ? "" : IsNegative(temp1) + GetLetter(letterProp[randomLetter, 0], 1);
            string token3 = IsNegative(temp2) + GetLetter(letterProp[randomLetter, 0], 0);
            return token1 + token2 + token3;
        }

        private static int GCF(List<int> arr)
        {
            int result = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                result = GCF(result, arr[i]);
            }
            return result;
        }

        private static int GCF(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private string[] FindQuadraticEquationX()
        {
            int a = random.Next(1, 10);
            int b = random.Next(-9, 10);
            int c = random.Next(-9, 10);

            Tuple<double, double> ans = SolveQuadraticEquation(a, b, c);

            if (ans == null)
            {
                return FindQuadraticEquationX();
            }

            string l = letterProp[randomLetter, 0];

            string question = "Solve for " + l + ": " + a + l + "^2" + IsNegative(b) + l + IsNegative(c) + ". Round your answer to 2 decimal places. Enclose your answer with parenthesis.";
            string answer = string.Join(", ", ans);
            string solution = "Coefficients are: a = " + a + ", b = " + b + ", c = " + c + "<br>Quadratic Formula: " + l + " = (−b ± √(b^2 − 4ac)) / 2a<br>Put in a, b and c: " + l + " = (" + -b + " ± √(" + b + "^2 - 4" + " x " + a + " x " + c + ")) / 2 x " + a + "<br>Solve: " + l + " = (" + -b + " ± √(" + Math.Pow(b, 2) + " - (" + (4 * a * c) + "))) / " + (2 * a) + "<br>Answer: " + l + " = " + ans.Item1 + " or " + l + " = " + ans.Item2;

            return new string[] { question, solution, answer };
        }

        private static Tuple<double, double> SolveQuadraticEquation(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double x1 = (-b + sqrtDiscriminant) / (2 * a);
                double x2 = (-b - sqrtDiscriminant) / (2 * a);
                return Tuple.Create(Math.Round(x1, 2), Math.Round(x2, 2));
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                return Tuple.Create(x, x);
            }
            else
            {
                return null;
            }
        }

        private List<int[]> GenPairForGrouping()
        {
            List<int[]> pairs = new List<int[]>();
            bool randBool = false;
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    randBool = random.Next(0, 2) == 1;
                    pairs.Add(new int[] { randBool ? random.Next(0, 2) : 0, !randBool ? random.Next(0, 2) : 0 });
                }
                else
                {
                    pairs.Add(new int[] { !randBool ? random.Next(0, 2) : 0, randBool ? random.Next(0, 2) : 0 });
                }
            }

            if ((pairs[0][0] == 0 && pairs[0][1] == 0 && pairs[1][0] == 0 && pairs[1][1] == 0) || (pairs[2][0] == 0 && pairs[2][1] == 0 && pairs[3][0] == 0 && pairs[3][1] == 0))
                return GenPairForGrouping();

            return pairs;
        }

        private string[] GetQuestionGrouping(int[] numbers, List<int[]> letters)
        {
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 2; j < 4; j++)
                {
                    result.Add(new int[] { numbers[i] * numbers[j], letters[i][0] + letters[j][0], letters[i][1] + letters[j][1] });
                }
            }

            string l1 = letterProp[randomLetter, 0];
            string l2 = letterProp[randomLetter, 1];
            string secPar = "(" + numbers[2] + GetLetter(l1, letters[2][0]) + GetLetter(l2, letters[2][1]) + IsNegative(numbers[3]) + GetLetter(l1, letters[3][0]) + GetLetter(l2, letters[3][1]) + ")";
            string firstToken = numbers[0] + GetLetter(l1, letters[0][0]) + GetLetter(l2, letters[0][1]);
            string secondToken = IsNegative(numbers[1]) + GetLetter(l1, letters[1][0]) + GetLetter(l2, letters[1][1]);
            string firstPar = "(" + firstToken + secondToken + ")";

            string answer = firstPar + secPar;

            string question = GenGroupingExpression(result, l1, l2);
            List<int[]> resultEval = EvaluateEqualLettersAndSort(result);
            string questionEval = GenGroupingExpression(resultEval, l1, l2);

            string solution = "Step 1: Group the terms into pairs.<br>" + AddParenthesis(question) + "<br>Step 2: Factor out the common factor from each pair.<br>" + firstToken + secPar + secondToken + secPar + "<br>Step 3: Look for a common factor in the resulting binomials.<br>Notice that " + secPar + " is a common factor.<br>Step 4: Factor out the common factor from the binomials.<br>" + answer;

            return new string[] { questionEval, solution, answer };
        }

        private static string GenGroupingExpression(List<int[]> result, string l1, string l2)
        {
            string question = string.Empty;
            for (int i = 0; i < result.Count; i++)
            {
                if (i != 0)
                {
                    question += IsNegative(result[i][0]) + GetLetter(l1, result[i][1]) + GetLetter(l2, result[i][2]);
                }
                else
                {
                    question += result[i][0] + GetLetter(l1, result[i][1]) + GetLetter(l2, result[i][2]);
                }
            }
            return question;
        }

        private static string AddParenthesis(string expression)
        {
            string[] splittedExp = expression.Split(' ');
            for (int i = 0; i < splittedExp.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if ((i + 4) % 4 == 0)
                    {
                        splittedExp[i] = "(" + splittedExp[i];
                    }
                    else
                    {
                        splittedExp[i] = splittedExp[i] + ")";
                    }
                }
            }
            return string.Join(" ", splittedExp);
        }

        private int[] GenerateSimplifiedNumbers()
        {
            int[] num = new int[] { random.Next(1, 10), GenerateNonZeroNumber(), random.Next(1, 10), GenerateNonZeroNumber() };

            if (GCF(num[0], num[1]) != 1 || GCF(num[2], num[3]) != 1) return GenerateSimplifiedNumbers();

            return num;
        }
    }

    public class DescendingSumComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int sumX = x[1] + x[2];
            int sumY = y[1] + y[2];

            return sumY.CompareTo(sumX);
        }
    }
}