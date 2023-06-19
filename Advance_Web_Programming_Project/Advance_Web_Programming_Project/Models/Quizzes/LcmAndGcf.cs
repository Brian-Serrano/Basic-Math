using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class LcmAndGcf
    {
        private Random random;
        private int minlength, maxlength, minValue, maxValue;

        public LcmAndGcf(Random random, int level)
        {
            this.random = random;

            if (level <= 5)
            {
                minlength = 2;
                maxlength = 5;
                minValue = 2;
                maxValue = 10;
            }
            else if (level > 5 && level <= 10)
            {
                minlength = 2;
                maxlength = 6;
                minValue = 3;
                maxValue = 12;
            }
            else if (level > 10 && level <= 20)
            {
                minlength = 3;
                maxlength = 6;
                minValue = 5;
                maxValue = 15;
            }
            else if (level > 20 && level <= 50)
            {
                minlength = 3;
                maxlength = 7;
                minValue = 10;
                maxValue = 20;
            }
            else if (level > 50 && level <= 100)
            {
                minlength = 4;
                maxlength = 7;
                minValue = 15;
                maxValue = 30;
            }
            else
            {
                minlength = 4;
                maxlength = 8;
                minValue = 20;
                maxValue = 40;
            }
        }

        public List<string> GetComponent()
        {
            int type = random.Next(0, 2);
            int numberAmount = random.Next(minlength, maxlength);
            string question = string.Empty;
            string solution1 = string.Empty;
            string solution2 = string.Empty;
            int answer = 0;
            switch (type)
            {
                case 0: // GCF
                    question = "Find the greatest common factor of ";
                    solution1 += "Let's find the GCF of ";
                    solution2 += "Let's find the GCF of ";
                    List<int> gcfNum = new List<int>();
                    int multiplierGcf = random.Next(2, 20);
                    for (int i = 0; i < numberAmount; i++)
                    {
                        int number = GetUniqueNumber(gcfNum, multiplierGcf);
                        gcfNum.Add(number);
                    }
                    question += string.Join(", ", gcfNum);
                    solution1 += string.Join(", ", gcfNum) + " using the prime factorization method:<br>";
                    solution2 += string.Join(", ", gcfNum) + " using the method of listing factors:<br>";
                    for (int i = 0; i < numberAmount; i++)
                    {
                        List<int> primeFactors = GetPrimeFactors(gcfNum[i]);
                        List<int> factors = GetFactors(gcfNum[i]);
                        solution1 += "Prime factorization of " + gcfNum[i] + ": " + string.Join(" x ", primeFactors) + "<br>";
                        solution2 += "Factors of " + gcfNum[i] + ": " + string.Join(", ", factors) + "<br>";
                    }
                    answer = GCF(gcfNum);
                    List<int> answerPrimeFactors = GetPrimeFactors(answer);
                    solution1 += "To find the GCF, we take the common prime factors:<br>GCF = " + string.Join(" x ", answerPrimeFactors) + " = " + answer;
                    solution2 += "The largest common factor is " + answer + ".";
                    break;
                case 1: // LCM
                    question = "Find the least common multiple of ";
                    solution1 += "Let's find the LCM of ";
                    solution2 += "Let's find the LCM of ";
                    List<int> lcmNum = new List<int>();
                    int multiplierLcm = random.Next(2, 20);
                    for (int i = 0; i < numberAmount; i++)
                    {
                        int number = GetUniqueNumber(lcmNum, multiplierLcm);
                        lcmNum.Add(number);
                    }
                    question += string.Join(", ", lcmNum);
                    solution1 += string.Join(", ", lcmNum) + " using the prime factorization method:<br>";
                    solution2 += string.Join(", ", lcmNum) + " using the method of listing multiples:<br>";
                    answer = LCM(lcmNum);
                    for (int i = 0; i < numberAmount; i++)
                    {
                        List<int> primeFactors = GetPrimeFactors(lcmNum[i]);
                        List<int> multiples = GetMultiples(lcmNum[i], answer, 10);
                        solution1 += "Prime factorization of " + lcmNum[i] + ": " + string.Join(" x ", primeFactors) + "<br>";
                        solution2 += "Multiples of " + lcmNum[i] + ": ";
                        for (int j = 0; j < multiples.Count; j++)
                        {
                            string seperator = j == multiples.Count - 1 ? "" : ", ";
                            string number = multiples[j] == -1 ? "..., " + answer : multiples[j].ToString();
                            solution2 += number + seperator;
                        }
                        solution2 += "<br>";
                    }
                    List<int> answerPrimeNumbers = GetPrimeFactors(answer);
                    solution1 += "To find the LCM, we take the highest power of each prime factor:<br>LCM = " + string.Join(" x ", answerPrimeNumbers) + " = " + answer;
                    solution2 += "The smallest common multiple is " + answer + ".";
                    break;
            }
            question += ".";
            string solution = solution1 + "<br>" + solution2;
            return new List<string>() { question, solution, answer.ToString() };
        }

        private int GetUniqueNumber(List<int> numbers, int multiplier)
        {
            int number = random.Next(minValue, maxValue) * multiplier;
            foreach (int n in numbers)
            {
                if (n == number) return GetUniqueNumber(numbers, multiplier);
            }
            return number;
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

        private static int LCM(List<int> arr)
        {
            int result = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                result = LCM(result, arr[i]);
            }
            return result;
        }

        private static int LCM(int a, int b) => (a * b) / GCF(a, b);

        private static List<int> GetFactors(int number)
        {
            List<int> factors = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    factors.Add(i);
            }

            return factors;
        }

        private static List<int> GetPrimeFactors(int number)
        {
            List<int> primeFactors = new List<int>();

            for (int i = 2; i <= number; i++)
            {
                while (number % i == 0)
                {
                    primeFactors.Add(i);
                    number /= i;
                }
            }

            return primeFactors;
        }

        private static List<int> GetMultiples(int number, int limit, int threshold)
        {
            List<int> multiples = new List<int>();

            for (int i = number; i <= limit; i += number)
            {
                multiples.Add(i);

                if (multiples.Count > threshold)
                {
                    multiples.Add(-1);
                    break;
                }
            }

            return multiples;
        }
    }
}