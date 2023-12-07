using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string fileName = "C:\\Users\\Jimmy BERNABE\\source\\repos\\Advent of Code 2023\\Advent of Code 2023\\Input.txt";
            int sum = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sum = sum + App.GetLineNumber(line);
                }
            }

            this.DataContext = this;
            this.Debt = sum.ToString();
        }
    }
}
