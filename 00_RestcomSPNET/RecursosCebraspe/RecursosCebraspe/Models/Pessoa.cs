using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosCebraspe.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Cpf")]
        public Int64 Cpf { get; set; }
        [Column("atendimentoespecial")]
        public bool AtentimentoEspeceial { get; set; }

    }
}
