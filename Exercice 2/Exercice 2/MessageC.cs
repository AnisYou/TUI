using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice_2
{
    public class MessageC : Message
    {
        public override void CustomMethod()
        {
            Console.WriteLine("Message from C");
            OtherMethod();
        }
        public void OtherMethod()
        {
            Console.WriteLine("Message from OtherMethod");
        }
    }
}
