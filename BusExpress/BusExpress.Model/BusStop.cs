using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class BusStop : BaseEntity
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public BusStopLine BusStopLine { get; set; }

        //public BusStop()
        //{
        //    BusStopLine = new List<BusStopLine>();
        //}
    }
}
