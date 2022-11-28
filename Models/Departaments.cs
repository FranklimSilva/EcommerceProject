using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Departaments
    {
        [Key]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo 'Departamento' é requerido!!")]
        [MaxLength(50, ErrorMessage ="Você ultrapassou o limite de caracteres")]
        [Display(Name = "Departamento")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Company> Companys { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<WareHouse> WareHouses { get; set; }
    }
}