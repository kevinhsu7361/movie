using System;
using System.Collections.Generic;

#nullable disable

namespace movie.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int MemberShipId { get; set; }

        public virtual MemberShip MemberShip { get; set; }
    }
}
