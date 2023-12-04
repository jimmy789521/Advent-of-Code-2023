using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Advent_of_Code_2023
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int CheckCard(string line)
        {
            line = line.Replace("  ", " ");
            line = line.Substring(9); // We remove the card name and all double spaces
            string[] winNums = line.Split(" | ")[0].Split(' ');
            string[] drawNums = line.Split(" | ")[1].Split(' ');
            string[] commonNum = winNums.Intersect(drawNums).ToArray(); // We get an array of all the numbers in common
            if(commonNum.Length > 0 )
            {
                return (int)Math.Pow(2,commonNum.Length-1); //We calculate the points based on the amount of matching numbers.
            }
            else { return 0; }
        }
    }
}
