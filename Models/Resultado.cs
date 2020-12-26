using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinerTrabajoFInal.Models
{
    [Table("T_recepcion")]    
    public class Resultado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id  { get; set; }
        [Column("idcliente")]
        [Display(Name="Nombre CLiente")]
        public int idcliente { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un numero de recepcion")] 
        [Column("numerorecpcion")]
        [Display(Name="Numero de Recepcion")]
        public int numerorecpcion { get; set; }
        [Column("tipo_analisis")]
        [Display(Name="Tipo de Analisis")]
        public string tipo_analisis  { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una muestra")]         
        [Column("muestra")]
        [Display(Name="Muestra")]
        public string muestra  { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un precio")] 
        [Column("precio")]
        [Display(Name="Precio")]
        public double precio  { get; set; }
        [Required(ErrorMessage = "Por favor ingrese una cantidad")] 
        [Column("cantidad")]
        [Display(Name="Cantidad")]
        public int cantidad  { get; set; }
        [Column("valor")]
        public string valor  { get; set; } 
    }
}