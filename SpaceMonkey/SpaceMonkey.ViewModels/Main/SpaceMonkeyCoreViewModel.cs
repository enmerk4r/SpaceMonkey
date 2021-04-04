using Newtonsoft.Json;
using SpaceMonkey.IO.EventArguments;
using SpaceMonkey.IO.Schemas;
using SpaceMonkey.MVVM.Base;
using SpaceMonkey.ViewModels.Controls;
using SpaceMonkey.ViewModels.Helpers;
using SpaceMonkey.WebClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceMonkey.ViewModels.Main
{
    public class SpaceMonkeyCoreViewModel : BaseViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public int SearchRadius { get; set; }
        public int CategoryId { get; set; }
        public double ScaleFactor { get; set; }

        public static SpaceMonkeyCoreViewModel Instance;

        

        public ICommand GetSatellitesCommand { get; set; }
        public ICommand BakeAllCommand { get; set; }
        private SpaceMonkeyWebClient Client;

        public ObservableCollection<SatelliteCardViewModel> Satellites { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<string> Scales { get; set; }

        public SpaceMonkeyCoreViewModel()
        {
            string apiKey = string.Empty;
            using(StreamReader reader = new StreamReader("secrets.json"))
            {
                string json = reader.ReadToEnd();
                SmSecrets secrets = JsonConvert.DeserializeObject<SmSecrets>(json);
                apiKey = secrets.ApiKey;
            }
            this.Satellites = new ObservableCollection<SatelliteCardViewModel>();
            this.Categories = new ObservableCollection<string>(CategoryIdHelper.GetCategories());
            this.Scales = new ObservableCollection<string>(ScaleFactorHelper.GetScales());
            this.Client = new SpaceMonkeyWebClient(apiKey);
            this.GetSatellitesCommand = new RelayCommand(this.GetSatellites);
            this.BakeAllCommand = new RelayCommand(this.BakeAll);
            this.SearchRadius = 70;
            this.CategoryId = 0;
            this.ScaleFactor = 0.001;
            Instance = this;
        }


        public async void GetSatellites()
        {
            SmAboveResponse response = await this.Client.GetAboveSatellites(this.Latitude, this.Longitude, this.Altitude, this.SearchRadius, this.CategoryId);
            this.Satellites.Clear();
            if (response != null)
            {
                foreach (SmSatellite sat in response.Above)
                {
                    if (sat.SatAlt <= 500000)
                    {
                        var vmodel = new SatelliteCardViewModel(sat);
                        vmodel.BakeTriggered += SatelliteCard_BakeTriggered;
                        this.Satellites.Add(vmodel);
                    }
                }
            }
        }

        public EventHandler BakeTriggered;
        public void OnBakeTriggered(BakeTriggeredEventArgs e)
        {
            EventHandler handler = BakeTriggered;
            handler?.Invoke(this, e);
        }

        private void SatelliteCard_BakeTriggered(object sender, EventArgs e)
        {
            BakeTriggeredEventArgs args = e as BakeTriggeredEventArgs;
            OnBakeTriggered(args);
        }

        public void BakeAll()
        {
            BakeTriggeredEventArgs args = new BakeTriggeredEventArgs(this.Satellites.Select(o => o.ToSmSatellite()).ToList());
            this.OnBakeTriggered(args);
        }


    }
}
