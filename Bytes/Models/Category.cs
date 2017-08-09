using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bytes.Models
{
    public class Category
    {
        private int categoryID;
        private string categoryName;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        [Required(ErrorMessage = "Please provide category name")]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}