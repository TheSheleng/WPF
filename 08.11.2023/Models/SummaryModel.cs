using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._11._2023.Models
{
    internal class SummaryModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsEngish { get; set; }

        public SummaryModel(string name, string surname, bool isEnglish)
        {
            Name = name;
            Surname = surname;
            IsEngish = isEnglish;
        }

        public override string ToString()
        {
            return Name + ' ' + Surname;
        }
    }
}
