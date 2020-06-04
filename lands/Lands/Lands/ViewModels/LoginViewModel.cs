using GalaSoft.MvvmLight.Command;
using Lands.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemember { get; set; }

        public bool IsEnabled {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { get { return new RelayCommand(Login); } }

        private async void Login()
        {
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                   "Debes ingresar tu Email",
                                   "OK");
                return;
            }

            if (String.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                   "Debes ingresar tu Password",
                                   "OK");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "jared@ex.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error",
                                   "Email o Password incorrecta",
                                   "OK");

                this.Password = String.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = String.Empty;
            this.Password = String.Empty;

            MainViewModel.getInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync( new LandsPage() );
        }

        public ICommand RegisterCommand { get; }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemember = true;
            //this.IsRunning = false;
            this.IsEnabled = true;

            //Temporal
            this.Email = "jared@ex.com";
            this.Password = "1234";

            //http://restcountries.eu/rest/v2/all
        }
        #endregion
    }
}
