using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class Route
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Location StartPoint { get; set; }
        public Location EndPoint { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }

        public IList<BusLine> Lines { get; set; }
        public Route()
        {
            Lines = new List<BusLine>();
        }
    }
}
