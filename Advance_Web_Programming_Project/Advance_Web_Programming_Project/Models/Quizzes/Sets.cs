using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Sets
    {
        private Random random;
        private int minlength, maxlength;

        public Sets(Random random, int level)
        {
            this.random = random;

            if (level <= 5)
            {
                minlength = 2;
                maxlength = 5;
            }
            else if (level > 5 && level <= 10)
            {
                minlength = 3;
                maxlength = 6;
            }
            else if (level > 10 && level <= 20)
            {
                minlength = 3;
                maxlength = 7;
            }
            else if (level > 20 && level <= 50)
            {
                minlength = 4;
                maxlength = 8;
            }
            else if (level > 50 && level <= 100)
            {
                minlength = 4;
                maxlength = 9;
            }
            else
            {
                minlength = 5;
                maxlength = 10;
            }
        }

        public List<string> GetComponent()
        {
            int topic = random.Next(0, 6);
            string question = string.Empty;
            string answer = string.Empty;
            string solution = string.Empty;
            switch (topic)
            {
                case 0: // Union
                    List<List<int>> unionSet = new List<List<int>>()
                    {
                        new List<int>(), new List<int>(), new List<int>()
                    };
                    List<int> unionSetAmount = new List<int>()
                    {
                        random.Next(minlength, maxlength), random.Next(minlength, maxlength), random.Next(minlength, maxlength)
                    };
                    question = "Find the resulting set of A ∪ B:<br>";
                    for (int i = 0; i < unionSet.Count; i++)
                    {
                        for (int j = 0; j < unionSetAmount[i]; j++)
                        {
                            int number = GetUniqueNumber(unionSet);
                            unionSet[i].Add(number);
                        }
                    }
                    List<int> unionSetA = CombineAndSortLists(new List<List<int>>() { unionSet[0], unionSet[2] });
                    List<int> unionSetB = CombineAndSortLists(new List<List<int>>() { unionSet[1], unionSet[2] });
                    List<int> unionAnswer = CombineAndSortLists(new List<List<int>>() { unionSet[0], unionSet[1], unionSet[2] });
                    question += ExpressionBuilder(unionSetA, "A = ") + "<br>" + ExpressionBuilder(unionSetB, "B = ");
                    answer = ExpressionBuilder(unionAnswer);
                    solution += "The union of two sets A and B, denoted by A ∪ B, is the set that contains all the elements that are in either set A or set B, or in both.<br>" + answer;
                    break;
                case 1: // Intersection
                    List<List<int>> intersectionSet = new List<List<int>>()
                    {
                        new List<int>(), new List<int>(), new List<int>()
                    };
                    List<int> intersectionSetAmount = new List<int>()
                    {
                        random.Next(minlength, maxlength), random.Next(minlength, maxlength), random.Next(minlength, maxlength)
                    };
                    question = "Find the resulting set of A ∩ B:<br>";
                    for (int i = 0; i < intersectionSet.Count; i++)
                    {
                        for (int j = 0; j < intersectionSetAmount[i]; j++)
                        {
                            int number = GetUniqueNumber(intersectionSet);
                            intersectionSet[i].Add(number);
                        }
                    }
                    List<int> intersectionSetA = CombineAndSortLists(new List<List<int>>() { intersectionSet[0], intersectionSet[2] });
                    List<int> intersectionSetB = CombineAndSortLists(new List<List<int>>() { intersectionSet[1], intersectionSet[2] });
                    List<int> intersectionAnswer = CombineAndSortLists(new List<List<int>>() { intersectionSet[2] });
                    question += ExpressionBuilder(intersectionSetA, "A = ") + "<br>" + ExpressionBuilder(intersectionSetB, "B = ");
                    answer = ExpressionBuilder(intersectionAnswer);
                    solution += "The intersection of two sets A and B, denoted by A ∩ B, is the set that contains all the elements that are common to both set A and set B.<br>" + answer;
                    break;
                case 2: // Difference
                    List<List<int>> differenceSet = new List<List<int>>()
                    {
                        new List<int>(), new List<int>(), new List<int>()
                    };
                    List<int> differenceSetAmount = new List<int>()
                    {
                        random.Next(minlength, maxlength), random.Next(minlength, maxlength), random.Next(minlength, maxlength)
                    };
                    question = "Find the resulting set of A - B:<br>";
                    for (int i = 0; i < differenceSet.Count; i++)
                    {
                        for (int j = 0; j < differenceSetAmount[i]; j++)
                        {
                            int number = GetUniqueNumber(differenceSet);
                            differenceSet[i].Add(number);
                        }
                    }
                    List<int> differenceSetA = CombineAndSortLists(new List<List<int>>() { differenceSet[0], differenceSet[2] });
                    List<int> differenceSetB = CombineAndSortLists(new List<List<int>>() { differenceSet[1], differenceSet[2] });
                    List<int> differenceAnswer = CombineAndSortLists(new List<List<int>>() { differenceSet[0] });
                    question += ExpressionBuilder(differenceSetA, "A = ") + "<br>" + ExpressionBuilder(differenceSetB, "B = ");
                    answer = ExpressionBuilder(differenceAnswer);
                    solution += "The set difference of two sets A and B, denoted by A - B or A \\ B, is the set that contains all the elements that are in set A but not in set B.<br>" + answer;
                    break;
                case 3: // Complement
                    List<List<int>> complementSet = new List<List<int>>()
                    {
                        new List<int>(), new List<int>()
                    };
                    List<int> complementSetAmount = new List<int>()
                    {
                        random.Next(minlength, maxlength), random.Next(minlength, maxlength)
                    };
                    question = "Find the resulting set of A':<br>";
                    for (int i = 0; i < complementSet.Count; i++)
                    {
                        for (int j = 0; j < complementSetAmount[i]; j++)
                        {
                            int number = GetUniqueNumber(complementSet);
                            complementSet[i].Add(number);
                        }
                    }
                    List<int> universalSet = CombineAndSortLists(new List<List<int>>() { complementSet[0], complementSet[1] });
                    List<int> complementSetA = CombineAndSortLists(new List<List<int>>() { complementSet[1] });
                    List<int> complementAnswer = CombineAndSortLists(new List<List<int>>() { complementSet[0] });
                    question += ExpressionBuilder(universalSet, "U = ") + "<br>" + ExpressionBuilder(complementSetA, "A = ");
                    answer = ExpressionBuilder(complementAnswer);
                    solution += "The complement of a set A, denoted by A', is the set of all elements in the universal set that are not in set A.<br>" + answer;
                    break;
                case 4: // Cartesian Product
                    List<List<int>> cartesianSet = new List<List<int>>()
                    {
                        new List<int>(), new List<int>()
                    };
                    List<int> cartesianSetAmount = new List<int>()
                    {
                        random.Next(minlength, maxlength), random.Next(minlength, maxlength)
                    };
                    question = "Find the resulting set of A × B:<br>";
                    for (int i = 0; i < cartesianSet.Count; i++)
                    {
                        for (int j = 0; j < cartesianSetAmount[i]; j++)
                        {
                            int number = GetUniqueNumber(cartesianSet);
                            cartesianSet[i].Add(number);
                        }
                    }
                    List<int> cartesianSetA = CombineAndSortLists(new List<List<int>>() { cartesianSet[0] });
                    List<int> cartesianSetB = CombineAndSortLists(new List<List<int>>() { cartesianSet[1] });
                    question += ExpressionBuilder(cartesianSetA, "A = ") + "<br>" + ExpressionBuilder(cartesianSetB, "B = ");
                    answer = AnotherExpressionBuilder(GetCartesian(cartesianSetA, cartesianSetB));
                    solution += "The Cartesian product of two sets A and B, denoted by A × B, is the set of all ordered pairs (a, b) where a is from set A and b is from set B.<br>" + answer;
                    break;
                case 5: // Power
                    List<int> powerSet = new List<int>();
                    int powerSetAmount = random.Next(minlength, maxlength);
                    question = "Find the resulting set of P(A):<br>";
                    for (int i = 0; i < powerSetAmount; i++)
                    {
                        int number = GetUniqueNumber(new List<List<int>>() { powerSet });
                        powerSet.Add(number);
                    }
                    List<int> sortedPowerSet = CombineAndSortLists(new List<List<int>>() { powerSet });
                    question += ExpressionBuilder(sortedPowerSet, "A = ");
                    answer = AnotherExpressionBuilder(GetAllCombinations(sortedPowerSet));
                    solution += "The power set of a set A, denoted by P(A), is the set of all possible subsets of A, including the empty set and the set itself.<br>" + answer;
                    break;
            }

            return new List<string>() { question, solution, answer };
        }

        private int GetUniqueNumber(List<List<int>> numbers)
        {
            int number = random.Next(2, 40);
            foreach (List<int> list in numbers)
            {
                foreach (int n in list)
                {
                    if (n == number) return GetUniqueNumber(numbers);
                }
            }
            return number;
        }

        private static List<List<int>> GetCartesian(List<int> setA, List<int> setB)
        {
            List<List<int>> cartesian = new List<List<int>>();
            for (int i = 0; i < setA.Count; i++)
            {
                for (int j = 0; j < setB.Count; j++)
                {
                    cartesian.Add(new List<int>() { setA[i], setB[j] });
                }
            }
            return cartesian;
        }

        private static string AnotherExpressionBuilder<T>(List<List<T>> set)
        {
            string expression = "{";
            for (int i = 0; i < set.Count; i++)
            {
                expression += "{";
                if (set[i].Count != 0)
                {
                    expression += string.Join(", ", set[i]);
                }
                else
                {
                    expression += " ";
                }
                string seperator1 = i == set.Count - 1 ? "" : ", ";
                expression += "}" + seperator1;
            }
            expression += "}";
            return expression;
        }

        private static string ExpressionBuilder<T>(List<T> set, string letter = "") => letter + "{ " + string.Join(", ", set) + " }";

        private static List<T> CombineAndSortLists<T>(List<List<T>> list)
        {
            List<T> combinedList = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                combinedList.AddRange(list[i]);
            }

            combinedList.Sort();

            return combinedList;
        }

        private static List<List<int>> GetAllCombinations(List<int> nums)
        {
            List<List<int>> combinations = new List<List<int>>();
            List<int> currentCombination = new List<int>();

            GenerateCombinations(nums, 0, currentCombination, combinations);

            return combinations;
        }

        private static void GenerateCombinations(List<int> nums, int index, List<int> currentCombination, List<List<int>> combinations)
        {
            if (index == nums.Count)
            {
                combinations.Add(new List<int>(currentCombination));
                return;
            }

            currentCombination.Add(nums[index]);
            GenerateCombinations(nums, index + 1, currentCombination, combinations);

            currentCombination.RemoveAt(currentCombination.Count - 1);
            GenerateCombinations(nums, index + 1, currentCombination, combinations);
        }
    }
}