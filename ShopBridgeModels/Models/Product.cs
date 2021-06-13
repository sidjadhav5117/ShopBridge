using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopBridgeModels.Models
{
    public class Product
    {
        /// <summary>
        /// The unique id of the product.
        /// </summary>
        [Key]
        public long Id { get; set; }
        
        /// <summary>
        /// The name of the product.
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Product Name should be of length 50 only.")]
        public string ProductName { get; set; }

        /// <summary>
        /// The code of the product.
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        [StringLength(20, ErrorMessage = "Product Code should be of length 20 only.")]
        public string ProductCode { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100, ErrorMessage = "Description should be of length 50 only.")]
        public string Description { get; set; }

        /// <summary>
        /// The purchase cost of the product.
        /// </summary>
        [Column(TypeName = "decimal(7,2)")]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The selling cost of the selling.
        /// </summary>
        [Column(TypeName = "decimal(7,2)")]
        public decimal SellingCost { get; set; }

        /// <summary>
        /// The created date of the product.
        /// </summary>
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The updated dated of hte product.
        /// </summary>
        [Column(TypeName = "DateTime2")]
        public DateTime UpdatedDate { get; set; }
    }
}
