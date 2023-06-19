using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Others
    {
        private Random random;
        private string[] phrases, onesDigit, tensDigit, teensDigit;
        private int minlength, maxlength, sayMin, sayMax, perMin, perMax;

        public Others(Random random, int level)
        {
            this.random = random;

            phrases = new string[]
            {
                "5 decimal places", "4 decimal places", "3 decimal places", "2 decimal places", "1 decimal place", "the nearest whole number", "the 10's digit", "the 100's digit", "the 1000's digit", "the 10000's digit", "the 100000's digit"
            };

            onesDigit = new string[] {
                "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
            };
            tensDigit = new string[] {
                "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };
            teensDigit = new string[] {
                "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            if (level <= 5)
            {
                minlength = 2;
                maxlength = 8;
                sayMin = 1;
                sayMax = 8;
                perMin = 2;
                perMax = 4;
            }
            else if (level > 5 && level <= 10)
            {
                minlength = 2;
                maxlength = 9;
                sayMin = 1;
                sayMax = 9;
                perMin = 2;
                perMax = 4;
            }
            else if (level > 10 && level <= 20)
            {
                minlength = 1;
                maxlength = 9;
                sayMin = 1;
                sayMax = 10;
                perMin = 2;
                perMax = 4;
            }
            else if (level > 20 && level <= 50)
            {
                minlength = 1;
                maxlength = 10;
                sayMin = 1;
                sayMax = 11;
                perMin = 2;
                perMax = 5;
            }
            else if (level > 50 && level <= 100)
            {
                minlength = 0;
                maxlength = 10;
                sayMin = 1;
                sayMax = 12;
                perMin = 2;
                perMax = 5;
            }
            else
            {
                minlength = 0;
                maxlength = 11;
                sayMin = 1;
                sayMax = 13;
                perMin = 2;
                perMax = 5;
            }
        }

        public List<string> GetComponent()
        {
            int randomTopic = random.Next(0, 3);

            string answer = string.Empty;
            string solution = string.Empty;
            string question = string.Empty;

            switch (randomTopic)
            {
                case 0: // Round
                    int roundingIndex = random.Next(minlength, maxlength);
                    int numberAmount = random.Next(roundingIndex + 1, 11);
                    double power = Math.Pow(10, numberAmount - 5);
                    int roundAmount = random.Next(-2, roundingIndex - 1);
                    if (roundAmount > 5) roundAmount = 5;
                    double number = Math.Round(random.NextDouble() * power, 5 - roundAmount);

                    int digitNumber = 0;
                    int precedentNumber = 0;
                    if (roundingIndex <= 5)
                    {
                        int multiplier = (int)Math.Pow(10, 5 - roundingIndex);
                        int multiplier2 = (int)Math.Pow(10, (5 - roundingIndex) + 1);
                        digitNumber = (int)((number * multiplier) % 10);
                        precedentNumber = (int)((number * multiplier2) % 10);
                        solution = "Identify the digit present in " + phrases[roundingIndex] + ": " + digitNumber + "<br>Identify the next smallest place: " + precedentNumber + "<br>";
                        answer = (Math.Round(number, 5 - roundingIndex)).ToString();
                    }
                    else
                    {
                        int rounder = (int)Math.Pow(10, roundingIndex - 5);
                        int rounder2 = (int)Math.Pow(10, (roundingIndex - 5) - 1);
                        digitNumber = (int)((number / rounder) % 10);
                        precedentNumber = (int)((number / rounder2) % 10);
                        solution = "Identify the digit present in " + phrases[roundingIndex] + ": " + digitNumber + "<br>Identify the next smallest place: " + precedentNumber + "<br>";
                        answer = ((int)Math.Round(number / rounder) * rounder).ToString();
                    }
                    if (precedentNumber > 5)
                    {
                        solution += "Since the digit in the smallest place is more than 5, a round up has to be done and also the digit will be change to " + (digitNumber + 1) + ".";
                    }
                    else
                    {
                        solution += "Since the digit in the smallest place is less than 5, a round down has to be done and also the digit remains unchanged.";
                    }
                    solution += "<br>Every other digit from the right becomes zero.<br>So the final number is " + answer + ".";
                    if (Equals(answer, "0"))
                    {
                        return GetComponent();
                    }
                    question = "Round " + number + " to " + phrases[roundingIndex] + ".";
                    break;
                case 1: // Say
                    int digits = random.Next(sayMin, sayMax);
                    long randomNumber = LongRandom(Power(10, digits - 1), Power(10, digits), random);
                    string numWithCommas = randomNumber.ToString("N0");
                    question = "Write " + numWithCommas + " in words.";
                    string[] say = Say(randomNumber);
                    answer = say[0];
                    solution = say[1];
                    break;
                case 2: // Percent
                    int digitsPercent = random.Next(perMin, perMax);
                    double[] result = GenerateNumberAndAnswer(digitsPercent);
                    double randomNumberWithin = result[0];
                    double randomNumberPercent = result[2];
                    question = "Find the percentage of " + randomNumberWithin + " within " + randomNumberPercent + ".";
                    answer = result[1] + "%";
                    solution = "Percentage = (" + randomNumberWithin + " / " + randomNumberPercent + ") * 100 = " + answer;
                    break;
            }


            return new List<string>() { question, solution, answer };
        }

        private string[] Say(long number)
        {
            string numberString = number.ToString();
            string numberLetter = "";
            string solution = "";
            if (number == 0)
            {
                numberLetter = "zero";
            }
            else
            {
                for (int i = numberString.Length - 1; i >= 0; i--)
                {
                    int checkIndex = (numberString.Length - 1) - i;
                    int index = int.Parse(numberString[i].ToString());
                    switch (checkIndex % 3)
                    {
                        case 0:
                            string thousands = " ";
                            if (checkIndex > 0)
                            {
                                string temp = numberLetter.Trim();
                                solution += "Combine them altogether " + temp + ".<br>";
                            }
                            switch (checkIndex)
                            {
                                case 3:
                                    thousands = CheckThousands(numberString, checkIndex, 7, " thousand ");
                                    break;
                                case 6:
                                    thousands = CheckThousands(numberString, checkIndex, 10, " million ");
                                    break;
                                case 9:
                                    thousands = CheckThousands(numberString, checkIndex, 13, " billion ");
                                    break;
                                case 12:
                                    thousands = CheckThousands(numberString, checkIndex, 16, " trillion ");
                                    break;
                            }
                            if (i - 1 >= 0)
                            {
                                if (numberString[i - 1] != '1')
                                {
                                    numberLetter = onesDigit[index] + thousands + numberLetter;
                                    if (numberString[i] != '0')
                                        solution += "Write " + numberString[i] + " as " + onesDigit[index] + ".<br>";
                                }
                                else
                                {
                                    numberLetter = teensDigit[index] + thousands + numberLetter;
                                    solution += "Write " + numberString[i - 1] + numberString[i] + " as " + teensDigit[index] + ".<br>";
                                }
                            }
                            else
                            {
                                numberLetter = onesDigit[index] + thousands + numberLetter;
                                if (numberString[i] != '0')
                                    solution += "Write " + numberString[i] + " as " + onesDigit[index] + ".<br>";
                            }
                            break;
                        case 1:
                            if (numberString[i] != '1' && numberString[i] != '0')
                            {
                                if (numberString[i + 1] != '0')
                                {
                                    numberLetter = tensDigit[index] + "-" + numberLetter;
                                    solution += "Write " + numberString[i] + numberString[i + 1] + " as " + tensDigit[index] + "-" + onesDigit[int.Parse(numberString[i + 1].ToString())] + ".<br>";
                                }
                                else
                                {
                                    numberLetter = tensDigit[index] + numberLetter;
                                    solution += "Write " + numberString[i] + numberString[i + 1] + " as " + tensDigit[index] + ".<br>";
                                }
                            }
                            break;
                        case 2:
                            if (numberString[i] != '0')
                            {
                                if (numberString[i + 1] != '0' || numberString[i + 2] != '0')
                                {
                                    numberLetter = onesDigit[index] + " hundred " + numberLetter;
                                }
                                else
                                {
                                    numberLetter = onesDigit[index] + " hundred" + numberLetter;
                                }
                                solution += "Write " + numberString[i] + " as " + onesDigit[index] + " hundred.<br>";
                            }
                            break;
                    }
                }
            }

            string trimmedPhrase = numberLetter.Trim();
            solution += "Combine them altogether " + trimmedPhrase + ".";

            return new string[] { trimmedPhrase, solution };
        }

        private static string CheckThousands(string numberString, int index, int length, string name)
        {
            if (numberString.Length >= length)
            {
                if (!(numberString[index] == '0' && numberString[index + 1] == '0' && numberString[index + 2] == '0'))
                {
                    return name;
                }
            }
            else
            {
                return name;
            }
            return "";
        }

        private double[] GenerateNumberAndAnswer(int digitsPercent)
        {
            int randomNumberPercent = random.Next((int)Math.Pow(10, digitsPercent - 1), (int)Math.Pow(10, digitsPercent));
            int number = random.Next(randomNumberPercent / 100, randomNumberPercent);
            double answer = ((double)number / randomNumberPercent) * 100;
            string answerString = answer.ToString();
            int decimalPlaces = answerString.Length - answerString.IndexOf('.') - 1;
            if (decimalPlaces > 2)
            {
                return GenerateNumberAndAnswer(digitsPercent);
            }
            return new double[] { number, answer, randomNumberPercent };
        }

        private long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        private long Power(int baseNumber, int exponent)
        {
            long result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result *= baseNumber;
            }

            return result;
        }
    }
}