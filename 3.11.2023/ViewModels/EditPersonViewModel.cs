using _3._11._2023.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _3._11._2023.ViewModels
{
    internal class EditPersonViewModel : DependencyObject
    {
        private static readonly DependencyProperty _result;

        private static readonly DependencyProperty _BIO;
        private static readonly DependencyProperty _addres;
        private static readonly DependencyProperty _number;

        public bool Result
        {
            get { return (bool)GetValue(_result); }
            set { SetValue(_result, value); }
        }

        public string BIO
        {
            get { return (string)GetValue(_BIO); }
            set { SetValue(_BIO, value); }
        }

        public string Addres
        {
            get { return (string)GetValue(_addres); }
            set { SetValue(_addres, value); }
        }

        public string Number
        {
            get { return (string)GetValue(_number); }
            set { SetValue(_number, value); }
        }

        static EditPersonViewModel()
        {
            _result = DependencyProperty.Register(
                "Result", typeof(bool), typeof(MainViewModel));
            _BIO = DependencyProperty.Register(
                "BIO", typeof(string), typeof(MainViewModel));
            _addres = DependencyProperty.Register(
                "Addres", typeof(string), typeof(MainViewModel));
            _number = DependencyProperty.Register(
                "Number", typeof(string), typeof(MainViewModel));
        }

        DelegateCommand saveCommand;
        public ICommand SaveCommand { get { return saveCommand; } }

        DelegateCommand closeCommand;
        public ICommand CloseCommand { get { return closeCommand; } }

        public EditPersonViewModel()
        {
            closeCommand = new DelegateCommand(CloseWindow, CanAlways);
            saveCommand = new DelegateCommand(SavePerson, CanAlways);

            Result = false;
            BIO = "";
            Addres = "";
            Number = "";
        }

        private bool CanAlways(object obj)
        {
            return true;
        }

        private void CloseWindow(object obj)
        {
            Result = false;
            (obj as Window).Close();
        }

        private void SavePerson(object obj)
        {
            Result = true;
            (obj as Window).Close();
        }
    }
}
