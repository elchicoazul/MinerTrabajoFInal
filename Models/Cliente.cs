using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinerTrabajoFInal.Models
{
    [Table("T_clientes")]    
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una razon social")]   
        [Display(Name="Razon social: ")]
        [Column("razonsocial")]
        public string razonsocial { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese un dni")]   
        [Display(Name="DNI: ")]
        [Column("dni")]
        public int dni { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una direccion")]   
        [Display(Name="Direccion: ")]
        [Column("direccion")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un telefono")]   
        [Display(Name="Telefono: ")]
        [Column("telefono")]
        public int telefono { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un correo")]   
        [Display(Name="Correo: ")]
        [Column("correo")]
        [EmailAddress]
        public string correo { get; set; }
    }
}