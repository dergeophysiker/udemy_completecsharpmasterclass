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

namespace WPF_08C___INotifyPropertyChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        
        /* method 1 of this */
        
        //public Sum SumObj { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            /* method 1 of this */
            //  SumObj = new Sum { Num1 = "1", Num2 = "2" };
            /* method 2 of this */
            Sum SumObj = new Sum() { Num1 = "0", Num2 = "0" };

            this.DataContext = SumObj;


        }
    }




}
