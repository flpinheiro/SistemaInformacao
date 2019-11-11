using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class BusStop
    {
        public Location Location { get; set; }

        public IList<BusStopLine> BusStopLine { get; set; }

        public BusStop()
        {
            BusStopLine = new List<BusStopLine>();
        }
    }
}
