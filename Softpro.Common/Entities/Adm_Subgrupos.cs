using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Softpro.Common.Entities
{
    public class Adm_Subgrupos
    {
        [Key]
        [MaxLength(4, ErrorMessage = "El campo {0} solo puede tener un maximo de {1} caracteres")]
        public string  SubgrupoID { get; set; }

        [MaxLength(250, ErrorMessage = "El campo {0} solo puede tener un maximo de {1} caracteres")]
        [Display(Name = "Nombre del subgrupo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string  Subgrupo { get; set; }
    }
}
