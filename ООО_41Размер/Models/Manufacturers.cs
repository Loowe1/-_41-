using System;
using System.Collections.Generic;

namespace ООО_41Размер.Models
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Products = new HashSet<Products>();
        }

        public int ManufacturerId { get; set; }
        public string ProductManufacturer { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
