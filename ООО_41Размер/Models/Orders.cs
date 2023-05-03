using System;
using System.Collections.Generic;

namespace ООО_41Размер.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Orderproducts = new HashSet<Orderproducts>();
        }

        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public int OrderPickupPoint { get; set; }
        public int UserId { get; set; }
        public int OrderCode { get; set; }

        public virtual Pickuppoints OrderPickupPointNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Orderproducts> Orderproducts { get; set; }
    }
}
