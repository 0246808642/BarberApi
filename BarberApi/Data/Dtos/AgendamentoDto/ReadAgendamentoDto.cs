using BarberApi.Service;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.AgendamentoDto
{
    public class ReadAgendamentoDto
    {
        public int ClientId { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacoes { get; set; }
        public int Status { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
