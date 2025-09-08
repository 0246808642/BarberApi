using BarberApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.ServicoDto
{
    public class ReadServicoDto
    {
        public long Id { get; set; }
        public ServicosEnum NomeServico { get; set; }
        public string? Descricao { get; set; }
        public int DuracaoMin { get; set; }
        public decimal Preco { get; set; }
    }
}
