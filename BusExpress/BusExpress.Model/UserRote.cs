using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    class UserRote
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoutesId { get; set; }
        public Route Route { get; set; }
    }
}
