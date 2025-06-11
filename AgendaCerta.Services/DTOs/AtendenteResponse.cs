namespace AgendaCerta.Services.DTOs
{
    public class AtendenteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Especialidade { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
    }
}