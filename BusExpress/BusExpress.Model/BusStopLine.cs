using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class BusStopLine
    {
        /// <summary>
        /// Primeira parte do numero da linha de onibus XXXX.YY
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// segunda parte do numero da linha de onibus XXXX.YY
        /// </summary>
        public int DotNumber { get; set; }
        public ICollection<BusStop> BusStop { get; set; }
        public ICollection<BusLine> BusLine { get; set; }
        public int BusStopId { get; set; }

    }
}
