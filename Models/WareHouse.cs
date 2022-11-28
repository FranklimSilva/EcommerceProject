using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class WareHouse
    {
        [Key]
        [Display(Name="Armazem")]
        public int WareHouseId { get; set; }

        [Required(ErrorMessage = "O campo 'Companhia' é requerido!!")]
        [Display(Name = "Companhia")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é requerido!!")]
        [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' é requerido!!")]
        [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo 'Endereço' é requerido!!")]
        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O campo 'Departamento' é requerido!!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo 'Cidade' é requerido!!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        public virtual Departaments Departments { get; set; }
        public virtual City Cities { get; set; }
        public virtual Company Companies { get; set; }
        public virtual Inventory Inventories { get; set; }
    }
}