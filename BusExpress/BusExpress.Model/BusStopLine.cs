using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class BusStopLine
    {
        public int BusStopId { get; set; }
        public BusStop BusStop { get; set; }

        public BusLine BusLine { get; set; }
        public int BusLineId { get; set; }

    }
}
