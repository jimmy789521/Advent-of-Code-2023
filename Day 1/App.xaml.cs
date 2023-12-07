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
        public static int GetLineNumber(string line)
        {
            line = Regex.Replace(line, "one", "o1e");
            line = Regex.Replace(line, "two", "t2o");
            line = Regex.Replace(line, "three", "t3e");
            line = Regex.Replace(line, "four", "f4r");
            line = Regex.Replace(line, "five", "f5e");
            line = Regex.Replace(line, "six", "s6x");
            line = Regex.Replace(line, "seven", "s7n");
            line = Regex.Replace(line, "eight", "e8t");
            line = Regex.Replace(line, "nine", "n9e");
            line = Regex.Replace(line, "[^0-9]", "");
            string number = line[0].ToString() + line[line.Length - 1].ToString();
            return Int32.Parse(number);
        }
    }
}
