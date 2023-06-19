using Advance_Web_Programming_Project.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Statistics
    {
        private Random random;
        private int[] difficultyChances; // 12 length

        public Statistics(Random random, int level)
        {
            this.random = random;

            if (level <= 5)
            {
                difficultyChances = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 2 };
            }
            else if (level > 5 && level <= 10)
            {
                difficultyChances = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2 };
            }
            else if (level > 10 && level <= 20)
            {
                difficultyChances = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2 };
            }
            else if (level > 20 && level <= 50)
            {
                difficultyChances = new int[] { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
            }
            else if (level > 50 && level <= 100)
            {
                difficultyChances = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2, 2, 2, 2 };
            }
            else
            {
                difficultyChances = new int[] { 0, 0, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 };
            }
        }

        public List<string> GetComponent()
        {
            int randomTopic = difficultyChances[random.Next(0, 12)];
            string question = string.Empty;
            string solution = string.Empty;
            string answer = string.Empty;

            switch (randomTopic)
            {
                case 0: // Measures of Central Tendency
                    int randomTendency = random.Next(0, 3);
                    int setAmount = random.Next(5, 10);
                    int numberPusher = random.Next(1, 70);

                    switch (randomTendency)
                    {
                        case 0: // Mean
                            string[] mean = ProcessMean(setAmount, numberPusher, 0);
                            question = mean[0];
                            solution = mean[1];
                            answer = mean[2];
                            break;
                        case 1: // Median
                            List<int> numbersMedian = new List<int>();
                            for (int i = 0; i < setAmount; i++)
                            {
                                numbersMedian.Add(random.Next(10, 30) + numberPusher);
                            }
                            question = "Find the median of the following data set: " + string.Join(", ", numbersMedian);
                            string[] res2 = MedianAnswerAndSolution(numbersMedian);
                            solution = res2[0];
                            answer = res2[1];
                            break;
                        case 2: // Mode
                            List<int> numbersMode = new List<int>();
                            for (int i = 0; i < setAmount; i++)
                            {
                                numbersMode.Add(random.Next(10, 30) + numberPusher);
                            }
                            numbersMode.Insert(random.Next(0, numbersMode.Count), numbersMode[random.Next(0, numbersMode.Count)]);
                            question = "Find the mode of the following data set: " + string.Join(", ", numbersMode);
                            string[] res3 = ModeAnswerAndSolution(numbersMode);
                            solution = res3[0];
                            answer = res3[1];
                            break;
                    }
                    break;
                case 1: // Measures of Variability
                    int randomVariability = random.Next(0, 3);
                    int setAmountV = random.Next(5, 10);
                    int numberPusherV = random.Next(1, 70);

                    switch (randomVariability)
                    {
                        case 0: // Range
                            List<int> numbersRange = new List<int>();
                            for (int i = 0; i < setAmountV; i++)
                            {
                                numbersRange.Add(random.Next(10, 30) + numberPusherV);
                            }
                            question = "Find the range of the following data set: " + string.Join(", ", numbersRange);
                            numbersRange.Sort();
                            answer = (numbersRange[numbersRange.Count - 1] - numbersRange[0]).ToString();
                            solution = "Range = " + numbersRange[numbersRange.Count - 1] + " - " + numbersRange[0] + " = " + answer;
                            break;
                        case 1: // Variance
                            string[] variance = ProcessMean(setAmountV, numberPusherV, 1);
                            question = variance[0];
                            solution = variance[1];
                            answer = variance[2];
                            break;
                        case 2: // Standard Deviation
                            string[] sd = ProcessMean(setAmountV, numberPusherV, 2);
                            question = sd[0];
                            solution = sd[1];
                            answer = sd[2];
                            break;
                    }
                    break;
                case 2: // Probability Distribution
                    int randomDistribution = random.Next(0, 4);

                    switch (randomDistribution)
                    {
                        case 0: // Binomial
                            int trials = random.Next(5, 15);
                            int success = random.Next(2, trials);
                            int randInterval = random.Next(1, 4);
                            double probabilitySuccess = Math.Round(random.NextDouble() * 0.8 + 0.1, 2);

                            string[] binomial;

                            switch (randInterval)
                            {
                                case 1:
                                    question = "Find " + GetProbabilityString(randInterval, success) + " given number of trials = " + trials + " and probability of success = " + probabilitySuccess + ". Round your answer to 4 decimal places.";
                                    binomial = BinomialAnswerAndSolution(randInterval, trials, success, probabilitySuccess, 1 - probabilitySuccess);
                                    break;
                                case 2:
                                    question = "Find " + GetProbabilityString(randInterval, success) + " given number of trials = " + trials + " and probability of success = " + probabilitySuccess + ". Round your answer to 4 decimal places.";
                                    binomial = BinomialAnswerAndSolution(randInterval, trials, success, probabilitySuccess, 1 - probabilitySuccess);
                                    break;
                                case 3:
                                    question = "Find " + GetProbabilityString(randInterval, success) + " given number of trials = " + trials + " and probability of success = " + probabilitySuccess + ". Round your answer to 4 decimal places.";
                                    binomial = BinomialAnswerAndSolution(randInterval, trials, success, probabilitySuccess, 1 - probabilitySuccess);
                                    break;
                                default:
                                    question = "";
                                    binomial = new string[2];
                                    break;
                            }
                            solution = binomial[0];
                            answer = binomial[1];
                            break;
                        case 1: // Poisson
                            int events = random.Next(2, 15);
                            int mean = random.Next(2, 15);
                            int interval = random.Next(1, 4);

                            string[] poisson;

                            switch (interval)
                            {
                                case 1:
                                    question = "Find " + GetProbabilityString(interval, events) + " given mean = " + mean + ". Round your answer to 4 decimal places.";
                                    poisson = PoissonAnswerAndSolution(interval, events, mean);
                                    break;
                                case 2:
                                    question = "Find " + GetProbabilityString(interval, events) + " given mean = " + mean + ". Round your answer to 4 decimal places.";
                                    poisson = PoissonAnswerAndSolution(interval, events, mean);
                                    break;
                                case 3:
                                    question = "Find " + GetProbabilityString(interval, events) + " given mean = " + mean + ". Round your answer to 4 decimal places.";
                                    poisson = PoissonAnswerAndSolution(interval, events, mean);
                                    break;
                                default:
                                    question = "";
                                    poisson = new string[2];
                                    break;
                            }
                            solution = poisson[0];
                            answer = poisson[1];
                            break;
                        case 2: // Normal
                            int meanNormal = random.Next(30, 90);
                            int standardDeviation = random.Next(10, 20);
                            int randomInt = random.Next(0, 3);

                            string[] normal;

                            switch (randomInt)
                            {
                                case 0:
                                    int[] x2 = GenerateTwoUniqueNumbers(-30, 30, meanNormal);
                                    question = "Find " + GetProbabilityString(randomInt, x2[0], x2[1]) + " given mean = " + meanNormal + " and standard deviation = " + standardDeviation + ". Round your answer to 4 decimal places.";
                                    normal = NormalAnswerAndSolution(randomInt, meanNormal, standardDeviation, x2[0], x2[1]);
                                    break;
                                case 1:
                                    int x = meanNormal + random.Next(-30, 30);
                                    question = "Find " + GetProbabilityString(randomInt, x) + " given mean = " + meanNormal + " and standard deviation = " + standardDeviation + ". Round your answer to 4 decimal places.";
                                    normal = NormalAnswerAndSolution(randomInt, meanNormal, standardDeviation, x);
                                    break;
                                case 2:
                                    int x1 = meanNormal + random.Next(-30, 30);
                                    question = "Find " + GetProbabilityString(randomInt, x1) + " given mean = " + meanNormal + " and standard deviation = " + standardDeviation + ". Round your answer to 4 decimal places.";
                                    normal = NormalAnswerAndSolution(randomInt, meanNormal, standardDeviation, x1);
                                    break;
                                default:
                                    question = "";
                                    normal = new string[2];
                                    break;
                            }
                            solution = normal[0];
                            answer = normal[1];
                            break;
                        case 3: // Exponential
                            double rateParameter = Math.Round(random.NextDouble() * 0.8 + 0.1, 2);
                            int randomInterval = random.Next(0, 3);

                            string[] exponential;

                            switch (randomInterval)
                            {
                                case 0:
                                    int[] time2 = GenerateTwoUniqueNumbers(5, 15);
                                    question = "Find " + GetProbabilityString(randomInterval, time2[0], time2[1]) + " given rate parameter = " + rateParameter + ". Round your answer to 4 decimal places.";
                                    exponential = ExponentialAnswerAndSolution(randomInterval, rateParameter, time2[0], time2[1]);
                                    break;
                                case 1:
                                    int time = random.Next(5, 15);
                                    question = "Find " + GetProbabilityString(randomInterval, time) + " given rate parameter = " + rateParameter + ". Round your answer to 4 decimal places.";
                                    exponential = ExponentialAnswerAndSolution(randomInterval, rateParameter, time);
                                    break;
                                case 2:
                                    int time1 = random.Next(5, 15);
                                    question = "Find " + GetProbabilityString(randomInterval, time1) + " given rate parameter = " + rateParameter + ". Round your answer to 4 decimal places.";
                                    exponential = ExponentialAnswerAndSolution(randomInterval, rateParameter, time1);
                                    break;
                                default:
                                    question = "";
                                    exponential = new string[2];
                                    break;
                            }

                            solution = exponential[0];
                            answer = exponential[1];
                            break;
                    }
                    break;
            }

            return new List<string>() { question, solution, answer };
        }

        private string[] ProcessMean(int setAmount, int numberPusher, int id) // Recursively calls if decimal places is more than 2
        {
            string question = string.Empty;
            string solution = string.Empty;
            string answer = string.Empty;

            List<int> numbers = new List<int>();
            for (int i = 0; i < setAmount; i++)
            {
                numbers.Add(random.Next(10, 30) + numberPusher);
            }
            string[] res1 = MeanAnswerAndSolution(numbers);
            int decimalPlaces = res1[1].Length - res1[1].IndexOf('.') - 1;
            if (decimalPlaces > 2)
            {
                return ProcessMean(setAmount, numberPusher, id);
            }
            else
            {
                switch (id)
                {
                    case 0: // Mean
                        question = "Find the mean of the following data set: " + string.Join(", ", numbers);
                        solution = res1[0];
                        answer = res1[1];
                        break;
                    case 1: // Variance
                        question = "Find the variance of the following data set: " + string.Join(", ", numbers) + ". Round every result with more than 2 decimal places to 2 decimal places.";
                        string[] res = VarianceAnswerAndSolution(numbers);
                        solution = res[0];
                        answer = res[1];
                        break;
                    case 2: // Standard Deviation
                        question = "Find the standard deviation of the following data set: " + string.Join(", ", numbers) + ". Round every result with more than 2 decimal places to 2 decimal places.";
                        string[] res2 = FindStandardDeviationForVariance(VarianceAnswerAndSolution(numbers));
                        solution = res2[0];
                        answer = res2[1];
                        break;
                }
            }

            return new string[] { question, solution, answer };
        }

        private static string GetProbabilityString(int interval, int num1, int num2 = 0)
        {
            string[] probability = new string[]
            {
                "P(" + num1 + " ≤ X ≤ " + num2 + ")", "P(X ≥ " + num1 + ")", "P(X ≤ " + num1 + ")", "P(X = " + num1 + ")"
            };

            return probability[interval];
        }

        private int[] GenerateTwoUniqueNumbers(int min, int max, int pusher = 0)
        {
            int num1 = random.Next(min, max);
            int num2 = random.Next(min, max);

            while (num2 == num1)
            {
                num2 = random.Next(min, max);
            }

            int[] numbers = new int[] { num1 + pusher, num2 + pusher };
            Array.Sort(numbers);
            return numbers;
        }

        private static string[] MeanAnswerAndSolution(List<int> numbers)
        {
            double answer = (double)numbers.Sum(x => x) / numbers.Count;
            string solution = "Mean = (" + string.Join(" + ", numbers) + ") / " + numbers.Count + " = " + answer;
            return new string[] { solution, answer.ToString() };
        }

        private static string[] MedianAnswerAndSolution(List<int> numbers)
        {
            numbers.Sort();
            double answer = 0;
            string solution = "Arrange in ascending order: " + string.Join(", ", numbers) + "<br>";
            if (numbers.Count % 2 == 0)
            {
                answer = (numbers[numbers.Count / 2] + numbers[(numbers.Count / 2) - 1]) / 2.0;
                solution += "Median = (" + numbers[(numbers.Count / 2) - 1] + " + " + numbers[numbers.Count / 2] + ") / 2 = " + answer;
            }
            else
            {
                answer = numbers[numbers.Count / 2];
                solution += "Median = " + answer;
            }
            return new string[] { solution, answer.ToString() };
        }

        private static string[] ModeAnswerAndSolution(List<int> numbers)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            foreach (int value in numbers)
            {
                if (frequencyMap.ContainsKey(value))
                    frequencyMap[value]++;
                else
                    frequencyMap[value] = 1;
            }

            int highestFrequency = frequencyMap.Values.Max();

            List<int> modes = frequencyMap.Where(kv => kv.Value == highestFrequency)
                                          .Select(kv => kv.Key)
                                          .ToList();

            string answer = string.Join(", ", modes);
            string solution = "Mode = " + answer + " (Appeared " + highestFrequency + " times)";

            return new string[] { solution, answer };
        }

        private static string[] VarianceAnswerAndSolution(List<int> numbers)
        {
            List<double> squaredDeviations = new List<double>();
            double mean = (double)numbers.Sum(x => x) / numbers.Count;
            string solution = "Step 1: Calculate the mean: Mean = " + mean + "<br>Step 2: Calculate the squared deviation of each data point from the mean:";
            for (int i = 0; i < numbers.Count; i++)
            {
                squaredDeviations.Add(Math.Round(Math.Pow(numbers[i] - mean, 2), 2));
                solution += "<br>(" + numbers[i] + " - " + mean + ")^2 = " + squaredDeviations[i];
            }
            double answer = Math.Round(squaredDeviations.Sum(x => x) / squaredDeviations.Count, 2);
            solution += "<br>Step 3: Calculate the average of the squared deviations:<br>Variance = (" + string.Join(" + ", squaredDeviations) + ") / " + squaredDeviations.Count + " = " + answer;
            return new string[] { solution, answer.ToString() };
        }

        private static string[] FindStandardDeviationForVariance(string[] varianceResult)
        {
            string temp = varianceResult[1];
            varianceResult[1] = Math.Round(Math.Sqrt(double.Parse(varianceResult[1])), 2).ToString();
            varianceResult[0] += "<br>Standard Deviation = √(" + temp + ") = " + varianceResult[1];
            return varianceResult;
        }

        private static long CalculateCombinations(int trials, int successes)
        {
            if (trials < 0 || successes < 0 || successes > trials)
                throw new ArgumentException("Invalid input");

            long numerator = Factorial(trials);
            long denominator = Factorial(successes) * Factorial(trials - successes);

            return numerator / denominator;
        }

        private static long Factorial(int n)
        {
            if (n == 0)
                return 1;

            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private static string[] BinomialAnswerAndSolution(int randomInterval, int trials, int success, double probabilitySuccess, double probabilityFailure)
        {
            string solution = string.Empty;
            double answer = 0;

            switch (randomInterval)
            {
                case 1:
                    List<double> answers = new List<double>();
                    solution = "Use the following formula:<br>";
                    for (int i = success; i <= trials; i++)
                    {
                        solution += "P(X = k) = C(n, k) * p^k * (1 - p)^(n - k)<br>P(X = " + i + ") = C(" + trials + ", " + i + ") * (" + probabilitySuccess + ")^" + i + " * (1 - " + probabilitySuccess + ")^(" + trials + " - " + i + ")<br>";
                        long combination1 = CalculateCombinations(trials, i);
                        double pk1 = Math.Pow(probabilitySuccess, i);
                        double nk1 = Math.Pow(probabilityFailure, trials - i);
                        solution += "= " + combination1 + " * " + pk1 + " * " + nk1;
                        answers.Add(Math.Round(combination1 * pk1 * nk1, 4));
                        solution += "<br>= " + answers[i - success] + "<br>";
                    }
                    answer = Math.Round(answers.Sum(x => x), 4);
                    solution += GetProbabilityString(randomInterval, success) + " = " + string.Join(" + ", answers) + " = " + answer;
                    break;
                case 2:
                    List<double> answers2 = new List<double>();
                    solution = "Use the following formula:<br>";
                    for (int i = 0; i <= success; i++)
                    {
                        solution += "P(X = k) = C(n, k) * p^k * (1 - p)^(n - k)<br>P(X = " + i + ") = C(" + trials + ", " + i + ") * (" + probabilitySuccess + ")^" + i + " * (1 - " + probabilitySuccess + ")^(" + trials + " - " + i + ")<br>";
                        long combination1 = CalculateCombinations(trials, i);
                        double pk1 = Math.Pow(probabilitySuccess, i);
                        double nk1 = Math.Pow(probabilityFailure, trials - i);
                        solution += "= " + combination1 + " * " + pk1 + " * " + nk1;
                        answers2.Add(Math.Round(combination1 * pk1 * nk1, 4));
                        solution += "<br>= " + answers2[i] + "<br>";
                    }
                    answer = Math.Round(answers2.Sum(x => x), 4);
                    solution += GetProbabilityString(randomInterval, success) + " = " + string.Join(" + ", answers2) + " = " + answer;
                    break;
                case 3:
                    solution = "Use the following formula:<br>P(X = k) = C(n, k) * p^k * (1 - p)^(n - k)<br>P(X = " + success + ") = C(" + trials + ", " + success + ") * (" + probabilitySuccess + ")^" + success + " * (1 - " + probabilitySuccess + ")^(" + trials + " - " + success + ")<br>";
                    long combination = CalculateCombinations(trials, success);
                    double pk = Math.Pow(probabilitySuccess, success);
                    double nk = Math.Pow(probabilityFailure, trials - success);
                    solution += "= " + combination + " * " + pk + " * " + nk;
                    answer = Math.Round(combination * pk * nk, 4);
                    solution += "<br>= " + answer;
                    break;
            }

            return new string[] { solution, answer.ToString() };
        }

        private static string[] PoissonAnswerAndSolution(int randomInterval, int events, int mean)
        {
            string solution = string.Empty;
            double answer = 0;

            switch (randomInterval)
            {
                case 1:
                    List<double> answers = new List<double>();
                    solution = "Use the following formula:<br>";
                    for (int i = 0; i < events; i++)
                    {
                        solution += "P(X = k) = (e^(-λ) * λ^k) / k!<br>P(X = " + i + ") = (e^(-" + mean + ") * " + mean + "^" + i + ") / " + i + "!<br>";
                        double em1 = Math.Exp(-mean);
                        double mk1 = Math.Pow(mean, i);
                        long fact1 = Factorial(i);
                        solution += "= (" + em1 + " * " + mk1 + ") / " + fact1;
                        answers.Add(Math.Round((em1 * mk1) / fact1, 4));
                        solution += "<br>= " + answers[i] + "<br>";
                    }
                    answer = Math.Round(1 - answers.Sum(x => x), 4);
                    solution += GetProbabilityString(randomInterval, events) + " = 1 - (" + string.Join(" + ", answers) + ") = " + answer;
                    break;
                case 2:
                    List<double> answers2 = new List<double>();
                    solution = "Use the following formula:<br>";
                    for (int i = 0; i <= events; i++)
                    {
                        solution += "P(X = k) = (e^(-λ) * λ^k) / k!<br>P(X = " + i + ") = (e^(-" + mean + ") * " + mean + "^" + i + ") / " + i + "!<br>";
                        double em1 = Math.Exp(-mean);
                        double mk1 = Math.Pow(mean, i);
                        long fact1 = Factorial(i);
                        solution += "= (" + em1 + " * " + mk1 + ") / " + fact1;
                        answers2.Add(Math.Round((em1 * mk1) / fact1, 4));
                        solution += "<br>= " + answers2[i] + "<br>";
                    }
                    answer = Math.Round(answers2.Sum(x => x), 4);
                    solution += GetProbabilityString(randomInterval, events) + " = " + string.Join(" + ", answers2) + " = " + answer;
                    break;
                case 3:
                    solution = "Use the following formula:<br>P(X = k) = (e^(-λ) * λ^k) / k!<br>P(X = " + events + ") = (e^(-" + mean + ") * " + mean + "^" + events + ") / " + events + "!<br>";
                    double em = Math.Exp(-mean);
                    double mk = Math.Pow(mean, events);
                    long fact = Factorial(events);
                    solution += "= (" + em + " * " + mk + ") / " + fact;
                    answer = Math.Round((em * mk) / fact, 4);
                    solution += "<br>= " + answer;
                    break;
            }

            return new string[] { solution, answer.ToString() };
        }

        private static string[] NormalAnswerAndSolution(int randomInterval, int meanNormal, int standardDeviation, int x, int x2 = 0)
        {
            string solution = string.Empty;
            double answer = 0;

            switch (randomInterval)
            {
                case 0:
                    int[] xs = new int[] { x, x2 };
                    double[] answers = new double[2];
                    for (int i = 0; i < xs.Length; i++)
                    {
                        string seperator = i == 1 ? "<br>" : "";
                        solution += seperator + "Use the following formula:<br>Z Score = (X − λ)/σ<br>Z Score = (" + xs[i] + " - " + meanNormal + ")/" + standardDeviation + "<br>";
                        double z = Math.Round((double)(xs[i] - meanNormal) / standardDeviation, 2);
                        solution += "= " + z;
                        answers[i] = NormalDistribution.GetNormalDistribution(z);
                    }
                    answer = Math.Round(answers[1] - answers[0], 4);
                    solution += "<br>Use the normal distribution table to get the answer<br>" + GetProbabilityString(randomInterval, x, x2) + " = " + answers[1] + " - " + answers[0] + " = " + answer;
                    break;
                case 1:
                    solution = "Use the following formula:<br>Z Score = (X − λ)/σ<br>Z Score = (" + x + " - " + meanNormal + ")/" + standardDeviation + "<br>";
                    double zScore = Math.Round((double)(x - meanNormal) / standardDeviation, 2);
                    solution += "= " + zScore;
                    answer = 1 - NormalDistribution.GetNormalDistribution(zScore);
                    solution += "<br>Use the normal distribution table to get the answer<br>" + GetProbabilityString(randomInterval, x) + " = " + answer;
                    break;
                case 2:
                    solution = "Use the following formula:<br>Z Score = (X − λ)/σ<br>Z Score = (" + x + " - " + meanNormal + ")/" + standardDeviation + "<br>";
                    double zScore1 = Math.Round((double)(x - meanNormal) / standardDeviation, 2);
                    solution += "= " + zScore1;
                    answer = NormalDistribution.GetNormalDistribution(zScore1);
                    solution += "<br>Use the normal distribution table to get the answer<br>" + GetProbabilityString(randomInterval, x) + " = " + answer;
                    break;
            }

            return new string[] { solution, answer.ToString() };
        }

        private static string[] ExponentialAnswerAndSolution(int randomInterval, double rateParameter, int time, int time2 = 0)
        {
            string solution = string.Empty;
            double answer = 0;

            switch (randomInterval)
            {
                case 0:
                    solution = "Use the following formula:<br>P(x1 < X < x2) = P(X < x2) − P(X < x1) = (1 - e^−μx1) − (1 - e^−μx2)<br>" + GetProbabilityString(randomInterval, time, time2) + " = (1 - e^(-" + rateParameter + ")(" + time2 + ")) - (1 - e^(-" + rateParameter + ")(" + time + "))<br>";
                    double answerT1 = 1 - Math.Round(Math.Exp(-rateParameter * time), 4);
                    double answerT2 = 1 - Math.Round(Math.Exp(-rateParameter * time2), 4);
                    answer = Math.Round(answerT2 - answerT1, 4);
                    solution += "= " + answerT2 + " - " + answerT1 + " = " + answer;
                    break;
                case 1:
                    solution = "Use the following formula:<br>P(X > x) = e^-μx<br>" + GetProbabilityString(randomInterval, time) + " = e^(-" + rateParameter + ")(" + time + ")<br>";
                    answer = Math.Round(Math.Exp(-rateParameter * time), 4);
                    solution += "= " + answer;
                    break;
                case 2:
                    solution = "Use the following formula:<br>P(X < x) = 1 - e^-μx<br>" + GetProbabilityString(randomInterval, time) + " = 1 - e^(-" + rateParameter + ")(" + time + ")<br>";
                    answer = 1 - Math.Round(Math.Exp(-rateParameter * time), 4);
                    solution += "= " + answer;
                    break;
            }

            return new string[] { solution, answer.ToString() };
        }
    }
}