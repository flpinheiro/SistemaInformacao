using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusExpress.Model
{
    public class BusLine
    {
        [MaxLength(45)]
        public string Name { get; set; }
        /// <summary>
        /// Primeira parte do numero da linha de onibus XXXX.YY
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// segunda parte do numero da linha de onibus XXXX.YY
        /// </summary>
        public int DotNumber { get; set; }

        public BusStopLine BusStopLine { get; set; }

        //public BusLine()
        //{
        //    BusStopLine = new List<BusStopLine>();
        //}
    }
}
