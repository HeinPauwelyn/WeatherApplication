using BALaboVoorbeeld.UWP.Pages;
using BALaboVoorbeeld.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace BALaboVoorbeeld.UWP.ViewModels
{
    public class ApplicationViewModel : ViewModelBaseClass
    {
        private Page _currentPage = IocContainer.Ioc.ShowWeatherPage;
        private ShowWeatherDetailPage _showWeatherDetailPage = new ShowWeatherDetailPage();
        private ShowWeatherPage _showWeatherPage = new ShowWeatherPage();

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }


        public ShowWeatherDetailViewModel SwdVm
        {
            get
            {
                return (App.Current.Resources["ioc"] as IocContainer)?.ShowWeatherDetailViewModel;
            }
        }

        public ShowWeatherViewModel SwVm
        {
            get
            {
                return (App.Current.Resources["ioc"] as IocContainer)?.ShowWeatherViewModel;
            }
        }

        public void Navigate(Type sourcePageType)
        {
            if (sourcePageType.Equals(typeof(ShowWeatherDetailPage)))
            {
                SwdVm.Item = SwVm.SelectedVillage;

                CurrentPage = _showWeatherDetailPage;
            }
            else if (sourcePageType.Equals(typeof(ShowWeatherPage)))
            {
                CurrentPage = _showWeatherPage;
            }
        }
    }
}
