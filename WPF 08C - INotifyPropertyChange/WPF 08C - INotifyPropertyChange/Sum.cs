using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF_08C___INotifyPropertyChange
{
    public class Sum : INotifyPropertyChanged
    {

        private string num1;
        private string num2;
        private string result;

        public string Num1
        {
            get { return num1; }
            set {
                
                int number;
                bool res = int.TryParse(value, out number);
                if (res) num1 = value;
                onPropertyChanged("Num1");
                onPropertyChanged("Result");
            }
        }

        public string Num2
        {
            get { return num2; }
            set
            {

                int number;
                bool res = int.TryParse(value, out number);
                if (res) num2 = value;
                onPropertyChanged("Num2");
                onPropertyChanged("Result");
            }
        }


        public string Result
        {
            get { int res = int.Parse(Num1) + int.Parse(Num2);
                return res.ToString();
            }
            set
            {

                int res = int.Parse(Num1) + int.Parse(Num2);
                result =  res.ToString();
                onPropertyChanged("Result");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;



        private void onPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
