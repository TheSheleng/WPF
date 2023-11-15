using _08._11._2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _08._11._2023.ViewModels
{
    internal class SummaryViewModel : ViewModelBase
    {
        private static readonly DependencyProperty SummaryInfoProperty;

        static SummaryViewModel() 
        {
            SummaryInfoProperty = DependencyProperty.Register(
                "Name", typeof(string), typeof(SummaryViewModel));
        }

        public SummaryViewModel(SummaryModel summaryModel)
        {
            SummaryInfo = GeneratedInfo(summaryModel);
        }

        public string SummaryInfo
        {
            get { return (string)GetValue(SummaryInfoProperty); }
            set { SetValue(SummaryInfoProperty, value); }
        }

        private string GeneratedInfo(SummaryModel summaryModel)
        {
            return $"{summaryModel.Name} {summaryModel.Surname}\nEngish: {summaryModel.IsEngish}" +
                $"\nJava: {summaryModel.Java}\nC++: {summaryModel.CPlusPlus}\nC#: {summaryModel.CSharp}";
        }
    }
}
