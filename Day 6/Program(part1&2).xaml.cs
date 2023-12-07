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
        public static int WinRace(long time, long distance)
        {
            int ans = 0;
            for (long i = 0; i<time+1; i++)
            {
                if(i * (time - i)> distance)
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
