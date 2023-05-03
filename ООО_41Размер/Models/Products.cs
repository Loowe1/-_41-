using System;
using System.Collections.Generic;

namespace ООО_41Размер.Models
{
    public partial class Products
    {
        public Products()
        {
            Orderproducts = new HashSet<Orderproducts>();
        }

        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategory { get; set; }
        public byte[] ProductPhoto { get; set; }
        public int ProductManufacturer { get; set; }
        public decimal ProductCost { get; set; }
        public sbyte? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set; }
        public int ProductUnit { get; set; }
        public int ProductSupplier { get; set; }
        public sbyte? ProductMaxDiscountAmount { get; set; }

        public virtual Categorys ProductCategoryNavigation { get; set; }
        public virtual Manufacturers ProductManufacturerNavigation { get; set; }
        public virtual Suppliers ProductSupplierNavigation { get; set; }
        public virtual Units ProductUnitNavigation { get; set; }
        public virtual ICollection<Orderproducts> Orderproducts { get; set; }
    }
}
