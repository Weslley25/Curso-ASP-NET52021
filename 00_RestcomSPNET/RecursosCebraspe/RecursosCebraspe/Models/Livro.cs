using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosCebraspe.Models
{
    [Table("Livro")]
    public class Livro :BaseEntity
    {
       
        [Column("Autor")]
        public string? Autor { get; set; }
        [Column("Data_lançamento")]
        public DateTime? DataLançamento { get; set; }
        [Column("preço")]
        public Decimal preço { get; set; }
        [Column("titulo")]
        public string? Titulo { get; set; }



    }
}
