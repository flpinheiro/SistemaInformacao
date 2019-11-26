using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusExpress.Model
{
    public class Route :BaseEntity
    {
        [MaxLength(25)]
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int StartPointId { get; set; }
        public BusStop StartPoint { get; set; }
        public int EndPointId { get; set; }
        public BusStop EndPoint { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        
        public IList<RouteLine> RouteLine { get; set; }
        public Route()
        {
            RouteLine = new List<RouteLine>();
        }
    }
}
