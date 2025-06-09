using System.ComponentModel.DataAnnotations;

namespace AgendaCerta.Services.DTOs
{
    public class AgendamentoUpdateRequest
    {
        [Required]
        public int AtendenteId { get; set; }

        [Required(ErrorMessage = "A data e hora do agendamento são obrigatórias")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        [StringLength(50)]
        public string Status { get; set; } = string.Empty;

        [StringLength(500)]
        public string Observacao { get; set; } = string.Empty;
    }
}