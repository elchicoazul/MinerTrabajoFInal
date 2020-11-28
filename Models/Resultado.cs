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
        public string Id  { get; set; }
        [Column("idcliente")]
        public string idcliente { get; set; }
        [Column("numerorecpcion")]
        public string numerorecpcion { get; set; }
        [Column("tipo_analisis")]
        public string tipo_analisis  { get; set; }        
        [Column("muestra")]
        public string muestra  { get; set; }
        [Column("precio")]
        public string precio  { get; set; }
        [Column("cantidad")]
        public string cantidad  { get; set; }
        [Column("valor")]
        public string valor  { get; set; } 
    }
}