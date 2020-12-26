using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinerTrabajoFInal.Models
{
    [Table("T_Muestras")]  
    public class Muestras
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id  { get; set; }

        [Column("Muestra")]
        [Display(Name="Muestra")]
        public string Muestra { get; set; }

        [Column("Descripcion")]
        [Display(Name="Descripcion")]
        public string Descripcion { get; set; }
        
        [Column("Img")]
        [Display(Name="Img")]
        public string Img { get; set; }
        
        [Column("Precio")]
        [Display(Name="Precio")]
        public double Precio { get; set; }
    }
}