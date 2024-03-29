﻿using ChronoMedic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChronoMedic.ViewModel
{
    public class UserObjectViewModel: ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        private static ViewUsers SelectedUser;
        private static bool IsEdit;

        private static MainViewModel _currentMain;

        public ICommand Save1 { get; }
        public ICommand Back1 { get; }


        public UserObjectViewModel()
        {
            Save1 = new ViewModelCommand(ExecutedSaveCommand);
            Back1 = new ViewModelCommand(ExecutedBackCommand);

            if (IsEdit)
                SetUser();
        }

        public UserObjectViewModel(MainViewModel main)
        {
            _currentMain = main;
            IsEdit = false;
        }
        public UserObjectViewModel(MainViewModel main, ViewUsers selectedUser)
        {
            _currentMain = main;
            SelectedUser = selectedUser;
            IsEdit = true;
        }

        private void ExecutedBackCommand(object obj)
        {
            _currentMain.CurrentChildView = new CustomerViewModel();
            _currentMain.Caption = "Users";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.User;
        }
        private void SetUser()
        {
            Username = SelectedUser.Users.Username;
            Password = SelectedUser.Users.Password;
            Name = SelectedUser.Name;
            LastName = SelectedUser.LastName;
            Email = SelectedUser.Email;
            
        }

        private void ExecutedSaveCommand(object obj)
        {
            if (!IsEdit)
            {
                try
                {
                    FunctionUsers.Add(Username, Password, Name, LastName, Email);
                    FunctionWindow.OpenGoodWindow("Пользователь добавлен");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                try
                {
                    FunctionUsers.SaveEditUser(Username, Password, Name, LastName, Email, SelectedUser);
                    FunctionWindow.OpenGoodWindow("Пользователь отредактирован");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            
        }
    }
}
