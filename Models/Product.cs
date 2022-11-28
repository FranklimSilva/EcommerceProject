using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerceProject.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Produto ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo 'Companhia' é requerido!!")]
        [Display(Name = "Companhia")]
        [Index("Product_Descripition_CompanyID_Index",1, IsUnique = true)]
        [Range(1, double.MaxValue, ErrorMessage ="Selecione uma Distribuidora!")]
        [Index("Product_BarCode_CompanyId_Index",1 , IsUnique = true)]

        public int CompanyId { get; set; }

        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Required(ErrorMessage = "O campo 'Descrição' é requerido!!")]
        [Display(Name = "Descrição")]
        [Index("Product_Descripition_Company_Index",2, IsUnique = true)]
        public string Description { get; set; }

        [Display(Name = "Código de Barras")]
        public string BarCode { get; set; }
        [Display(Name = "Estoque")]
        public double Stock { get { return 0; /*Inventory.Sum(i=>i.Stock)*/ } }

        [Required(ErrorMessage = "O campo {0} é requerido!!")]
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Entre com um valor maior que 0!")]
        public decimal Price { get; set; }

        [Display(Name = "Imposto")]
        [Required(ErrorMessage = "O campo 'Imposto' é requerido!!")]
        [Range(1, double.MaxValue, ErrorMessage = "Apenas valores de 0 a 1")]
        public double TaxId { get; set; }
        [Display(Name = "Imposto")]
        [Required(ErrorMessage = "O campo 'Descrição' é requerido!!")]
        [Range(0, 1, ErrorMessage = "Apenas valores de 0 a 1")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public double Tax { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Apenas valores de 0 a 1")]
        [Required(ErrorMessage = "O campo {0} é requerido!!")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual Tax taxies { get; set; }
        public virtual Category categories { get; set; }
        public virtual Company Companys { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails {get; set;}
        public virtual Inventory Inventories { get; set; }
    }
}