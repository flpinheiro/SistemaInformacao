using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Bus> Bus { get; set; }

        public Company()
        {
            Bus = new HashSet<Bus>();
        }
    }
}
