using System;
using System.Collections.Generic;
using System.Reflection;
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

namespace WPF10C_ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBoxColors.ItemsSource = typeof(FinanceStuff).GetProperties();

          /*  PropertyInfo[] test = typeof(Colors).GetProperties();
            comboBoxColors.ItemsSource = typeof(Colors).GetProperties();
            comboBoxColors.SelectedItem = typeof(Colors).GetProperty(nameof(Colors.Red));
       */
            }
        private void cmb_Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            /*
            // string str = typeof(Colors).GetProperty(nameof(comboBoxColors.SelectedItem)).ToString();

            string str1 = (comboBoxColors.SelectedItem as PropertyInfo).Name;
            //string str = (System.Reflection.RuntimePropertyInfo )comboBoxColors.SelectedValue).ToString();
            string str = comboBoxColors.SelectedValue.ToString();
       
            MessageBox.Show(str +"\n" + str, "ITEM");
        
            */

            string str = (comboBoxColors.SelectedItem as PropertyInfo).Name;
            MessageBox.Show(str + "\n" + str, "ITEM");


        }

    }//end class

    public class FinanceStuff
    {
        public string Bonds { get; set; }
        public string Stocks { get; set; }
    }

}
