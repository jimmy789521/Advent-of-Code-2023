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
        public static IDictionary<string, List<int>> GetGears(string prevline, string curline, string nextline, IDictionary<string, List<int>> gears,int lineNum)
        {
            string numMem = "";
            string pos = "";
            for (int i = 0; i < curline.Length; i++)
            {
                if (Char.IsNumber(curline[i])) //begin or middle of a number
                {
                    numMem += curline[i]; // this operation allows to remember the full number until it's either added to the sum, or dropped if not valid
                    for (int j = Math.Max(0, i - 1); j < Math.Min(i + 2, curline.Length); j++) //Check the surroundings if there is a gear
                    {
                        if (!String.IsNullOrWhiteSpace(prevline))
                        {
                            if (prevline[j] == '*')
                            {
                                pos = (lineNum-1).ToString() + '-' + j.ToString(); //Position of the gear linked to this number
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(nextline))
                        {
                            if (nextline[j] == '*')
                            {
                                pos = (lineNum + 1).ToString() + '-' + j.ToString();
                            }
                        }
                        if (curline[j] == '*')
                        {
                            pos = lineNum.ToString() + '-' + j.ToString();
                        }
                    }
                }
                else // No number or end of the number
                {
                    if (!String.IsNullOrWhiteSpace(pos)) // there was a number linked to a gear
                    {
                        if (gears.ContainsKey(pos)) // the gears is known, the number is added to the list of numbers linked to the gear
                        {
                            List<int> list = gears[pos];
                            list.Add(Int32.Parse(numMem));
                        }
                        else
                        {
                            List<int> list = new List<int>(); // new gear
                            list.Add(Int32.Parse(numMem));
                            gears.Add(pos, list);
                        }
                    }
                    numMem = ""; //Reset to default value until next number in the line
                    pos = "";
                }
            }
            if (!String.IsNullOrWhiteSpace(pos)) //The last value was a number linked to a gear
            {
                if (!String.IsNullOrWhiteSpace(pos))
                {
                    if (gears.ContainsKey(pos))
                    {
                        List<int> list = gears[pos];
                        list.Add(Int32.Parse(numMem));
                    }
                    else
                    {
                        List<int> list = new List<int>();
                        list.Add(Int32.Parse(numMem));
                        gears.Add(pos, list);
                    }
                }
                numMem = ""; //Reset to default value until next number in the line
                pos = "";
            }
            return gears;
        }
    }
}
