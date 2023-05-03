using System;
using System.Collections.Generic;

namespace ООО_41Размер.Models
{
    public partial class Categorys
    {
        public Categorys()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string ProductCategory { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
