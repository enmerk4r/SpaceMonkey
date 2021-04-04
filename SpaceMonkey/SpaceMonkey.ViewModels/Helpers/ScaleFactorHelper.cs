using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.ViewModels.Helpers
{
    
    public static class ScaleFactorHelper
    {
        public static List<string> GetScales()
        {
            List<string> cats = ScaleDict.Keys.ToList();
            cats.Sort();
            return cats;
        }

        public static double ScaleToDouble(string scale)
        {
            if (scale != null)
            {
                if (ScaleDict.ContainsKey(scale))
                {
                    return ScaleDict[scale];
                }
            }
            return 0;
        }

        public static string DoubleToScale(double sc)
        {
            foreach (KeyValuePair<string, double> p in ScaleDict)
            {
                if (p.Value == sc) return p.Key;
            }
            return string.Empty;
        }

        public static Dictionary<string, double> ScaleDict = new Dictionary<string, double>()
        {
            {"1:1", 1 },
            {"1:10", 0.1 },
            {"1:100", 0.01 },
            {"1:1000", 0.001 }
        };
    }
}
