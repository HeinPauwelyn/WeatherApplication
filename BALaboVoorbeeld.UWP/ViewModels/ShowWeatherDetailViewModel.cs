using BALaboVoorbeeld.Models;
using BALaboVoorbeeld.UWP.Pages;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.UWP.ViewModels
{
    public class ShowWeatherDetailViewModel: ViewModelBaseClass
    {
        private Item _item;
        private RelayCommand _showOverview;

        public Item Item
        {
            get
            {
                return _item;
            }
            set
            {
                if (value != _item)
                {
                    _item = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public RelayCommand ShowOverview
        {
            get { return _showOverview; }
            set { _showOverview = value; }
        }

        public ShowWeatherDetailViewModel()
        {
            _showOverview = new RelayCommand(ShowOverviewPage);
        }

        private void ShowOverviewPage()
        {
            ApplicationViewModel appVm = App.Current.Resources["appvm"] as ApplicationViewModel;
            appVm.Navigate(typeof(ShowWeatherPage));
        }
    }
}
