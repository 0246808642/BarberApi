using BarberApi.Service.Validacoes;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.AgendamentoDto
{
    public class UpdateAgendamentoDto
    {
        [Required]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Data e hora são obrigatórias")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Hora do Agendamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(ValidationHelper), nameof(ValidationHelper.ValidateDataAgendamento))]
        public DateTime DataHora { get; set; }

        [StringLength(300, ErrorMessage = "Observações não podem exceder {300} caracteres")]
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "Status inválido")]
        public int Status { get; set; } = 2;
    }
}
