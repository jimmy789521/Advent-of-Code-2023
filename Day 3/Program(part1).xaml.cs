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
        public static int GetParts(string prevline, string curline, string nextline)
        {
            int ans = 0;
            string numMem = "";
            bool valid = false;
            for (int i = 0; i < curline.Length; i++)
            {
                if (Char.IsNumber(curline[i])) //begin or middle of a number
                {
                    numMem+= curline[i]; // this operation allows to remember the full number until it's either added to the sum, or dropped if not valid
                    for(int j = Math.Max(0,i-1); j<Math.Min(i+2,curline.Length); j++) //Check the surroundings if there is a symboles
                    {
                        if (!String.IsNullOrWhiteSpace(prevline))
                        {
                            if (!Char.IsNumber(prevline[j]) && prevline[j] != '.')
                            {
                                valid= true;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(nextline))
                        {
                            if (!Char.IsNumber(nextline[j]) && nextline[j] != '.')
                            {
                                valid = true;
                            }
                        }
                        if (!Char.IsNumber(curline[j]) && curline[j] != '.')
                        {
                            valid = true;
                        }
                    }
                }
                else // No number or end of the number
                {
                    if (valid)
                    {
                        ans += Int32.Parse(numMem); // the number is valid, it is added to the value of the line.
                    }
                    numMem = ""; //Reset to default value until next number in the line
                    valid = false;
                }
            }
            if (valid)
            {
                ans += Int32.Parse(numMem); // In case the line finishes on a valid number
            }
            return ans;
        }
    }
}
