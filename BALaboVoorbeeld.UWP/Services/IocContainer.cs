using BALaboVoorbeeld.UWP.Pages;
using BALaboVoorbeeld.UWP.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BALaboVoorbeeld.UWP.Services
{
    public class IocContainer
    {
        static IocContainer()
        {
            SimpleIoc.Default.Register<ApplicationViewModel>(false);
            SimpleIoc.Default.Register<ShowWeatherViewModel>(false);
            SimpleIoc.Default.Register<ShowWeatherPage>(false);
            SimpleIoc.Default.Register<ShowWeatherDetailPage>(false);
            SimpleIoc.Default.Register<ShowWeatherDetailViewModel>(false);
        }

        public static IocContainer Ioc
        {
            get
            {
                return App.Current.Resources["ioc"] as IocContainer;
            }
        }

        public ShowWeatherPage ShowWeatherPage
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherPage>(); }
        }

        public ShowWeatherViewModel ShowWeatherViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherViewModel>(); }
        }

        public ApplicationViewModel ApplicationViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ApplicationViewModel>(); }
        }

        public ShowWeatherDetailPage ShowWeatherDetailPage
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherDetailPage>(); }
        }

        public ShowWeatherDetailViewModel ShowWeatherDetailViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ShowWeatherDetailViewModel>(); }
        }
    }
}
