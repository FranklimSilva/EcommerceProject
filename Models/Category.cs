using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Categoria ID")]
        public int CategoryId { get; set; }

        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Required(ErrorMessage = "O campo 'Categoria' é requerido!!")]
        [Display(Name = "Categoria")]
        [Index("Category_Descripition_CompanyId_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo 'Distribuidora' é requerido!!")]
        [Index("Category_Descripition_CompanyId_Index", 1, IsUnique = true)]
        [Display(Name = "Distribuidoras")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma  Distribuidora!")]
        public int CompanyId { get; set; }

        public virtual Company Companys { get; set; }

    }
}