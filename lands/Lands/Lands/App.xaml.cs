using Lands.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lands.Helpers;
using Lands.ViewModels;
using System.IO;
using Lands.Domain;

namespace Lands
{
    public partial class App : Application
    {
        #region Attributes
        public static string root_db;
        #endregion
        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        #endregion

        #region Constructors

        //Build overload Get route db
        public App(string root_DB)
        {
            InitializeComponent();
            //Set root SQLite
            root_db = root_DB;

            //this.MainPage = new NavigationPage(new LoginPage());
            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                //Connection With SQLite
                var user = new UserLocal();
                using (var conn = new SQLite.SQLiteConnection(App.root_db) ) {
                    conn.CreateTable<UserLocal>();
                    user = conn.Table<UserLocal>().FirstOrDefault();
                }

                var mainViewModel = MainViewModel.getInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.User = user; // <-- sqlite
                mainViewModel.Lands = new LandsViewModel();

                this.MainPage = new MasterPage();
            }
        }

        public App()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Token))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                var mainViewModel = MainViewModel.getInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;

                mainViewModel.Lands = new LandsViewModel();

                Application.Current.MainPage = new MasterPage();
            }
            
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion
    }
}
