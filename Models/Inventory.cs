using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Inventory
    {
        [Key]
        [Display(Name="Inventário")]
        public int InventoryId { get; set; }
        [Display(Name = "Produto ID")]
        public int ProductId { get; set; }
        [Display(Name="Armazem")]
        public int WareHouseId { get; set; }
        [Display(Name="Estoque")]
        public double Stock { get; set; }
    }
}