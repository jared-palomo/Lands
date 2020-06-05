using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Lands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LandItemViewModel : Land
    {
        #region Command
        public ICommand SelectLandCommand
        {
            get { return new RelayCommand(SelectLand); }
        }

        private async void SelectLand()
        {
            MainViewModel.getInstance().Land = new LandViewModel( this );
            await Application.Current.MainPage.Navigation.PushAsync( new LandPage() );
        }
        #endregion
    }
}
