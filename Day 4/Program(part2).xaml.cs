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
        public static int[] CheckCard(string line, int[] pile, int card)
        {
            line = line.Replace("  ", " ");
            line = line.Substring(9); // We remove the card name and all double spaces
            string[] winNums = line.Split(" | ")[0].Split(' ');
            string[] drawNums = line.Split(" | ")[1].Split(' ');
            string[] commonNum = winNums.Intersect(drawNums).ToArray(); // We get an array of all the numbers in common
            if(commonNum.Length > 0 )
            {
                for (int i = 0; i < commonNum.Length; i++)
                {
                    pile[card + i] = pile[card + i] + pile[card - 1]; //for each amount of the current card, we add one new following card for each winning number
                }
                return pile;
            }
            else { return pile; }
        }
    }
}
