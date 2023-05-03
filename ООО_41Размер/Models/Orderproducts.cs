using System;
using System.Collections.Generic;

namespace ООО_41Размер.Models
{
    public partial class Orderproducts
    {
        public int OrderId { get; set; }
        public string ProductArticleNumber { get; set; }
        public int OrderQuantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products ProductArticleNumberNavigation { get; set; }
    }
}
