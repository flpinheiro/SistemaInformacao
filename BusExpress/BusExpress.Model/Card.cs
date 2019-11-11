using System;
using System.Collections.Generic;
using System.Text;

namespace BusExpress.Model
{
    public class Card
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int Code { get; set; }
        public decimal Balance { get; set; }

    }
}
