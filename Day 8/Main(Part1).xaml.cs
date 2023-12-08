using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Advent_of_Code_2023;

namespace Advent_of_Code_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Debt
        {
            get { return (string)GetValue(DebtProperty); }
            set { SetValue(DebtProperty, value); }
        }
        public static readonly DependencyProperty DebtProperty =
                    DependencyProperty.Register("Debt", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
        
        public MainWindow()
        {
            InitializeComponent();
            string instructions = "LRRRLRRRLRRLRLRRLLRRLLRLRRRLRRLRRRLRRLLRLRLRRRLRLLRRRLLRLRRRLRLRRRLRRRLRRRLRRRLRLLLRRRLRRLRRLRRRLRLRLRRLRLRRRLRLRLRLRRRLRRLRLRRRLRRLRRRLRRLLRRRLLRLLRLRRRLRLLRRLLRRRLRLLRRLRLRRLRRRLRLRLRLLRLRRRLRRRLRLLLRRRLRLRRRLRRLRRLLLLRLRRRLRLRRRLLRRRLRRRLRRRLLLRLRLRLLLLRRRLRRLRRRLRLRLRLRRRLRLRRRR";
            string fileName = "C:\\Users\\Jimmy BERNABE\\source\\repos\\Advent of Code 2023\\Advent of Code 2023\\Input.txt";
            int sum = 0;
            Dictionary <string, string[]> paths = new Dictionary<string, string[]>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = { line.Substring(7,3), line.Substring(12,3) };
                    paths.Add(line.Substring(0, 3), values);
                }
            }
            string curLocation = "AAA";
            while (curLocation != "ZZZ")
            {

                curLocation = paths[curLocation][
                  instructions[sum % instructions.Length] == 'L' ? 0 : 1
                ];
                sum++;
            }
            this.DataContext = this;
            this.Debt = sum.ToString();
        }
    }
}
