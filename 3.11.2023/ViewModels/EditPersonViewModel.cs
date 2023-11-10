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
    }
}
