using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LancheAPI.Models.ViewModels
{
    public class VendaViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public List<VendaItensViewModel> Lanches { get; set; }
        public DateTime MomentoVenda { get; set; }
        public decimal Total { get; set; }
    }
}
