using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class RouteLine
    {
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int BusLineId { get; set; }
        public BusLine BusLine { get; set; }

    }
}
