using System;
using System.Collections.Generic;

namespace ООО_41Размер.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        public int SupplierId { get; set; }
        public string ProductSupplier { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
