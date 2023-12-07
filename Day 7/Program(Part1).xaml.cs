using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup.Localizer;

namespace Advent_of_Code_2023
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string[] EvaluateHand(string line)
        {
            string[] ans = { line.Split(" ")[0], line.Split(" ")[1], "A-nothing" };
            Dictionary<char, int> occurences = new Dictionary<char, int>();
            foreach (char card in ans[0])
            {
                if (!occurences.ContainsKey(card))
                {
                    occurences.Add(card, 1);
                }
                else
                {
                    occurences[card] = occurences[card] + 1;
                }
            }
            Dictionary<char, int>.ValueCollection values = occurences.Values;
            switch(values.Count){
                case 1:
                    ans[2] = "H-fiveOfAKind";
                    break;
                case 2:
                    ans[2] = values.Contains(4) ? "G-fourOfAKind" : "E-fullHouse";
                    break;
                case 3:
                    ans[2] = values.Contains(3) ? "D-threeOfAKind" : "C-twoPair";
                    break;
                case 4:
                    ans[2] = "B-pair";
                    break;
            }
            return ans;
        }
    }
}
