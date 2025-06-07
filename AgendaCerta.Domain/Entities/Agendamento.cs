using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaCerta.Domain.Entities
{
    public class Agendamento
    {
        public Agendamento() { }

        public Agendamento(int clienteId, int atendenteId, DateTime dataHora, string status)
        {
            ClienteId = clienteId;
            AtendenteId = atendenteId;
            DataHora = dataHora;
            Status = status;
            DataCriacao = DateTime.Now;
            Observacao = string.Empty;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int AtendenteId { get; set; }

        [Required(ErrorMessage = "A data e hora do agendamento são obrigatórias")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Observacao { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [ForeignKey("AtendenteId")]
        public Atendente Atendente { get; set; }
    }
}