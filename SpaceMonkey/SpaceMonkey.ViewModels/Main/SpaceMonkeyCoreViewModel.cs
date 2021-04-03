using SpaceMonkey.IO.Schemas;
using SpaceMonkey.MVVM.Base;
using SpaceMonkey.ViewModels.Controls;
using SpaceMonkey.ViewModels.Helpers;
using SpaceMonkey.WebClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceMonkey.ViewModels.Main
{
    public class SpaceMonkeyCoreViewModel : BaseViewModel
    {
        public string APIKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public int SearchRadius { get; set; }
        public int CategoryId { get; set; }

        

        public ICommand GetSatellitesCommand { get; set; }
        private SpaceMonkeyWebClient Client;

        public ObservableCollection<SatelliteCardViewModel> Satellites { get; set; }
        public ObservableCollection<string> Categories { get; set; }

        public SpaceMonkeyCoreViewModel()
        {
            this.Satellites = new ObservableCollection<SatelliteCardViewModel>();
            this.Categories = new ObservableCollection<string>(CategoryIdHelper.GetCategories());
            this.Client = new SpaceMonkeyWebClient();
            this.GetSatellitesCommand = new RelayCommand(this.GetSatellites);
            this.SearchRadius = 70;
            this.CategoryId = 0;
        }


        public async void GetSatellites()
        {
            SmAboveResponse response = await this.Client.GetAboveSatellites(this.Latitude, this.Longitude, this.Altitude, this.SearchRadius, this.CategoryId, this.APIKey);
            this.Satellites.Clear();
            if (response != null)
            {
                foreach (SmSatellite sat in response.Above)
                {
                    this.Satellites.Add(new SatelliteCardViewModel(sat));
                }
            }
        }


    }
}
