using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int StateId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Comentarios")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
        [Display(Name="Detalhes")]
        public List<OrderDetailsTmp> Details { get; set; }
        public virtual Status StatusId { get; set; }
        public virtual Customer Customer {get;set;}
        public virtual NewOrderView NewOrderView { get; set; }
        public virtual OrderDetailsTmp OrderDetailsTmp { get; set; }
    }
}