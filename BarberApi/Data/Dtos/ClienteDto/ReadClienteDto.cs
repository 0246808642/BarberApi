using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.ClienteDto
{
    public class ReadClienteDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime HoraCriacao { get; set; } = DateTime.Now;
    }
}
