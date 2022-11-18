using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    class Tank : Vehicle
    {
        public Tank(float speed, string color)
        {
            Speed = speed;
            Color = color;
        }
    }
}
