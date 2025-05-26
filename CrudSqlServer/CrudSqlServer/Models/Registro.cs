
using System.ComponentModel.DataAnnotations;

namespace CrudSqlServer.Models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombres { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El apellido Paterno es obligatorio")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El apellido Materno es obligatorio")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "La edad es obligatorio")]
        [Range(1, 100, ErrorMessage = "Edad fuera de rango")]
        public int Edad { get; set; }

        [Display(Name = "Numero de celular")]
        [Required(ErrorMessage = "El numero de celular es obligatorio")]
        public string Numero { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es valido")]
        public string Correo { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El sexo es obligatorio")]
        public string Sexo { get; set; }

        [Display(Name = "Estado civil")]
        [Required(ErrorMessage = "El estado civil es obligatorio")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Fecha de creación")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy : hh:mm:ss}")]
        public DateTime Creacion { get; set; } = DateTime.Now;
    }
}
