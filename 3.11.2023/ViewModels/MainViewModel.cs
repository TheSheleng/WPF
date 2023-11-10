using _3._11._2023.Command;
using _3._11._2023.Modesl;
using _3._11._2023.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace _3._11._2023.ViewModels
{
    internal class MainViewModel : DependencyObject
    {
        const string PathFile = "save.json";

        public ObservableCollection<Person> Persons { get; set; }

        DelegateCommand closeCommand;
        public ICommand CloseCommand { get { return closeCommand; } }

        DelegateCommand addCommand;
        public ICommand AddCommand { get { return addCommand; } }

        DelegateCommand editCommand;
        public ICommand EditCommand { get { return editCommand; } }

        DelegateCommand dellCommand;
        public ICommand DellCommand { get { return dellCommand; } }

        DelegateCommand saveFileCommand;
        public ICommand SaveFileCommand { get { return saveFileCommand; } }

        DelegateCommand openFileCommand;
        public ICommand OpenFileCommand { get { return openFileCommand; } }

        public MainViewModel() 
        {
            Persons = new ObservableCollection<Person>();
            closeCommand = new DelegateCommand(CloseWindow, CanAlways);
            addCommand = new DelegateCommand(AddPerson, CanAlways);
            editCommand = new DelegateCommand(Edit, CanModifyItem);
            dellCommand = new DelegateCommand(Dell, CanModifyItem);
            saveFileCommand = new DelegateCommand(SaveFile, CanAlways);
            openFileCommand = new DelegateCommand(OpenFile, CanAlways);
        }

        private bool CanModifyItem(object obj)
        {
            return obj != null;
        }

        private void Edit(object obj)
        {
            EditPersonWindow view = new EditPersonWindow();
            EditPersonViewModel viewModel = new EditPersonViewModel();
            view.DataContext = viewModel;
            view.ShowDialog();

            if (!viewModel.Result) return;

            if (viewModel.BIO == "" || viewModel.Addres == "" || viewModel.Number == "")
            {
                MessageBox.Show("All input fields must be filled in.");
                return;
            }

            Persons.Remove(obj as Person);
            Persons.Add(new Person(viewModel.BIO, viewModel.Addres, viewModel.Number));
        }

        private void OpenFile(object obj)
        {
            string json = File.ReadAllText(PathFile);
            Persons = JsonSerializer.Deserialize<ObservableCollection<Person>>(json);
        }

        private void SaveFile(object obj)
        {
            string json = JsonSerializer.Serialize(Persons);
            File.WriteAllText(PathFile, json);
        }

        private void Dell(object obj)
        {
            Persons.Remove(obj as Person);
        }

        private bool CanAlways(object obj)
        {
            return true;
        }

        private void CloseWindow(object obj)
        {
            (obj as Window).Close();
        }

        private void AddPerson(object obj)
        {
            EditPersonWindow view = new EditPersonWindow();
            EditPersonViewModel viewModel = new EditPersonViewModel();
            view.DataContext = viewModel;
            view.ShowDialog();

            if (!viewModel.Result) return;

            if (viewModel.BIO == "" || viewModel.Addres == "" || viewModel.Number == "")
            {
                MessageBox.Show("All input fields must be filled in.");
                return;
            }

            Persons.Add(new Person(viewModel.BIO, viewModel.Addres, viewModel.Number));
        }


    }
}
