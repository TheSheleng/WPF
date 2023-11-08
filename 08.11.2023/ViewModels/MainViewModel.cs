﻿using _08._11._2023.Commands;
using _08._11._2023.Models;
using _08._11._2023.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _08._11._2023.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private static readonly DependencyProperty NameProperty;
        private static readonly DependencyProperty SurnameProperty;
        private static readonly DependencyProperty IsEnglishProperty;
        private static readonly DependencyProperty SelectedSummaryItemProperty;

        static MainViewModel()
        {
            NameProperty = DependencyProperty.Register(
                "Name", typeof(string), typeof(MainViewModel));

            SurnameProperty = DependencyProperty.Register(
                "Surname", typeof(string), typeof(MainViewModel));

            IsEnglishProperty = DependencyProperty.Register(
                "English", typeof(bool), typeof(MainViewModel));

            SelectedSummaryItemProperty = DependencyProperty.Register(
                "SelectedSummaryItem", typeof(SummaryModel), typeof(MainViewModel));
        }

        public MainViewModel()
        {
            Summaries = new ObservableCollection<SummaryModel>();

            Summaries.Add(new SummaryModel("Name 1", "Surname 1", true));
            Summaries.Add(new SummaryModel("Name 2", "Surname 2", false));
            Summaries.Add(new SummaryModel("Name 3", "Surname 3", true));
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string Surname
        {
            get { return(string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value);}
        }

        public bool IsEnglish
        {
            get { return (bool)GetValue(IsEnglishProperty); }
            set { SetValue(IsEnglishProperty, value);}
        }

        public SummaryModel SelectedSummaryItem
        {
            get { return (SummaryModel)GetValue(SelectedSummaryItemProperty); }
            set { SetValue(SelectedSummaryItemProperty, value); }
        }

        public ObservableCollection<SummaryModel> Summaries { get; set; }

        DelegateCommand saveCommand;

        public ICommand SaveCommand { 
            get { 
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(SaveSummary, CanSaveSummary);
                }

                return saveCommand;
            } }

        private void SaveSummary(object obj)
        {
            Summaries.Add(new SummaryModel(Name, Surname, IsEnglish));
        }

        private bool CanSaveSummary(object obj)
        {
            return true;
        }

        DelegateCommand clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    clearCommand = new DelegateCommand(ClearSummary, CanClearSummary);
                }

                return clearCommand;
            }
        }

        private void ClearSummary(object obj)
        {
            Name = "";
            Surname = "";
            IsEnglish = false;
        }

        private bool CanClearSummary(object obj)
        {
            return true;
        }

        DelegateCommand showCommand;

        public ICommand ShowCommand
        {
            get
            {
                if (showCommand == null)
                {
                    showCommand = new DelegateCommand(ShowSummary, CanShowSummary);
                }

                return showCommand;
            }
        }

        private bool CanShowSummary(object obj)
        {
            return SelectedSummaryItem != null;
        }

        private void ShowSummary(object obj)
        {
            SummaryView summaryView = new SummaryView();
            SummaryViewModel summaryModel = new SummaryViewModel(SelectedSummaryItem);
            summaryView.DataContext = summaryModel;
            summaryView.Show();  
        }
    }
}
