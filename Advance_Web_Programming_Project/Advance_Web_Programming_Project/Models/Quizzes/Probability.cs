using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Probability
    {
        private Random random;
        private int maxlength;
        private int[] difficultyChances;

        public Probability(Random random, int level)
        {
            this.random = random;

            if (level <= 5)
            {
                difficultyChances = new int[] { 0, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4 };
                maxlength = 10;
            }
            else if (level > 5 && level <= 10)
            {
                difficultyChances = new int[] { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
                maxlength = 12;
            }
            else if (level > 10 && level <= 20)
            {
                difficultyChances = new int[] { 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4 };
                maxlength = 14;
            }
            else if (level > 20 && level <= 50)
            {
                difficultyChances = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4 };
                maxlength = 16;
            }
            else if (level > 50 && level <= 100)
            {
                difficultyChances = new int[] { 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 4, 4 };
                maxlength = 18;
            }
            else
            {
                difficultyChances = new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 4 };
                maxlength = 20;
            }
        }

        public List<string> GetComponent()
        {
            int randomTopic = difficultyChances[random.Next(0, 14)];

            string question = string.Empty;
            string solution = string.Empty;
            string answer = string.Empty;

            switch (randomTopic)
            {
                case 0: // Permutation
                    int isRepetition = random.Next(0, 2);

                    switch (isRepetition)
                    {
                        case 0: // No repetition
                            int total = random.Next(5, maxlength);
                            int selected = random.Next(2, total);
                            question = "Find P(" + total + ", " + selected + ") for P(n, r).";
                            answer = CalculatePermutation(total, selected).ToString();
                            solution = "Use the following formula<br>P(n, r) = n! / (n - r)!<br>P(" + total + ", " + selected + ") = " + total + "! / (" + total + " - " + selected + ")!<br>P(n, r) = " + answer;
                            break;
                        case 1: // Repetition
                            int total2 = random.Next(5, maxlength);
                            List<int> kinds = GenerateNumbers(total2);
                            question = "Find P(" + total2 + ", " + string.Join(", ", kinds) + ") for P(n, n1, n2, ..., nr)";
                            answer = CalculatePermutationWithRepetition(total2, kinds).ToString();
                            solution = "Use the following formula<br>P(n, n1, n2, ..., nr) = n! / n1! * n2! * ... * nr!<br>P(" + total2 + ", " + string.Join(", ", kinds) + ") = " + total2 + "! / " + string.Join("! * ", kinds) + "!<br>P(" + total2 + ", " + string.Join(", ", kinds) + ") = " + answer;
                            break;
                    }
                    break;
                case 1: // Combination
                    int total1 = random.Next(5, maxlength);
                    int selected1 = random.Next(2, total1);
                    question = "Find C(" + total1 + ", " + selected1 + ") for C(n, r).";
                    answer = CalculateCombination(total1, selected1).ToString();
                    solution = "Use the following formula<br>C(n, r) = n! / r! (n - r)!<br>C(" + total1 + ", " + selected1 + ") = " + total1 + "! / " + selected1 + "! (" + total1 + " - " + selected1 + ")!<br>C(n, r) = " + answer;
                    break;
                case 2: // Addition Rule
                    int isExclusive = random.Next(0, 2);

                    switch (isExclusive)
                    {
                        case 0: // Mutually Exclusive
                            double[] p = GenerateTwoDoubleNumbers();
                            question = "Let P(A) = " + p[0] + " and P(B) = " + p[1] + ". Find P(A or B)";
                            answer = (p[0] + p[1]).ToString();
                            solution = "Use the following formula<br>P(A or B) = P(A) + P(B)<br>P(A or B) = " + p[0] + " + " + p[1] + "<br>P(A or B) = " + answer;
                            break;
                        case 1: // Not Mutually Exclusive
                            double[] p2 = GenerateTwoDoubleNumbers();
                            double aAndB = GenerateLessThanP(p2);
                            question = "Let P(A) = " + p2[0] + " and P(B) = " + p2[1] + ". Find P(A or B) if P(A and B) = " + aAndB;
                            answer = ((p2[0] + p2[1]) - aAndB).ToString();
                            solution = "Use the following formula<br>P(A or B) = P(A) + P(B) - P(A and B)<br>P(A or B) = " + p2[0] + " + " + p2[1] + " - " + aAndB + "<br>P(A or B) = " + answer;
                            break;
                    }
                    break;
                case 3: // Multiplication Rule
                    int isEvent = random.Next(0, 2);

                    switch (isEvent)
                    {
                        case 0: // Independent
                            int denominator = random.Next(10, 50);
                            int numerator = random.Next(5, denominator);
                            question = "Let independent event P(A) = " + numerator + "/" + denominator + ". Find P(A and B)";
                            answer = (numerator * numerator) + "/" + (denominator * denominator);
                            solution = "Use the following formula<br>P(A and B) = P(A) * P(B)<br>P(A and B) = " + numerator + "/" + denominator + " * " + numerator + "/" + denominator + "<br>P(A and B) = " + answer;
                            break;
                        case 1: // Dependent
                            int denominator2 = random.Next(10, 50);
                            int numerator2 = random.Next(5, denominator2);
                            question = "Let dependent event P(A) = " + numerator2 + "/" + denominator2 + ". Find P(A and B)";
                            answer = (numerator2 * numerator2 - 1) + "/" + (denominator2 * denominator2 - 1);
                            solution = "Use the following formula<br>P(A and B) = P(A) * P(B|A)<br>P(A and B) = " + numerator2 + "/" + denominator2 + " * " + (numerator2 - 1) + "/" + (denominator2 - 1) + "<br>P(A and B) = " + answer;
                            break;
                    }
                    break;
                case 4: // Complement Rule
                    double num = Math.Round(random.NextDouble() * 0.6 + 0.2, 2);
                    question = "Let A = " + num + ". Find A'";
                    answer = (1 - num).ToString();
                    solution = "Use the following formula<br>A' = 1 - A<br>A' = 1 - " + num + "<br>A' = " + answer;
                    break;
            }

            return new List<string>() { question, solution, answer };
        }

        private List<int> GenerateNumbers(int totalAmount)
        {
            List<int> numbers = new List<int>();
            int total = 0;

            while (total <= totalAmount)
            {
                int number = random.Next(2, 6);
                total += number;
                if (total <= totalAmount) numbers.Add(number);
            }

            return numbers;
        }

        private double[] GenerateTwoDoubleNumbers()
        {
            double num1 = Math.Round(random.NextDouble() * 0.5 + 0.2, 2);
            double num2 = Math.Round(random.NextDouble() * 0.5 + 0.2, 2);

            while (num1 == num2)
            {
                num2 = Math.Round(random.NextDouble() * 0.5 + 0.2, 2);
            }

            if (num1 + num2 > 1)
            {
                return GenerateTwoDoubleNumbers();
            }

            return new double[] { num1, num2 };
        }

        private double GenerateLessThanP(double[] p2)
        {
            double num = Math.Round(random.NextDouble() * 0.3 + 0.05, 2);

            foreach (double p in p2)
            {
                if (num > p - 0.1) return GenerateLessThanP(p2);
            }

            return num;
        }

        private static long CalculatePermutation(int n, int r) => Factorial(n) / Factorial(n - r);

        private static long CalculatePermutationWithRepetition(int n, List<int> numbers)
        {
            long result = 1;
            foreach (int number in numbers)
            {
                result *= Factorial(number);
            }
            return Factorial(n) / result;
        }

        private static long CalculateCombination(int n, int r) => Factorial(n) / (Factorial(r) * Factorial(n - r));

        private static long Factorial(int n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }
    }
}