using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._11._2023.Modesl
{
    internal class Person
    {
        public string BIO { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }

        public Person(string _BIO, string _address, string _number)
        {
            BIO = _BIO;
            Address = _address;
            Number = _number;
        }

        public override string ToString()
        {
            return BIO + ' ' + Address + ' ' + Number;
        }
    }
}
