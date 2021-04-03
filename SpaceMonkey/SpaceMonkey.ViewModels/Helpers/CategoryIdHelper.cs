using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.ViewModels.Helpers
{
    public static class CategoryIdHelper
    {
        public static List<string> GetCategories()
        {
            List<string> cats = CategoryDict.Keys.ToList();
            cats.Sort();
            return cats;
        }

        public static int CategoryToId(string cat)
        {
            if (CategoryDict.ContainsKey(cat))
            {
                return CategoryDict[cat];
            }
            else return -1;
        }

        private static Dictionary<string, int> CategoryDict { get; set; } = new Dictionary<string, int>()
        {
            {"Amateur radio", 18},
            {"Beidou Navigation System", 35},
            {"Brightest", 1},
            {"Celestis", 45},
            {"CubeSats", 32},
            {"Disaster monitoring", 8},
            {"Earth resources", 6},
            {"Education", 29 },
            {"Engineering", 28 },
            {"Experimental", 19 },
            {"Flock", 48 },
            {"Galileo", 22 },
            {"Geodetic", 27 },
            {"Geostationary", 10 },
            {"Global Positioning System (GPS) Constellation", 50},
            {"Global Positioning System (GPS) Operational", 20 },
            {"Globalstar", 17 },
            {"Glonass Constellation", 51 },
            {"Glonass Operational", 21 },
            {"GOES", 5 },
            {"Gonets", 40 },
            {"Gorizont", 12 },
            {"Intelsat", 11 },
            {"Iridium", 15 },
            {"IRNSS", 46 },
            {"ISS", 1 },
            {"Lemur", 49 },
            {"Military", 30 },
            {"Molniya", 14 },
            {"Navy Navigation Satellite System", 24 },
            {"NOAA", 4 },
            {"O3B Networks", 43 },
            {"OneWeb", 53 },
            {"Orbcomm", 16 },
            {"Parus", 38 },
            {"QZSS", 47 },
            {"Radar Calibration", 31 },
            {"Raduga", 13 },
            {"Russian LEO Navigation", 25 },
            {"Satellite-Based Augmentation System", 23 },
            {"Search & rescue", 7 },
            {"Space & Earth Science", 26 },
            {"Starlink", 52 },
            {"Strela", 39 },
            {"Tracking and Data Relay Satellite System", 9 },
            {"Tselina", 44 },
            {"Tsikada", 42 },
            {"Tsiklon", 41 },
            {"TV", 34 },
            {"Weather", 3 },
            {"Westford Needles", 37 },
            {"XM and Sirius", 33 },
            {"Yaogan", 36 }
        };
    }
}
