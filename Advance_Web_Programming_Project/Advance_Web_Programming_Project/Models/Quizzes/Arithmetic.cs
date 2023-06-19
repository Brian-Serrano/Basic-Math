using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Arithmetic
    {
        private Random random;
        private int type, minlength, maxlength, minValue, maxValue;
        private List<int> operators;
        private List<double> operands;
        private List<int[]> fractionOperands;
        private List<bool> hasParenthesis;
        private string[] symbols;

        public Arithmetic(Random random, int level)
        {
            this.random = random;

            symbols = new string[] { " * ", " / ", " + ", " - " };
            type = random.Next(0, 3);

            if (level <= 5)
            {
                minlength = 2;
                maxlength = 5;
                minValue = 3;
                maxValue = 15;
            }
            else if (level > 5 && level <= 10)
            {
                minlength = 3;
                maxlength = 6;
                minValue = 5;
                maxValue = 20;
            }
            else if (level > 10 && level <= 20)
            {
                minlength = 3;
                maxlength = 7;
                minValue = 10;
                maxValue = 30;
            }
            else if (level > 20 && level <= 50)
            {
                minlength = 4;
                maxlength = 8;
                minValue = 15;
                maxValue = 40;
            }
            else if (level > 50 && level <= 100)
            {
                minlength = 4;
                maxlength = 9;
                minValue = 20;
                maxValue = 50;
            }
            else
            {
                minlength = 5;
                maxlength = 10;
                minValue = 30;
                maxValue = 70;
            }
        }

        public List<string> GetComponent()
        {
            int randomOperand = random.Next(minlength, maxlength);
            bool lastValue = false;
            operands = new List<double>();
            fractionOperands = new List<int[]>();
            hasParenthesis = new List<bool>();
            operators = new List<int>();
            for (int i = 0; i < randomOperand; i++)
            {
                if (i < randomOperand - 1)
                {
                    bool randomValue = random.Next(2) == 1;

                    if (lastValue && randomValue)
                        randomValue = false;

                    hasParenthesis.Add(randomValue);
                    lastValue = randomValue;

                    operators.Add(random.Next(0, 4));
                }

                switch (type)
                {
                    case 0: // Whole
                        operands.Add(random.Next(minValue, maxValue));
                        break;
                    case 1: // Decimal
                        operands.Add(Math.Round(minValue + (random.NextDouble() * (maxValue - minValue)), 2));
                        break;
                    case 2: // Fraction
                        fractionOperands.Add(new int[] { random.Next(minValue, maxValue), random.Next(minValue, maxValue) });
                        break;
                }
            }

            string question = ExpressionBuilder();
            string solution = string.Empty;
            for (int i = -1; i < symbols.Length; i++)
            {
                for (int j = 0; j < operators.Count; j++)
                {
                    if (operators[j] == i || hasParenthesis[j])
                    {
                        switch (type)
                        {
                            case 0:
                            case 1:
                                switch (operators[j])
                                {
                                    case 0:
                                        solution += "Multiply " + operands[j] + " by " + operands[j + 1];
                                        operands[j] *= operands[j + 1];
                                        break;
                                    case 1:
                                        solution += "Divide " + operands[j] + " by " + operands[j + 1];
                                        operands[j] /= operands[j + 1];
                                        break;
                                    case 2:
                                        solution += "Add " + operands[j] + " by " + operands[j + 1];
                                        operands[j] += operands[j + 1];
                                        break;
                                    case 3:
                                        solution += "Subtract " + operands[j] + " by " + operands[j + 1];
                                        operands[j] -= operands[j + 1];
                                        break;
                                }
                                solution += " = " + operands[j] + "<br>";

                                operands.RemoveAt(j + 1);
                                operators.RemoveAt(j);
                                hasParenthesis.RemoveAt(j);

                                solution += ExpressionBuilder() + "<br>";

                                break;
                            case 2:
                                switch (operators[j])
                                {
                                    case 0:
                                        solution += "Multiply numerators and denominators together " + fractionOperands[j][0] + " x " + fractionOperands[j + 1][0] + ", " + fractionOperands[j][1] + " x " + fractionOperands[j + 1][1];
                                        fractionOperands[j][0] *= fractionOperands[j + 1][0];
                                        fractionOperands[j][1] *= fractionOperands[j + 1][1];
                                        break;
                                    case 1:
                                        solution += "Find the reciprocal of " + fractionOperands[j + 1][0] + "/" + fractionOperands[j + 1][1] + " then multiply numerators and denominators together " + fractionOperands[j][0] + " x " + fractionOperands[j + 1][1] + ", " + fractionOperands[j][1] + " x " + fractionOperands[j + 1][0];
                                        fractionOperands[j][0] *= fractionOperands[j + 1][1];
                                        fractionOperands[j][1] *= fractionOperands[j + 1][0];
                                        break;
                                    case 2:
                                        solution += "Find the common denominator of " + fractionOperands[j][1] + " and " + fractionOperands[j + 1][1];
                                        int commonDenominator = FindCommonDenominator(fractionOperands[j][1], fractionOperands[j + 1][1]);
                                        int numeratorMultiplier1 = commonDenominator / fractionOperands[j][1];
                                        int numeratorMultiplier2 = commonDenominator / fractionOperands[j + 1][1];
                                        fractionOperands[j][0] *= numeratorMultiplier1;
                                        fractionOperands[j + 1][0] *= numeratorMultiplier2;
                                        solution += " = " + commonDenominator + ", then add their numerators " + fractionOperands[j][0] + "/" + commonDenominator + " + " + fractionOperands[j + 1][0] + "/" + commonDenominator;
                                        fractionOperands[j][0] += fractionOperands[j + 1][0];
                                        fractionOperands[j][1] = commonDenominator;
                                        break;
                                    case 3:
                                        solution += "Find the common denominator of " + fractionOperands[j][1] + " and " + fractionOperands[j + 1][1];
                                        int commonDenominator2 = FindCommonDenominator(fractionOperands[j][1], fractionOperands[j + 1][1]);
                                        int numeratorMultiplier3 = commonDenominator2 / fractionOperands[j][1];
                                        int numeratorMultiplier4 = commonDenominator2 / fractionOperands[j + 1][1];
                                        fractionOperands[j][0] *= numeratorMultiplier3;
                                        fractionOperands[j + 1][0] *= numeratorMultiplier4;
                                        solution += " = " + commonDenominator2 + ", then subtract the numerator " + fractionOperands[j][0] + "/" + commonDenominator2 + " by " + fractionOperands[j + 1][0] + "/" + commonDenominator2;
                                        fractionOperands[j][0] -= fractionOperands[j + 1][0];
                                        fractionOperands[j][1] = commonDenominator2;
                                        break;
                                }

                                solution += " = " + fractionOperands[j][0] + "/" + fractionOperands[j][1] + "<br>";

                                fractionOperands.RemoveAt(j + 1);
                                operators.RemoveAt(j);
                                hasParenthesis.RemoveAt(j);

                                solution += ExpressionBuilder() + "<br>";

                                break;
                        }

                        j--; // Re-evaluate if the next operator is the same
                    }
                }
            }

            string answer = string.Empty;

            switch (type)
            {
                case 0:
                    if (operands[0] % 1 != 0)
                    {
                        return GetComponent();
                    }
                    answer = operands[0].ToString();
                    break;
                case 1:
                    string operandString = operands[0].ToString();
                    int decimalPlaces = operandString.Length - operandString.IndexOf('.') - 1;
                    if (decimalPlaces > 4)
                    {
                        return GetComponent();
                    }
                    answer = operands[0].ToString();
                    break;
                case 2:
                    answer = fractionOperands[0][0] + "/" + fractionOperands[0][1];
                    break;
            }

            return new List<string> { question, solution, answer };
        }

        private string ExpressionBuilder()
        {
            string expression = string.Empty;
            for (int i = 0; i < operators.Count; i++)
            {
                expression += hasParenthesis[i] ? "(" : "";
                switch (type)
                {
                    case 0:
                    case 1:
                        expression += operands[i];
                        break;
                    case 2:
                        expression += fractionOperands[i][0] + "/" + fractionOperands[i][1];
                        break;
                }

                if (i > 0 && hasParenthesis[i - 1])
                    expression += ")";
                expression += symbols[operators[i]];
            }
            switch (type)
            {
                case 0:
                case 1:
                    expression += operands[operands.Count - 1];
                    if (operands.Count > 1 && hasParenthesis[operands.Count - 2])
                        expression += ")";
                    break;
                case 2:
                    expression += fractionOperands[fractionOperands.Count - 1][0] + "/" + fractionOperands[fractionOperands.Count - 1][1];
                    if (fractionOperands.Count > 1 && hasParenthesis[fractionOperands.Count - 2])
                        expression += ")";
                    break;
            }

            return expression;
        }

        private static int FindCommonDenominator(int denominator1, int denominator2)
        {
            int maxDenominator = Math.Max(denominator1, denominator2);
            int commonDenominator = maxDenominator;

            while (true)
            {
                if (commonDenominator % denominator1 == 0 && commonDenominator % denominator2 == 0)
                {
                    break;
                }

                commonDenominator += maxDenominator;
            }

            return commonDenominator;
        }
    }
}