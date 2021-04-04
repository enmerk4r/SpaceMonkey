using SpaceMonkey.IO.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMonkey.IO.EventArguments
{
    public class BakeTriggeredEventArgs : EventArgs
    {
        public List<SmSatellite> Satellites { get; set; }
        public BakeTriggeredEventArgs(List<SmSatellite> sats)
        {
            this.Satellites = sats;
        }
    }
}
