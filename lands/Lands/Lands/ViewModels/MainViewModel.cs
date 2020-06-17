using Lands.Helpers;
using Lands.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lands.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<Land> LandsList { get; set; }
        //public TokenResponse Token { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        #endregion

        #region ViewModels
        public LoginViewModel Login { get; set; }

        public LandsViewModel Lands { get; set; }

        public LandViewModel Land { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel { 
                Icon = "ic_settings",
                Title = Languages.MyProfile,
                PageName ="MyProfilePage",
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart_outlined",
                Title = Languages.Stadistics,
                PageName = "StadisticsPage",
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                Title = Languages.Logout,
                PageName = "LoginPage",
            });

        }
        #endregion

        #region Singleton
        private static MainViewModel instance { get; set; }
        
        public static MainViewModel getInstance()
        {
            if (instance == null) { return new MainViewModel();  }

            return instance;
        }
        #endregion
    }
}
