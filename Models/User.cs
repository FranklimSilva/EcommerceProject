using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

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

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Required(ErrorMessage = "O campo 'Departamento' é requerido!!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo 'Cidade' é requerido!!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo 'Companhia' é requerido!!")]
        [Display(Name = "Companhia")]
        public int CompanyId { get; set; }
        [Display(Name = "Usuário")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual Departaments Departments { get; set; }
        public virtual City Cities { get; set; }
        public virtual Company Companies { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}