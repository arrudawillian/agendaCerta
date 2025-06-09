using System.ComponentModel.DataAnnotations;

namespace AgendaCerta.Services.DTOs
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}