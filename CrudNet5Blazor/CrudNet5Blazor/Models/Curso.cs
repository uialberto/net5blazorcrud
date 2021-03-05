using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNet5Blazor.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es un dato requerido.")]
        [Display(Name = "Nombre del Curso")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo descripcion es un dato requerido.")]
        public string Descripcion { get; set; }
        
        [Required(ErrorMessage = "El campo precio es un dato requerido.")]
        //[Range(0, (double)decimal.MaxValue, ErrorMessage = "Introduzca un precio valido")]
        [RegularExpression(@"^\d+\,\d{0,2}$",ErrorMessage = "Formato incorrecto")]
        public decimal Precio { get; set; }
    }
}
