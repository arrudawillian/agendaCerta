namespace AgendaCerta.Services.DTOs
{
    public class AgendamentoResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int AtendenteId { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        // DTOs simplificados para evitar recursão
        public ClienteResponse? Cliente { get; set; }
        public AtendenteResponse? Atendente { get; set; }
    }
}