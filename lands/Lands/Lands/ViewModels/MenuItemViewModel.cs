﻿using GalaSoft.MvvmLight.Command;
using Lands.Domain;
using Lands.Helpers;
using Lands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }
        #endregion

        #region Methods
        private void Navigate()
        {
            //Ocultar Menú
            App.Master.IsPresented = false;

            if (this.PageName == "LoginPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                //-----------Por seguridad...
                var mainViewModel = MainViewModel.getInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;

                using (var conn = new SQLite.SQLiteConnection(App.root_db) )
                {
                    conn.DeleteAll<UserLocal>();
                }

                Application.Current.MainPage = new NavigationPage( new LoginPage() );
            }
            else if(this.PageName == "MyProfilePage")
            {
                MainViewModel.getInstance().MyProfile = new MyProfileViewModel();
                App.Navigator.PushAsync( new MyProfilePage() );
            }
        }
        #endregion
    }
}
