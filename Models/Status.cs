using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Required(ErrorMessage = "O campo 'Descrição' é requerido!!")]
        [Display(Name = "Descrição")]
        [Index("Status_Descripition_CompanyId_Index", 1, IsUnique = true)]
        public string Description { get; set; }

        public virtual OrderDetailsTmp OrderDetailsTmp { get; set; }
    }
}