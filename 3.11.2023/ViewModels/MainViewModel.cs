using _3._11._2023.Command;
using _3._11._2023.Modesl;
using _3._11._2023.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace _3._11._2023.ViewModels
{
    internal class MainViewModel : DependencyObject
    {
        private bool CanAlways(object obj)
        {
            return true;
        }

        DelegateCommand closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new DelegateCommand(CloseWindow, CanAlways);
                }

                return closeCommand;
            }
        }

        private void CloseWindow(object obj)
        {
            (obj as Window).Close();
        }

        public ObservableCollection<Person> Persons { get; set; }

        DelegateCommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(AddPerson, CanAlways);
                }

                return addCommand;
            }
        }

        private void AddPerson(object obj)
        {
            EditPersonWindow view = new EditPersonWindow();
            EditPersonViewModel viewModel = new EditPersonViewModel();
            view.DataContext = viewModel;
            view.ShowDialog();
        }


    }
}
