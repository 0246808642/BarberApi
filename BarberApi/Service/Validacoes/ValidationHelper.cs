using System.ComponentModel.DataAnnotations;

namespace BarberApi.Service.Validacoes
{
    public static class ValidationHelper
    {
        // ✅ Método que será chamado para validar
        public static ValidationResult ValidateDataAgendamento(DateTime dataHora, ValidationContext context)
        {
            var agora = DateTime.Now;

            // Regra 1: Não pode agendar no passado
            if (dataHora <= agora)
                return new ValidationResult("Data e hora devem ser no futuro");

            // Regra 2: Horário comercial
            if (dataHora.Hour < 8 || dataHora.Hour >= 18)
                return new ValidationResult("Agendamentos apenas das 08:00 às 17:59");

            // Regra 3: Não aos domingos
            if (dataHora.DayOfWeek == DayOfWeek.Sunday)
                return new ValidationResult("Não atendemos aos domingos");

            // ✅ Passou em todas as validações
            return ValidationResult.Success;
        }
    }
}
