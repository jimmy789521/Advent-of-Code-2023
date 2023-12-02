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
        public static int CheckPossibleGame(string line)
        {
            //First we get the ID of the game simply by cutting before the colon and trimming the "Game " segment.
            int id = Int32.Parse(line.Split(": ")[0].Substring(5));

            string[] redValues = line.Split(" red");
            foreach (string value in redValues)
            {
                if (value.Length > 1)
                {
                    if (Char.IsNumber(value[value.Length - 2])) //This condition checks at the same time if the value is for a red amount of cubes and if it's a two digits amount
                    {
                        if (Int32.Parse(value.Substring(value.Length - 2)) > 12) //Comparison with the max amount of red cubes
                        {
                            return 0;
                        }
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
                        if (Int32.Parse(value.Substring(value.Length - 2)) > 13) //Comparison with the max amount of green cubes
                        {
                            return 0;
                        }
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
                        if (Int32.Parse(value.Substring(value.Length - 2)) > 14) //Comparison with the max amount of blue cubes
                        {
                            return 0;
                        }
                    }
                }
            }
            return id;
        }
    }
}
