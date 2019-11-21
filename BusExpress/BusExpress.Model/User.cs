using System;
using System.Collections.Generic;

namespace BusExpress.Model
{
    public class User :BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Card Card { get; set; }

        public IList<Route> Routes { get; set; }

        public User()
        {
            Routes = new List<Route>();
        }
    }
}
