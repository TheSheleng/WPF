using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _29._09._2023
{
    using lang = KeyValuePair<string, List<string>>;

    public class LanguagesModel
    {
        List<lang> Languages;
        int Selected = 0;

        public LanguagesModel()
        {
            Languages = new List<lang>();
        }

        public void AddLanguage(string icon, List<string> translations)
        {
            Languages.Add(new lang(icon, translations));
        }

        public lang GetCurrent()
        {
            return Languages[Selected];
        }

        public lang GetNext() 
        {
            if (Selected < Languages.Count - 1) Selected++;
            else Selected = 0;
            return Languages[Selected];
        }
    }
}
