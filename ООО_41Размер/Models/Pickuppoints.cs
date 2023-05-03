using System;
using System.Collections.Generic;

namespace ООО_41Размер.Models
{
    public partial class Pickuppoints
    {
        public Pickuppoints()
        {
            Orders = new HashSet<Orders>();
        }

        public int PickupPointId { get; set; }
        public int PickupPointIndex { get; set; }
        public string PickupPointAdress { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
