using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class City
    {
        [Key]
        [Display(Name = "Cidade ID")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é requerido!!")]
        [Display(Name="Cidade")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo 'Departamento' é requerido!!")]
        [Range(1,double.MaxValue, ErrorMessage ="Selecione um Departamento!")]
        [Display(Name="Departamento")]
        public int DepartamentsId { get; set; }

        public virtual Departaments Departament { get; set; }
        public virtual ICollection<Company> Companys { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<WareHouse> WareHouses { get; set; }


    }
}