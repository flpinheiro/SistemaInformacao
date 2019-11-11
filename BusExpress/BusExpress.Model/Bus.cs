using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusExpress.Model
{
    public class Bus
    {
        public string LicensePlate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [NotMapped]
        public Location RealTimeLocation { get; set; }

        public IList<BusStopLine> BusStopLine { get; set; }

        public Bus()
        {
            BusStopLine = new List<BusStopLine>();
        }

    }
}
