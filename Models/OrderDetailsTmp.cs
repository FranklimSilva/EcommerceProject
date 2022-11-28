using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class OrderDetailsTmp
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "O campo 'E-Mail' é requerido!!")]
        [MaxLength(256, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Display(Name = "Produto ID")]
        [Required(ErrorMessage = "O campo '{0}' é requerido!!")]
        public int ProductId { get; set; }

        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Required(ErrorMessage = "O campo {0} é requerido!!")]
        [Display(Name = "Produto")]
        public string Description { get; set; }

        [Display(Name = "Taxa")]
        [Required(ErrorMessage = "O campo 'Taxa' é requerido!!")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public double TaxRate { get; set; }


        [Required(ErrorMessage = "O campo {0} é requerido!!")]
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage ="Entre com um valor maior que 0!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido!!")]
        [Display(Name = "Quantidade")]
        //[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Entre com um valor maior que 0!")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é requerido!!")]
        [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo 'Sobrenome' é requerido!!")]
        [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo 'Endereço' é requerido!!")]
        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Value { get { return Price * (decimal)Quantity; } }

        public virtual Product Product { get;set; }
    }
}