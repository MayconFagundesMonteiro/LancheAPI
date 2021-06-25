using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LancheAPI.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime MomentoVenda { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
