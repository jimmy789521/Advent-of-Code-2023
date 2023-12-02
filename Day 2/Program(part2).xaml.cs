using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Advent_of_Code_2023
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int GetGamePower(string line)
        {
            int minRed, minBlue, minGreen;
            minBlue = minGreen = minRed = 1; //Initialisation. There is at least one of each cube.

            string[] redValues = line.Split(" red");
            foreach (string value in redValues)
            {
                if (value.Length > 1)
                {
                    if (Char.IsNumber(value[value.Length - 2])) //This condition checks at the same time if the value is for a red amount of cubes and if it's a two digits amount
                    {
                        minRed = Math.Max(minRed, Int32.Parse(value.Substring(value.Length - 2))); //Keep the biggest min number.

                    }
                    else if (Char.IsNumber(value[value.Length - 1])) // This condition only checks if it's a value for a red amount of cubes
                    {
                        minRed = Math.Max(minRed, Int32.Parse(value.Substring(value.Length - 1))); //Keep the biggest min number.
                    }
                }
            }
            string[] greenValues = line.Split(" green");
            foreach (string value in greenValues)
            {
                if (value.Length > 1)
                {
                    if (Char.IsNumber(value[value.Length - 2])) //This condition checks at the same time if the value is for a green amount of cubes and if it's a two digits amount
                    {
                        minGreen = Math.Max(minGreen, Int32.Parse(value.Substring(value.Length - 2))); //Keep the biggest min number.

                    }
                    else if (Char.IsNumber(value[value.Length - 1])) // This condition only checks if it's a value for a green amount of cubes
                    {
                        minGreen = Math.Max(minGreen, Int32.Parse(value.Substring(value.Length - 1))); //Keep the biggest min number.
                    }
                }
            }
            string[] blueValues = line.Split(" blue");
            foreach (string value in blueValues)
            {
                if (value.Length > 1)
                {
                    if (Char.IsNumber(value[value.Length - 2])) //This condition checks at the same time if the value is for a blue amount of cubes and if it's a two digits amount
                    {
                        minBlue = Math.Max(minBlue, Int32.Parse(value.Substring(value.Length - 2))); //Keep the biggest min number.

                    }
                    else if (Char.IsNumber(value[value.Length - 1])) // This condition only checks if it's a value for a blue amount of cubes
                    {
                        minBlue = Math.Max(minBlue, Int32.Parse(value.Substring(value.Length - 1))); //Keep the biggest min number.
                    }
                }
            }
            return minBlue * minGreen * minRed;
        }
    }
}
