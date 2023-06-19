using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Fraction
    {
        private Random random;
        private int minValue, maxValue;

        public Fraction(Random random, int level)
        {
            this.random = random;

            if (level <= 5)
            {
                minValue = 2;
                maxValue = 20;
            }
            else if (level > 5 && level <= 10)
            {
                minValue = 5;
                maxValue = 30;
            }
            else if (level > 10 && level <= 20)
            {
                minValue = 10;
                maxValue = 50;
            }
            else if (level > 20 && level <= 50)
            {
                minValue = 20;
                maxValue = 70;
            }
            else if (level > 50 && level <= 100)
            {
                minValue = 30;
                maxValue = 100;
            }
            else
            {
                minValue = 50;
                maxValue = 150;
            }
        }

        public List<string> GetComponent()
        {
            int topic = random.Next(0, 2);
            string question = string.Empty;
            string solution = string.Empty;
            string answer = string.Empty;
            switch (topic)
            {
                case 0: // Simplify
                    int gcd = random.Next(minValue, maxValue);
                    int num1 = random.Next(minValue, maxValue);
                    int num2 = GetUniqueNumber(num1);
                    int numerator = num1 * gcd;
                    int denominator = num2 * gcd;
                    List<int> numFactors = GetFactors(numerator);
                    List<int> denFactors = GetFactors(denominator);
                    int commonFactor = GetCommonFactor(numFactors, denFactors);
                    answer = GetAnswer(numerator, denominator, commonFactor);
                    question = "Simplify the fraction " + numerator + "/" + denominator;
                    solution = "Step 1: Find the GCD of " + numerator + " and " + denominator + ". The factors of " + numerator + " are " + string.Join(", ", numFactors) + ". The factors of " + denominator + " are " + string.Join(", ", denFactors) + ". The largest number that divides both " + numerator + " and " + denominator + " is " + commonFactor + ".<br>Step 2: Divide both the numerator and denominator by " + commonFactor + ".<br>" + numerator + "/" + denominator + " = (" + numerator + " ÷ " + commonFactor + ") / (" + denominator + " ÷ " + commonFactor + ") = " + answer;
                    break;
                case 1: // Improper and Mixed
                    int type = random.Next(0, 2);
                    switch (type)
                    {
                        case 0: // Mixed to Improper
                            int denMixed = random.Next(minValue + 3, maxValue);
                            int numMixed = random.Next(minValue, denMixed);
                            int wholeNum = random.Next(minValue, maxValue / 2);
                            int denWhole = denMixed * wholeNum;
                            int denWholeNum = denWhole + numMixed;
                            question = "Convert the mixed fraction " + wholeNum + " " + numMixed + "/" + denMixed + " to an improper fraction.";
                            solution = "Step 1: Multiply the whole number (" + wholeNum + ") by the denominator (" + denMixed + "): " + wholeNum + " * " + denMixed + " = " + denWhole + ".<br>Step 2: Add the result (" + denWhole + ") to the numerator (" + numMixed + "): " + denWhole + " + " + numMixed + " = " + denWholeNum + ".<br>Step 3: Place the sum (" + denWholeNum + ") over the original denominator (" + denMixed + "): " + denWholeNum + "/" + denMixed + ".<br>So, " + wholeNum + " " + numMixed + "/" + denMixed + " as an improper fraction is " + denWholeNum + "/" + denMixed + ".";
                            answer = denWholeNum + "/" + denMixed;
                            break;
                        case 1: // Improper to Mixed
                            int denImp = random.Next(minValue + 3, maxValue);
                            int numImp = (denImp * random.Next(minValue, maxValue / 2)) + random.Next(minValue, denImp);
                            int divideNumDen = numImp / denImp;
                            int modNumDen = numImp % denImp;
                            question = "Convert the improper fraction " + numImp + "/" + denImp + " to a mixed fraction.";
                            solution = "Step 1: Divide the numerator (" + numImp + ") by the denominator (" + denImp + "): " + numImp + " ÷ " + denImp + " = " + divideNumDen + " with a remainder of " + modNumDen + ".<br>Step 2: Take the remainder (" + modNumDen + ") as the new numerator.<br>Step 3: Place the new numerator (" + modNumDen + ") over the original denominator (" + denImp + "): " + modNumDen + "/" + denImp + ".<br>So, " + numImp + "/" + denImp + " as a mixed fraction is " + divideNumDen + " " + modNumDen + "/" + denImp + ".";
                            answer = divideNumDen + " " + modNumDen + "/" + denImp;
                            break;
                    }
                    break;
            }



            return new List<string>() { question, solution, answer };
        }

        private int GetUniqueNumber(int numToCompare)
        {
            int num = random.Next(minValue, maxValue);
            if (num == numToCompare)
            {
                return GetUniqueNumber(numToCompare);
            }
            return num;
        }

        private static List<int> GetFactors(int number)
        {
            List<int> factors = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    factors.Add(i);
            }

            factors.Sort();
            return factors;
        }

        private static int GetCommonFactor(List<int> num, List<int> den)
        {
            for (int i = num.Count - 1; i >= 0; i--)
            {
                for (int j = den.Count - 1; j >= 0; j--)
                {
                    if (num[i] == den[j]) return num[i];
                }
            }
            return 0;
        }

        private static string GetAnswer(int num, int den, int fac) => (num / fac) + "/" + (den / fac);
    }
}