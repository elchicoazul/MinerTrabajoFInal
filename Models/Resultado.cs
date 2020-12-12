using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinerTrabajoFInal.Models
{
    [Table("recepcion")]    
    public class Resultado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id  { get; set; }
        [Column("idcliente")]
        [Display(Name="Nombre CLiente")]
        public int idcliente { get; set; }
        [Column("numerorecpcion")]
        public int numerorecpcion { get; set; }
        [Column("tipo_analisis")]
        public string tipo_analisis  { get; set; }        
        [Column("muestra")]
        public string muestra  { get; set; }
        [Column("precio")]
        public double precio  { get; set; }
        [Column("cantidad")]
        public int cantidad  { get; set; }
        [Column("valor")]
        public string valor  { get; set; } 
    }
}