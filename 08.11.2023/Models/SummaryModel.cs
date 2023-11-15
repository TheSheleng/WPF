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
        public bool Java { get; set; }
        public bool CPlusPlus { get; set; }
        public bool CSharp { get; set; }

        public SummaryModel()
        {

        }

        public SummaryModel(string name, string surname, bool isEnglish, bool java, bool cPlusPlus, bool cSharp)
        {
            Name = name;
            Surname = surname;
            IsEngish = isEnglish;
            Java = java;
            CPlusPlus = cPlusPlus;
            CSharp = cSharp;
        }

        public override string ToString()
        {
            return Name + ' ' + Surname;
        }
    }
}
