using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Display(Name = "Numero do Pedido")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Produto ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="O campo {0} é requerido")]
        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name="Produto")]
        public string Description { get; set; }

        [Display(Name = "Imposto")]
        [Required(ErrorMessage = "O campo 'Imposto' é requerido!!")]
        [Range(0, 1, ErrorMessage = "Apenas valores de 0 a 1")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public double TaxRate { get; set; }

        [Display(Name = "Valor")]
        [Range(0, double.MaxValue,ErrorMessage = "Apenas valores de 0 a 1")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public double Price { get; set; }

        [Display(Name="Quantidade")]
        [Range(0, double.MaxValue, ErrorMessage = "Apenas valores de 0 a 1")]
        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode = false)]
         public int Quantity { get; set; }
        public virtual Order Orders { get; set; }
        public virtual Product Product { get; set; }
    }
}