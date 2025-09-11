using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class LibroFormCLS
    {
        // Propiedades existentes
 
        public int idLibro { get; set; }

        [Required(ErrorMessage = "El titulo es requerido.")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del título es de 100 caracteres.")]
        public string titulo { get; set; } = null!;

        [Required(ErrorMessage = "El resumen es requerido.")]
        [MinLength(20, ErrorMessage = "La longitud mínima del resumen es de 20 caracteres.")]
        public string resumen { get; set; } = null!;

        // Nueva propiedad para Tipo de Libro
       [Required(ErrorMessage = "El tipo de libro es requerido.")]
        public int idTipoLibro { get; set; }  

        public string? nombreTipoLibro { get; set; }  



        public byte[]? image { get; set; }
    }
}
