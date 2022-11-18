using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Human
    {

        public static string firstName= "I have no name";
        private string lastName;

        public int Volume { get; set; }

        public int age  { get; set; }

        public void IntroduceMyself()
        {
            Console.WriteLine("Hi, im {0} , {1}", firstName,lastName);
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }

        }

        public Human()
        {

        }

    }
}
