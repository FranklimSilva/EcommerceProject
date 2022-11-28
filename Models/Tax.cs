using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Models
{
    public class Tax
    {
        [Key]
        [Display(Name = "Taxa ID")]
        public int TaxId { get; set; }

        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Required(ErrorMessage = "O campo 'Descrição' é requerido!!")]
        [Display(Name = "Descrição")]
        [Index("Category_Descripition_CompanyId_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Display(Name = "Imposto")]
        [Required(ErrorMessage = "O campo 'Descrição' é requerido!!")]
        [Range(0,1, ErrorMessage = "Apenas valores de 0 a 1")]
        [DisplayFormat(DataFormatString ="{0:P2}", ApplyFormatInEditMode =false)]
        public double Rate { get; set; }

        [Required(ErrorMessage = "O campo 'Distribuidora' é requerido!!")]
        [Index("Category_Descripition_CompanyId_Index", 1, IsUnique = true)]
        [Display(Name = "Distribuidoras")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma  Distribuidora!")]
        public int CompanyId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual Company Companys { get; set; }
    }
}