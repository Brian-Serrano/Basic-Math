using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class NumberSystem
    {
        private Random random;
        private string[] numberSystems;
        private int[] numberSystemsValue;
        private int from, to, number, minValue, maxValue;

        public NumberSystem(Random random, int level)
        {
            this.random = random;

            numberSystems = new string[] { "Binary", "Octal", "Decimal", "Hexadecimal" };
            numberSystemsValue = new int[] { 2, 8, 10, 16 };

            if (level <= 5)
            {
                minValue = 20;
                maxValue = 200;
            }
            else if (level > 5 && level <= 10)
            {
                minValue = 50;
                maxValue = 500;
            }
            else if (level > 10 && level <= 20)
            {
                minValue = 100;
                maxValue = 1000;
            }
            else if (level > 20 && level <= 50)
            {
                minValue = 150;
                maxValue = 1500;
            }
            else if (level > 50 && level <= 100)
            {
                minValue = 200;
                maxValue = 2000;
            }
            else
            {
                minValue = 500;
                maxValue = 5000;
            }
        }

        private int AvoidDuplicate()
        {
            int num = random.Next(0, 4);
            if (from == num)
            {
                return AvoidDuplicate();
            }
            return num;
        }

        public List<string> GetComponent()
        {
            from = random.Next(0, 4);
            to = AvoidDuplicate();

            number = random.Next(minValue, maxValue);

            string fromAnswer = Convert.ToString(number, numberSystemsValue[from]);
            string toAnswer = Convert.ToString(number, numberSystemsValue[to]);

            string statement = "Convert " + numberSystems[from] + " number " + fromAnswer + " to " + numberSystems[to] + ".";

            string solution = GetSolution(fromAnswer, toAnswer);

            return new List<string>() { statement, solution, toAnswer };
        }

        private string GetSolution(string fromAnswer, string toAnswer)
        {
            string solution = string.Empty;
            switch (from)
            {
                case 0: // Binary
                    switch (to)
                    {
                        case 1: // Binary - Octal
                            solution += "Step 1: Group the binary digits into sets of three from right to left:<br>";
                            List<string> splittedNumber = SplitString(fromAnswer, 3);
                            List<string> splittedAnswer = SplitString(toAnswer, 1);
                            for (int i = 0; i < splittedNumber.Count; i++)
                            {
                                solution += splittedNumber[i] + " ";
                            }
                            solution += "<br>Step 2: Convert each group to octal:<br>";
                            for (int i = 0; i < splittedNumber.Count; i++)
                            {
                                solution += splittedNumber[i] + " (binary) = " + splittedAnswer[i] + " (octal)<br>";
                            }
                            solution += "Therefore, the binary number " + fromAnswer + " is equivalent to the octal number " + toAnswer + ".";
                            break;
                        case 2: // Binary - Decimal
                            solution += "Step 1: Assign powers of 2 to each digit from right to left:<br>";
                            List<string> splittedBinary = SplitString(fromAnswer, 1);
                            for (int i = 0; i < splittedBinary.Count; i++)
                            {
                                string seperator = i >= splittedBinary.Count - 1 ? "" : " + ";
                                solution += splittedBinary[i] + " * 2^" + ((splittedBinary.Count - 1) - i) + seperator;
                            }
                            solution += "<br>Step 2: Perform the calculations:<br>";
                            for (int i = 0; i < splittedBinary.Count; i++)
                            {
                                string seperator = i >= splittedBinary.Count - 1 ? " = " + toAnswer + "<br>" : " + ";
                                double answer = Math.Pow(2, (splittedBinary.Count - 1) - i) * int.Parse(splittedBinary[i]);
                                solution += answer + seperator;
                            }
                            solution += "Therefore, the binary number " + fromAnswer + " is equivalent to the decimal number " + toAnswer + ".";
                            break;
                        case 3: // Binary - Hexadecimal
                            solution += "Step 1: Group the binary digits into sets of four from right to left:<br>";
                            List<string> splittedNum = SplitString(fromAnswer, 4);
                            List<string> splittedAns = SplitString(toAnswer, 1);
                            for (int i = 0; i < splittedNum.Count; i++)
                            {
                                solution += splittedNum[i] + " ";
                            }
                            solution += "<br>Step 2: Convert each group to hexadecimal:<br>";
                            for (int i = 0; i < splittedNum.Count; i++)
                            {
                                solution += splittedNum[i] + " (binary) = " + splittedAns[i] + " (hexadecimal)<br>";
                            }
                            solution += "Therefore, the binary number " + fromAnswer + " is equivalent to the hexadecimal number " + toAnswer + ".";
                            break;
                    }
                    break;
                case 1: // Octal
                    switch (to)
                    {
                        case 0: // Octal - Binary
                            solution += "Replace each octal digit with its equivalent 3-digit binary representation:<br>";
                            List<string> splittedNumber = SplitString(fromAnswer, 1);
                            List<string> splittedAnswer = SplitString(toAnswer, 3);
                            for (int i = 0; i < splittedNumber.Count; i++)
                            {
                                solution += splittedNumber[i] + " (octal) = " + splittedAnswer[i] + " (binary)<br>";
                            }
                            solution += "Therefore, the octal number " + fromAnswer + " is equivalent to the binary number " + toAnswer + ".";
                            break;
                        case 2: // Octal - Decimal
                            solution += "Step 1: Assign powers of 8 to each digit from right to left:<br>";
                            List<string> splittedOctal = SplitString(fromAnswer, 1);
                            for (int i = 0; i < splittedOctal.Count; i++)
                            {
                                string seperator = i >= splittedOctal.Count - 1 ? "" : " + ";
                                solution += splittedOctal[i] + " * 8^" + ((splittedOctal.Count - 1) - i) + seperator;
                            }
                            solution += "<br>Step 2: Perform the calculations:<br>";
                            for (int i = 0; i < splittedOctal.Count; i++)
                            {
                                string seperator = i >= splittedOctal.Count - 1 ? " = " + toAnswer + "<br>" : " + ";
                                double answer = Math.Pow(8, (splittedOctal.Count - 1) - i) * int.Parse(splittedOctal[i]);
                                solution += answer + seperator;
                            }
                            solution += "Therefore, the octal number " + fromAnswer + " is equivalent to the decimal number " + toAnswer + ".";
                            break;
                        case 3: // Octal - Hexadecimal
                            solution += "Step 1: Convert the octal number to binary:<br>";
                            string tempBinary = Convert.ToString(number, numberSystemsValue[0]);
                            List<string> splittedNum = SplitString(fromAnswer, 1);
                            List<string> splittedBin1 = SplitString(tempBinary, 3);
                            List<string> splittedBin2 = SplitString(tempBinary, 4);
                            List<string> splittedHex = SplitString(toAnswer, 1);
                            for (int i = 0; i < splittedNum.Count; i++)
                            {
                                solution += splittedNum[i] + " (octal) = " + splittedBin1[i] + " (binary)<br>";
                            }
                            solution += "So, the octal number " + fromAnswer + " is equivalent to the binary number " + tempBinary + ".<br>";
                            solution += "Step 2: Convert the binary number to hexadecimal:<br>";
                            for (int i = 0; i < splittedHex.Count; i++)
                            {
                                solution += splittedBin2[i] + " (binary) = " + splittedHex[i] + " (hexadecimal)<br>";
                            }
                            solution += "Therefore, the octal number " + fromAnswer + " is equivalent to the hexadecimal number " + toAnswer + ".";
                            break;
                    }
                    break;
                case 2: // Decimal
                    switch (to)
                    {
                        case 0: // Decimal - Binary
                            int tempFrom = int.Parse(fromAnswer);
                            for (int i = 0; i < toAnswer.Length; i++)
                            {
                                solution += "Step " + (i + 1) + ": Divide " + tempFrom + " by 2:<br>";
                                solution += tempFrom + " ÷ 2 = " + (tempFrom / 2) + " remainder " + (tempFrom % 2) + "<br>";
                                tempFrom /= 2;
                            }
                            solution += "The remainders in reverse order are " + toAnswer + ", so the binary representation of " + fromAnswer + " is " + toAnswer + ".";
                            break;
                        case 1: // Decimal - Octal
                            int tempFrom2 = int.Parse(fromAnswer);
                            for (int i = 0; i < toAnswer.Length; i++)
                            {
                                solution += "Step " + (i + 1) + ": Divide " + tempFrom2 + " by 8:<br>";
                                solution += tempFrom2 + " ÷ 8 = " + (tempFrom2 / 8) + " remainder " + (tempFrom2 % 8) + "<br>";
                                tempFrom2 /= 8;
                            }
                            solution += "The remainders in reverse order are " + toAnswer + ", so the octal representation of " + fromAnswer + " is " + toAnswer + ".";
                            break;
                        case 3: // Decimal - Hexadecimal
                            int tempFrom3 = int.Parse(fromAnswer);
                            for (int i = 0; i < toAnswer.Length; i++)
                            {
                                solution += "Step " + (i + 1) + ": Divide " + tempFrom3 + " by 16:<br>";
                                solution += tempFrom3 + " ÷ 16 = " + (tempFrom3 / 16) + " remainder " + (tempFrom3 % 16) + "<br>";
                                tempFrom3 /= 16;
                            }
                            solution += "The remainders in reverse order are " + toAnswer + ", so the hexadecimal representation of " + fromAnswer + " is " + toAnswer + ".";
                            break;
                    }
                    break;
                case 3: // Hexadecimal
                    switch (to)
                    {
                        case 0: // Hexadecimal - Binary
                            solution += "Replace each hexadecimal digit with its equivalent 4-digit binary representation:<br>";
                            List<string> splittedNumber = SplitString(fromAnswer, 1);
                            List<string> splittedAnswer = SplitString(toAnswer, 4);
                            for (int i = 0; i < splittedNumber.Count; i++)
                            {
                                solution += splittedNumber[i] + " (hexadecimal) = " + splittedAnswer[i] + " (binary)<br>";
                            }
                            solution += "Therefore, the hexadecimal number " + fromAnswer + " is equivalent to the binary number " + toAnswer + ".";
                            break;
                        case 1: // Hexadecimal - Octal
                            solution += "Step 1: Convert the hexadecimal number to binary:<br>";
                            string tempBinary = Convert.ToString(number, numberSystemsValue[0]);
                            List<string> splittedNum = SplitString(fromAnswer, 1);
                            List<string> splittedBin1 = SplitString(tempBinary, 4);
                            List<string> splittedBin2 = SplitString(tempBinary, 3);
                            List<string> splittedHex = SplitString(toAnswer, 1);
                            for (int i = 0; i < splittedNum.Count; i++)
                            {
                                solution += splittedNum[i] + " (octal) = " + splittedBin1[i] + " (binary)<br>";
                            }
                            solution += "So, the hexadecimal number " + fromAnswer + " is equivalent to the binary number " + tempBinary + ".<br>";
                            solution += "Step 2: Convert the binary number to octal:<br>";
                            for (int i = 0; i < splittedHex.Count; i++)
                            {
                                solution += splittedBin2[i] + " (binary) = " + splittedHex[i] + " (hexadecimal)<br>";
                            }
                            solution += "Therefore, the hexadecimal number " + fromAnswer + " is equivalent to the octal number " + toAnswer + ".";
                            break;
                        case 2: // Hexadecimal - Decimal
                            solution += "Step 1: Assign powers of 16 to each digit from right to left:<br>";
                            List<string> splittedHexa = SplitString(fromAnswer, 1);
                            for (int i = 0; i < splittedHexa.Count; i++)
                            {
                                string seperator = i >= splittedHexa.Count - 1 ? "" : " + ";
                                solution += Convert.ToInt32(splittedHexa[i], 16) + " * 16^" + ((splittedHexa.Count - 1) - i) + seperator;
                            }
                            solution += "<br>Step 2: Perform the calculations:<br>";
                            for (int i = 0; i < splittedHexa.Count; i++)
                            {
                                string seperator = i >= splittedHexa.Count - 1 ? " = " + toAnswer + "<br>" : " + ";
                                double answer = Math.Pow(16, (splittedHexa.Count - 1) - i) * Convert.ToInt32(splittedHexa[i], 16);
                                solution += answer + seperator;
                            }
                            solution += "Therefore, the hexadecimal number " + fromAnswer + " is equivalent to the decimal number " + toAnswer + ".";
                            break;
                    }
                    break;
            }

            return solution;
        }

        private static List<string> SplitString(string input, int groupLength)
        {
            List<string> groups = new List<string>();

            while (input.Length > groupLength)
            {
                string group = input.Substring(input.Length - groupLength);
                groups.Insert(0, group);
                input = input.Remove(input.Length - groupLength);
            }

            groups.Insert(0, input);

            return groups;
        }
    }
}