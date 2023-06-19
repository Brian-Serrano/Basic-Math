using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Area
    {
        private Random random;
        private string[,] measurements;
        private int minValue, maxValue;

        public Area(Random random, int level)
        {
            this.random = random;

            measurements = new string[,]
            {
                { "meters", "m" }, { "kilometers", "km" }, { "centimeters", "cm" }, { "feet", "ft" }, { "inches", "in" }
            };

            if (level <= 5)
            {
                minValue = 5;
                maxValue = 30;
            }
            else if (level > 5 && level <= 10)
            {
                minValue = 10;
                maxValue = 50;
            }
            else if (level > 10 && level <= 20)
            {
                minValue = 20;
                maxValue = 100;
            }
            else if (level > 20 && level <= 50)
            {
                minValue = 50;
                maxValue = 150;
            }
            else if (level > 50 && level <= 100)
            {
                minValue = 100;
                maxValue = 300;
            }
            else
            {
                minValue = 200;
                maxValue = 500;
            }
        }

        public List<string> GetComponent()
        {
            int randomShape = random.Next(0, 11);
            int randomMeasurement = random.Next(0, measurements.GetLength(0));
            string question = string.Empty;
            string solution = "Use the following formula:<br>";
            double answer = 0;
            switch (randomShape)
            {
                case 0: // Square
                    int squareSide = random.Next(minValue, maxValue);
                    question = "Find the area of square in " + measurements[randomMeasurement, 0] + " where all the sides are " + squareSide + measurements[randomMeasurement, 1] + ".";
                    answer = Square(squareSide);
                    solution += "Area of a square = side length * side length<br>Area = " + squareSide + " * " + squareSide + " = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 1: // Rectangle
                    int lengthRect = random.Next(minValue, maxValue);
                    int widthRect = random.Next(minValue, maxValue);
                    question = "Find the area of rectangle in " + measurements[randomMeasurement, 0] + " where the length is " + lengthRect + measurements[randomMeasurement, 1] + " and the height is " + widthRect + measurements[randomMeasurement, 1] + ".";
                    answer = Rectangle(lengthRect, widthRect);
                    solution += "Area of a rectangle = length * width<br>Area = " + lengthRect + " * " + widthRect + " = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 2: // Right Triangle
                    int baseRight = random.Next(minValue, maxValue);
                    int heightRight = random.Next(minValue, maxValue);
                    question = "Find the area of right triangle in " + measurements[randomMeasurement, 0] + " where the base is " + baseRight + measurements[randomMeasurement, 1] + " and the height is " + heightRight + measurements[randomMeasurement, 1] + ".";
                    answer = RightTriangle(baseRight, heightRight);
                    solution += "Area of a right triangle = (base * height) / 2<br>Area = (" + baseRight + " * " + heightRight + ") / 2 = " + (baseRight * heightRight) + " / 2 = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 3: // Equilateral Triangle
                    int sideEqui = random.Next(minValue, maxValue);
                    question = "Find the area of equilateral triangle in " + measurements[randomMeasurement, 0] + " where all the sides are " + sideEqui + measurements[randomMeasurement, 1] + ". Round your answer to the nearest whole number.";
                    answer = Math.Round(EquilateralTriangle(sideEqui));
                    solution += "Area of an equilateral triangle = (side length^2 * √3) / 4<br>Area = (" + sideEqui + "^2 * √3) / 4 = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 4: // Isosceles or Scalene Triangle
                    int side1Sca = random.Next(minValue, maxValue);
                    int side2Sca = random.Next(minValue, maxValue);
                    int side3Sca = random.Next(minValue, maxValue);
                    question = "Find the area of scalene triangle in " + measurements[randomMeasurement, 0] + " where the sides are " + side1Sca + measurements[randomMeasurement, 1] + ", " + side2Sca + measurements[randomMeasurement, 1] + " and " + side3Sca + measurements[randomMeasurement, 1] + ". Round your answer to the nearest whole number.";
                    answer = Math.Round(ScaleneTriangle(side1Sca, side2Sca, side3Sca));
                    double s = (double)(side1Sca + side2Sca + side3Sca) / 3;
                    solution += "Area of a scalene triangle = √s(s − side A)(s − side B)(s − side C)<br>Where: s = (" + side1Sca + " + " + side2Sca + " + " + side3Sca + ") / 3\nArea = √" + s + "(" + s + " - " + side1Sca + ")(" + s + " - " + side2Sca + ")(" + s + " - " + side3Sca + ") = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 5: // Circle
                    int radius = random.Next(minValue, maxValue);
                    question = "Find the area of circle in " + measurements[randomMeasurement, 0] + " where the radius is " + radius + measurements[randomMeasurement, 1] + ".";
                    answer = Circle(radius);
                    solution += "A = πr^2<br>A = 3.14159 * " + radius + "^2 = 3.14159 * " + Math.Pow(radius, 2) + " = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 6: // Trapezoid
                    int base1Trap = random.Next(minValue, maxValue);
                    int base2Trap = random.Next(minValue, maxValue);
                    int heightTrap = random.Next(minValue, maxValue);
                    question = "Find the area of trapezoid in " + measurements[randomMeasurement, 0] + " where the bases are " + base1Trap + measurements[randomMeasurement, 1] + " and " + base2Trap + measurements[randomMeasurement, 1] + ", and the height is " + heightTrap + measurements[randomMeasurement, 1] + ".";
                    answer = Trapezoid(base1Trap, base2Trap, heightTrap);
                    solution += "Area of a trapezoid = (base1 + base2) * height / 2<br>Area = (" + base1Trap + " + " + base2Trap + ") * " + heightTrap + " / 2 = " + (base1Trap + base2Trap) + " * " + heightTrap + " / 2 = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 7: // Parallelogram
                    int basePara = random.Next(minValue, maxValue);
                    int heightPara = random.Next(minValue, maxValue);
                    question = "Find the area of parallelogram in " + measurements[randomMeasurement, 0] + " where the base is " + basePara + measurements[randomMeasurement, 1] + " and the height is " + heightPara + measurements[randomMeasurement, 1] + ".";
                    answer = Parallelogram(basePara, heightPara);
                    solution += "Area of a parallelogram = base * height<br>Area = " + basePara + " * " + heightPara + " = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 8: // Regular Pentagon
                    int sidePentagon = random.Next(minValue, maxValue);
                    question = "Find the area of regular pentagon in " + measurements[randomMeasurement, 0] + " where all the sides are " + sidePentagon + measurements[randomMeasurement, 1] + ". Round your answer to the nearest whole number.";
                    answer = Math.Round(Pentagon(sidePentagon));
                    solution += "Area of a regular pentagon = (s^2 * sqrt(5 * (5 + 2 * sqrt(5)))) / 4<br>Area = (" + sidePentagon + "^2 * sqrt(5 * (5 + 2 * sqrt(5)))) / 4 = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 9: // Regular Hexagon
                    int sideHexagon = random.Next(minValue, maxValue);
                    question = "Find the area of regular hexagon in " + measurements[randomMeasurement, 0] + " where all the sides are " + sideHexagon + measurements[randomMeasurement, 1] + ". Round your answer to the nearest whole number.";
                    answer = Math.Round(Hexagon(sideHexagon));
                    solution += "Area of a regular hexagon = (3 * sqrt(3) * s^2) / 2<br>Area = (3 * sqrt(3) * " + sideHexagon + "^2) / 2 = " + ((3 * Math.Pow(sideHexagon, 2)) / 2) + " * sqrt(3) = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
                case 10: // Regular Octagon
                    int sideOctagon = random.Next(minValue, maxValue);
                    question = "Find the area of regular octagon in " + measurements[randomMeasurement, 0] + " where all the sides are " + sideOctagon + measurements[randomMeasurement, 1] + ". Round your answer to the nearest whole number.";
                    answer = Math.Round(Octagon(sideOctagon));
                    solution += "Area of a regular octagon = 2 * (1 + sqrt(2)) * s^2<br>2 * (1 + sqrt(2)) * " + sideOctagon + "^2 = " + (2 * Math.Pow(sideOctagon, 2)) + " * (1 + sqrt(2)) = " + answer + " square " + measurements[randomMeasurement, 0];
                    break;
            }

            return new List<string>() { question, solution, answer.ToString() };
        }

        private static double Square(double s) => s * s;

        private static double Rectangle(double l, double w) => l * w;

        private static double RightTriangle(double b, double h) => 0.5 * b * h;

        private static double EquilateralTriangle(double s) => (Math.Sqrt(3) / 4) * Math.Pow(s, 2);

        private static double ScaleneTriangle(double side1, double side2, double side3)
        {
            double s = (side1 + side2 + side3) / 2;
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }

        private static double Circle(double r) => 3.14159 * Math.Pow(r, 2);

        private static double Trapezoid(double b1, double b2, double h) => ((b1 + b2) / 2) * h;

        private static double Parallelogram(double b, double h) => b * h;

        private static double Pentagon(double side) => (1.0 / 4.0) * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * Math.Pow(side, 2);

        private static double Hexagon(double side) => (3 * Math.Sqrt(3)) / 2 * Math.Pow(side, 2);

        private static double Octagon(double side) => 2 * (1 + Math.Sqrt(2)) * Math.Pow(side, 2);
    }
}