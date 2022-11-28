using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Customer
    {
        [Key]
        public int CustumerId { get; set; }

        public virtual Category categories { get; set; }
        [Required(ErrorMessage = "O campo 'E-Mail' é requerido!!")]
        [MaxLength(250, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é requerido!!")]
        [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo 'Sobrenome' é requerido!!")]
        [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' é requerido!!")]
        [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo 'Endereço' é requerido!!")]
        [MaxLength(100, ErrorMessage = "Você ultrapassou o limite de caracteres")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public int CompanyId { get; set; }
        public int CityId { get; set; }
        public virtual Departaments Departments { get; set; }
        public virtual City Cities { get; set; }
        public virtual Company Companies { get; set; }
    }
}