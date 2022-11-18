using System;
using System.Collections.Generic;
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

namespace WPF_09C___ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Match> matches = new List<Match>();
            matches.Add(new Match() { Team1 = "B Munich", Team2="Real M.", Score1=3, Score2=2, Completion=85 });
            matches.Add(new Match() { Team1 = "AA", Team2 = "BB", Score1 = 3, Score2 = 2, Completion = 10 });
            matches.Add(new Match() { Team1 = "CC", Team2 = "DD", Score1 = 33, Score2 = 22, Completion = 24 });
            matches.Add(new Match() { Team1 = "EE", Team2 = "FF", Score1 = 23, Score2 = 332, Completion = 52 });


            lbMatches.ItemsSource = matches;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbMatches.SelectedItem != null)
            {
                MessageBox.Show("Selected Match: " +
                    (lbMatches.SelectedItem as Match).Team1 + " " + (lbMatches.SelectedItem as Match).Score1 + " " + (lbMatches.SelectedItem as Match).Team2 + " " + (lbMatches.SelectedItem as Match).Score2);
            }
        }
    }
    
    public class Match
    {
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Completion { get; set; }


    }
}
