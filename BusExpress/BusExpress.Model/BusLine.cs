using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class BusLine
    {
        public string Name { get; set; }
        /// <summary>
        /// Primeira parte do numero da linha de onibus XXXX.YY
        /// </summary>
        public ushort Number { get; set; }
        /// <summary>
        /// segunda parte do numero da linha de onibus XXXX.YY
        /// </summary>
        public byte DotNumber { get; set; }

        public IList<BusStopLine> BusStopLine { get; set; }

        public BusLine()
        {
            BusStopLine = new List<BusStopLine>();
        }
    }
}
