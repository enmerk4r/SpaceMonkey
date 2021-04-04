using SpaceMonkey.IO.EventArguments;
using SpaceMonkey.IO.Schemas;
using SpaceMonkey.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceMonkey.ViewModels.Controls
{
    public class SatelliteCardViewModel : BaseViewModel
    {
        public int SatelliteID { get; set; }
        public string SatelliteName { get; set; }
        public string InternationalDesignator { get; set; }
        public string LaunchDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }

        public ICommand BakeCommand { get; set; }

        public SatelliteCardViewModel(SmSatellite sat)
        {
            this.Initialize(sat.SatId, sat.SatName, sat.IntDesignator, sat.LaunchDate, sat.SatLat, sat.SatLng, sat.SatAlt);
        }

        public SmSatellite ToSmSatellite()
        {
            return new SmSatellite()
            {
                SatId = this.SatelliteID,
                SatName = this.SatelliteName,
                IntDesignator = this.InternationalDesignator,
                LaunchDate = this.LaunchDate,
                SatLat = this.Latitude,
                SatLng = this.Longitude,
                SatAlt = this.Altitude
            };
        }

        public void Initialize(
            int satId, 
            string satName, 
            string intDesignator, 
            string launchDate, 
            double satLat,
            double satLng,
            double satAlt)
        {
            this.SatelliteID = satId;
            this.SatelliteName = satName;
            this.InternationalDesignator = intDesignator;
            this.LaunchDate = launchDate;
            this.Latitude = satLat;
            this.Longitude = satLng;
            this.Altitude = satAlt;

            this.BakeCommand = new RelayCommand(this.Bake);
        }

        public EventHandler BakeTriggered;
        public void OnBakeTriggered(BakeTriggeredEventArgs e)
        {
            EventHandler handler = BakeTriggered;
            handler?.Invoke(this, e);
        }

        public void Bake()
        {
            this.OnBakeTriggered(new BakeTriggeredEventArgs(new List<SmSatellite>() { this.ToSmSatellite() }));
        }

    }
}
