using BALaboVoorbeeld.Data;
using BALaboVoorbeeld.Models;
using BALaboVoorbeeld.UWP.Pages;
using BALaboVoorbeeld.UWP.Services;
using GalaSoft.MvvmLight.Command;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BALaboVoorbeeld.UWP.ViewModels
{
    public class ShowWeatherViewModel: ViewModelBaseClass
    {
        #region variabelen

        private RelayCommand _showWeahter;
        private ObservableCollection<Item> _villageList;
        private string _village;
        private Item _selectedVillage = null;

        #endregion variabelen

        #region properties

        public RelayCommand ShowWeahter
        {
            get { return _showWeahter; }
            set { _showWeahter = value; }
        }
        
        public ObservableCollection<Item> VillageList
        {
            get
            {
                return _villageList;
            }
            set
            {
                if (_villageList != value)
                {
                    _villageList = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string Village
        {
            get
            {
                return _village;
            }
            set
            {
                if (_village != value)
                {
                    _village = value;
                }
            }
        }

        public Item SelectedVillage
        {
            get
            {
                return _selectedVillage;
            }
            set
            {
                if (_selectedVillage != value)
                {
                    _selectedVillage = value;
                    //ShowDetailPage();
                }
            }
        }

        private RelayCommand _showBigCmd;

        public RelayCommand ShowBigCmd
        {
            get { return _showBigCmd; }
            set { _showBigCmd = value; }
        }


        #endregion properties

        #region constructor

        public ShowWeatherViewModel()
        {
            _showWeahter = new RelayCommand(ShowWeatherExecute);
            _villageList = new ObservableCollection<Item>();
            _showBigCmd = new RelayCommand(ShowDetailPage);
        }

        #endregion constructor

        #region methodes

        private async void ShowWeatherExecute()
        {
            Debug.WriteLine($"De gemeente is {Village}");

            Item item = await YahooWeatherRepository.Get(Village);

            VillageList.Add(item);
            SQLiteCommandos(item);
        }

        private void SQLiteCommandos(Item item)
        {
            if (item != null)
            {
                string path = Path.Combine(ApplicationData.Current.LocalCacheFolder.Path, "Wheather.sqlite");

                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), path))
                {
                    CreateTable(conn);
                    SaveItem(conn, item);
                }
            }
        }

        private void SaveItem(SQLiteConnection conn, Item item)
        {
            string ins = "insert into Village (name, time, title, max, min) values (?, ?, ?, ?, ?)";
            object[] args = new object[] {
                Village,
                DateTime.Now,
                item.Title,
                item.Forecast0.High,
                item.Forecast0.Low
            };

            conn.Execute(ins, args);
        }

        private void CreateTable(SQLiteConnection conn)
        {
            string createTable = "create table if not exists Village (" +
                                 "ID integer primary key," +
                                 "Name text not null," +
                                 "Time datetime not null," +
                                 "Title text not null," +
                                 "Max integer not null," +
                                 "Min integer not null)";

            conn.CreateCommand(createTable).ExecuteNonQuery();
        }

        private void ShowDetailPage()
        {
            ApplicationViewModel appVm = App.Current.Resources["appvm"] as ApplicationViewModel;
            appVm.Navigate(typeof(ShowWeatherDetailPage));
        }

        #endregion methodes
    }
}
