using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    interface IDestroyable
    {

        string DestructionSound { get; set; }
        void Destroy();

    }
}
