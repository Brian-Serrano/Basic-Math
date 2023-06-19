using System;
using System.Collections.Generic;

namespace Advance_Web_Programming_Project.Models.Quizzes
{
    public class Volume
    {
        private Random random;
        private string[,] measurements;
        private int minValue, maxValue, randomShape, randomMeasurement;

        public Volume(Random random, int level)
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

            randomShape = random.Next(0, 6);
            randomMeasurement = random.Next(0, measurements.GetLength(0));
        }

        public List<string> GetComponent()
        {
            string question = string.Empty;
            string solution = "Use the following formula:<br>";
            double answer = 0;
            switch (randomShape)
            {
                case 0: // Cube
                    int cubeSide = random.Next(minValue, maxValue);
                    question = "Find the volume of cube in " + measurements[randomMeasurement, 0] + " where all the sides are " + cubeSide + measurements[randomMeasurement, 1] + ".";
                    answer = Cube(cubeSide);
                    solution += "Volume of a cube = side length^3<br>Volume = " + cubeSide + "^3 = " + answer + " cubic " + measurements[randomMeasurement, 0];
                    break;
                case 1: // Rectangular Prism
                    int lengthPrism = random.Next(minValue, maxValue);
                    int widthPrism = random.Next(minValue, maxValue);
                    int heightPrism = random.Next(minValue, maxValue);
                    question = "Find the volume of rectangular prism in " + measurements[randomMeasurement, 0] + " where the length is " + lengthPrism + measurements[randomMeasurement, 1] + ", the width is " + widthPrism + measurements[randomMeasurement, 1] + " and the height is " + heightPrism + measurements[randomMeasurement, 1] + ".";
                    answer = RectangularPrism(lengthPrism, widthPrism, heightPrism);
                    solution += "Volume of a rectangular prism = length * width * height<br>Volume = " + lengthPrism + " * " + widthPrism + " * " + heightPrism + " = " + answer + " cubic " + measurements[randomMeasurement, 0];
                    break;
                case 2: // Pyramid
                    int baseLength = random.Next(minValue, maxValue);
                    int baseWidth = random.Next(minValue, maxValue);
                    int heightPyramid = random.Next(minValue, maxValue);
                    question = "Find the volume of pyramid in " + measurements[randomMeasurement, 0] + " where the base length is " + baseLength + measurements[randomMeasurement, 1] + " and the base width is " + baseWidth + measurements[randomMeasurement, 1] + ", and the height is " + heightPyramid + measurements[randomMeasurement, 1] + ".";
                    answer = Pyramid(baseLength, baseWidth, heightPyramid);
                    solution += "Volume of a pyramid = ((base length * base width) * height) / 3<br>Volume = ((" + baseLength + " * " + baseWidth + ") * " + heightPyramid + ") / 3 = " + answer + " cubic " + measurements[randomMeasurement, 0];
                    break;
                case 3: // Cylinder
                    int radiusCylinder = random.Next(minValue, maxValue);
                    int heightCylinder = random.Next(minValue, maxValue);
                    question = "Find the volume of cylinder in " + measurements[randomMeasurement, 0] + " where the radius is " + radiusCylinder + measurements[randomMeasurement, 1] + " and the height is " + heightCylinder + measurements[randomMeasurement, 1] + ".";
                    answer = Cylinder(radiusCylinder, heightCylinder);
                    solution += "Volume of a cylinder = π * radius^2 * height<br>Volume = π * " + radiusCylinder + "^2 * " + heightCylinder + " = " + (Math.Pow(radiusCylinder, 2) * heightCylinder) + "π cubic " + measurements[randomMeasurement, 0] + " = " + answer + " cubic " + measurements[randomMeasurement, 0];
                    break;
                case 4: // Sphere
                    int radiusSphere = random.Next(minValue, maxValue);
                    question = "Find the volume of sphere in " + measurements[randomMeasurement, 0] + " where the radius is " + radiusSphere + measurements[randomMeasurement, 1] + ".";
                    answer = Sphere(radiusSphere);
                    solution += "Volume of a sphere = (4/3) * π * radius^3<br>Volume = (4/3) * π * " + radiusSphere + "^3 = (4/3) * π * " + Math.Pow(radiusSphere, 3) + " = " + ((4.0 / 3.0) * Math.Pow(radiusSphere, 3)) + "π cubic" + measurements[randomMeasurement, 0] + " = " + answer + " cubic " + measurements[randomMeasurement, 0];
                    break;
                case 5: // Cone
                    int radiusCone = random.Next(minValue, maxValue);
                    int heightCone = random.Next(minValue, maxValue);
                    question = "Find the volume of cone in " + measurements[randomMeasurement, 0] + " where the radius is " + radiusCone + measurements[randomMeasurement, 1] + " and the height is " + heightCone + measurements[randomMeasurement, 1] + ".";
                    answer = Cone(radiusCone, heightCone);
                    solution += "Volume of a cone = (1/3) * π * radius^2 * height<br>Volume = (1/3) * π * " + radiusCone + "^2 * " + heightCone + " = (1/3) * π * " + Math.Pow(radiusCone, 2) + " * " + heightCone + " = " + ((Math.Pow(radiusCone, 2) * heightCone) / 3) + "π cubic " + measurements[randomMeasurement, 0] + " = " + answer + " cubic " + measurements[randomMeasurement, 0];
                    break;
            }

            string answerString = answer.ToString();
            int decimalPlaces = answerString.Length - answerString.IndexOf('.') - 1;
            if (decimalPlaces > 5)
            {
                return GetComponent();
            }

            return new List<string>() { question, solution, answerString };
        }

        private static double Cube(double side) => side * side * side;

        private static double RectangularPrism(double length, double width, double height) => length * width * height;

        private static double Pyramid(double baseLength, double baseWidth, double height) => ((baseLength * baseWidth) * height) / 3;

        private static double Cylinder(double radius, double height) => 3.14159 * Math.Pow(radius, 2) * height;

        private static double Sphere(double radius) => (4.0 / 3.0) * 3.14159 * Math.Pow(radius, 3);

        private static double Cone(double radius, double height) => (1.0 / 3.0) * 3.14159 * Math.Pow(radius, 2) * height;
    }
}