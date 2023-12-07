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
        public static int SortHands(string[] x, string[] y) // Allows to sort by hand type and then by card's strength
        {
            if (x[2] == y[2])
            {
                for(int i=0; i<5; i++)
                {
                    if (x[0][i] != y[0][i])
                    {
                        switch (x[0][i])
                        {
                            case 'A':
                                return 1;
                            case 'K':
                                return y[0][i] != 'A' ? 1:-1;
                            case 'Q':
                                return y[0][i] != 'A' && y[0][i] != 'K' ? 1 : -1;
                            case 'J':
                                return -1;
                            case 'T':
                                return y[0][i] != 'A' && y[0][i] != 'K' && y[0][i] != 'Q' ? 1 : -1;
                            default:
                                if (y[0][i] == 'J')
                                {
                                    return 1;
                                }
                                else if (!Char.IsDigit(y[0][i]))
                                {
                                    return -1;
                                }
                                else return x[0].CompareTo(y[0]);
                        }
                    }
                }
                return 0;
            }
            else
            {
                return x[2].CompareTo(y[2]);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            string fileName = "C:\\Users\\Jimmy BERNABE\\source\\repos\\Advent of Code 2023\\Advent of Code 2023\\Input.txt";
            int sum = 0;
            List <string[]> hands = new List<string[]>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = App.EvaluateHand(line);
                    hands.Add(values);
                }
            }
            hands.Sort(SortHands);
            hands.Reverse();
            for (int i = 0; i < hands.Count; i++)
            {
                //this.Debt += hands[i][0] + " " + hands[i][2] + "\n";
                sum += (Int32.Parse(hands[i][1]) * (hands.Count - i));
            }
            this.DataContext = this;
            this.Debt = sum.ToString();
        }
    }
}
