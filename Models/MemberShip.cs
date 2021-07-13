using System;
using System.Collections.Generic;

#nullable disable

namespace movie.Models
{
    public partial class MemberShip
    {
        public MemberShip()
        {
            Customers = new HashSet<Customer>();
        }

        public int MemberShipId { get; set; }
        public string MemberShipName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
