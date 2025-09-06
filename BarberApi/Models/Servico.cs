using System.ComponentModel.DataAnnotations;

namespace BarberApi.Models
{
    public class Servico
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Nome do serviço obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage ="O campo deve conter entre 5 caracteres a 100 caracteres")]
        public string NomeServico { get; set; }

        [MaxLength(300, ErrorMessage ="O valor máximo do campo é de 300 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [Range(5, 300,ErrorMessage ="A duração deve estar entre 5 minutos a 300 minutos")]
        public int DuracaoMin { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0.01, 999999.99, ErrorMessage = "Preço deve estar entre R$ 0,01 e R$ 999.999,99")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Formato de preço inválido")]
        public double Preco { get; set; }
    }
}
