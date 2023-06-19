using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Perimeter
    {
        private Random random;
        private string[,] measurements;
        private int minValue, maxValue;

        public Perimeter(Random random, int level)
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
                    int sideSquare = random.Next(minValue, maxValue);
                    question = "Find the perimeter of square in " + measurements[randomMeasurement, 0] + " where all the sides are " + sideSquare + measurements[randomMeasurement, 1] + ".";
                    answer = Square(sideSquare);
                    solution += "Perimeter of a square = 4 * side length<br>Perimeter = 4 * " + sideSquare + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 1: // Rectangle
                    int lengthRect = random.Next(minValue, maxValue);
                    int heightRect = random.Next(minValue, maxValue);
                    question = "Find the perimeter of rectangle in " + measurements[randomMeasurement, 0] + " where the length is " + lengthRect + measurements[randomMeasurement, 1] + " and the height is " + heightRect + measurements[randomMeasurement, 1] + ".";
                    answer = Rectangle(lengthRect, heightRect);
                    solution += "Perimeter of a rectangle = 2 * (length + width)<br>Perimeter = 2 * (" + lengthRect + " + " + heightRect + ") = 2 * " + (lengthRect + heightRect) + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 2: // Right Triangle
                    int side1Right = random.Next(minValue, maxValue);
                    int side2Right = random.Next(minValue, maxValue);
                    int side3Right = random.Next(minValue, maxValue);
                    question = "Find the perimeter of right triangle in " + measurements[randomMeasurement, 0] + " where the sides are " + side1Right + measurements[randomMeasurement, 1] + ", " + side2Right + measurements[randomMeasurement, 1] + " and " + side3Right + measurements[randomMeasurement, 1] + ".";
                    answer = RightTriangle(side1Right, side2Right, side3Right);
                    solution += "Perimeter of a right triangle = side A + side B + side C<br>Perimeter = " + side1Right + " + " + side2Right + " + " + side3Right + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 3: // Equilateral Triangle
                    int side1Equi = random.Next(minValue, maxValue);
                    question = "Find the perimeter of equilateral triangle in " + measurements[randomMeasurement, 0] + " where all the sides are " + side1Equi + measurements[randomMeasurement, 1] + ".";
                    answer = EquilateralTriangle(side1Equi);
                    solution += "Perimeter of an equilateral triangle = 3 * side length<br>Perimeter = 3 * " + side1Equi + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 4: // Isosceles or Scalene Triangle
                    int side1Sca = random.Next(minValue, maxValue);
                    int side2Sca = random.Next(minValue, maxValue);
                    int side3Sca = random.Next(minValue, maxValue);
                    question = "Find the perimeter of scalene triangle in " + measurements[randomMeasurement, 0] + " where the sides are " + side1Sca + measurements[randomMeasurement, 1] + ", " + side2Sca + measurements[randomMeasurement, 1] + " and " + side3Sca + measurements[randomMeasurement, 1] + ".";
                    answer = ScaleneTriangle(side1Sca, side2Sca, side3Sca);
                    solution += "Perimeter of an isosceles or scalene triangle = side A + side B + side C<br>Perimeter = " + side1Sca + " + " + side2Sca + " + " + side3Sca + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 5: // Circle
                    int radius = random.Next(minValue, maxValue);
                    question = "Find the circumference of circle in " + measurements[randomMeasurement, 0] + " where the radius is " + radius + measurements[randomMeasurement, 1] + ".";
                    answer = Circle(radius);
                    solution += "C = 2πr<br>C = 2 * 3.14159 * " + radius + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 6: // Trapezoid
                    int base1Trap = random.Next(minValue, maxValue);
                    int base2Trap = random.Next(minValue, maxValue);
                    int leg1Trap = random.Next(minValue, maxValue);
                    int leg2Trap = random.Next(minValue, maxValue);
                    question = "Find the perimeter of trapezoid in " + measurements[randomMeasurement, 0] + " where the bases are " + base1Trap + measurements[randomMeasurement, 1] + " and " + base2Trap + measurements[randomMeasurement, 1] + ", and the legs are " + leg1Trap + measurements[randomMeasurement, 1] + " and " + leg2Trap + measurements[randomMeasurement, 1] + ".";
                    answer = Trapezoid(base1Trap, base2Trap, leg1Trap, leg2Trap);
                    solution += "Perimeter of a trapezoid = side A + side B + side C + side D<br>Perimeter = " + base1Trap + " + " + base2Trap + " + " + leg1Trap + " + " + leg2Trap + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 7: // Parallelogram
                    int basePara = random.Next(minValue, maxValue);
                    int heightPara = random.Next(minValue, maxValue);
                    question = "Find the perimeter of parallelogram in " + measurements[randomMeasurement, 0] + " where the base is " + basePara + measurements[randomMeasurement, 1] + " and the height is " + heightPara + measurements[randomMeasurement, 1] + ".";
                    answer = Parallelogram(basePara, heightPara);
                    solution += "Perimeter of a parallelogram = 2 * (base + height)<br>Perimeter = 2 * (" + basePara + " + " + heightPara + ") = 2 * " + (basePara + heightPara) + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 8: // Regular Pentagon
                    int sidePentagon = random.Next(minValue, maxValue);
                    question = "Find the perimeter of regular pentagon in " + measurements[randomMeasurement, 0] + " where all the sides are " + sidePentagon + measurements[randomMeasurement, 1] + ".";
                    answer = Pentagon(sidePentagon);
                    solution += "Perimeter of a regular pentagon = 5 * side length<br>Perimeter = 5 * " + sidePentagon + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 9: // Regular Hexagon
                    int sideHexagon = random.Next(minValue, maxValue);
                    question = "Find the perimeter of regular hexagon in " + measurements[randomMeasurement, 0] + " where all the sides are " + sideHexagon + measurements[randomMeasurement, 1] + ".";
                    answer = Hexagon(sideHexagon);
                    solution += "Perimeter of a regular hexagon = 6 * side length<br>Perimeter = 6 * " + sideHexagon + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
                case 10: // Regular Octagon
                    int sideOctagon = random.Next(minValue, maxValue);
                    question = "Find the perimeter of regular octagon in " + measurements[randomMeasurement, 0] + " where all the sides are " + sideOctagon + measurements[randomMeasurement, 1] + ".";
                    answer = Octagon(sideOctagon);
                    solution += "Perimeter of a regular octagon = 8 * side length<br>Perimeter = 8 * " + sideOctagon + " = " + answer + " " + measurements[randomMeasurement, 0];
                    break;
            }

            return new List<string>() { question, solution, answer.ToString() };
        }

        private static double Square(double s) => 4 * s;

        private static double Rectangle(double l, double w) => 2 * (l + w);

        private static double RightTriangle(double s1, double s2, double s3) => s1 + s2 + s3;

        private static double EquilateralTriangle(double s) => 3 * s;

        private static double ScaleneTriangle(double s1, double s2, double s3) => s1 + s2 + s3;

        private static double Circle(double r) => 2 * 3.14159 * r;

        private static double Trapezoid(double b1, double b2, double l1, double l2) => b1 + b2 + l1 + l2;

        private static double Parallelogram(double b, double h) => 2 * (b + h);

        private static double Pentagon(double side) => 5 * side;

        private static double Hexagon(double side) => 6 * side;

        private static double Octagon(double side) => 8 * side;
    }
}