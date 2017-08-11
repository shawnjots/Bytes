using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bytes.Models
{
    public class Product
    {
        private int productID;
        private string productname;
        private decimal buyingPrice;
        private decimal sellingPrice;
        private DateTime purchaseDate;
        private DateTime expiryDate;
        private string description;
  
        [Key]
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        [Required(ErrorMessage = "Please provide product name")]
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }

        [Key]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        
        [Required(ErrorMessage = "Please provide buying price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal BuyingPrice
        {
            get { return buyingPrice; }
            set { buyingPrice = value; }
        }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SellingPrice
        {
            get { return sellingPrice; }
            set { sellingPrice = value; }
        }

        [Required(ErrorMessage = "Please provide purchase date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        [Required(ErrorMessage = "Please provide expiry date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}