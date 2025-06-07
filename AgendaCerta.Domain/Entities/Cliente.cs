using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AgendaCerta.Domain.Entities
{
    [Index(nameof(Cpf), IsUnique = true)]
    public class Cliente
    {
        public Cliente() { }

        public Cliente(string nome, string email, string telefone, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Ativo = true;
            Agendamentos = new List<Agendamento>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}