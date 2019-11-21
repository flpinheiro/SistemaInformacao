using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class UserRote
    {
        public int UserId { get; set; }
        public virtual ICollection<User> User { get; set; }
        public int RoutesId { get; set; }
        public virtual ICollection<Route> Route { get; set; }
    }
}
