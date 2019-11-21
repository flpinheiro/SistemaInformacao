using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusExpress.Model
{
    [NotMapped]
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}
