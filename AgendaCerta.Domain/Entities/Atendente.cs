using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AgendaCerta.Domain.Entities
{
    [Index(nameof(CPF), IsUnique = true)]
    public class Atendente
    {
        public Atendente() { }

        public Atendente(string nome, string email, string telefone, string cpf, DateTime dataNascimento, string especialidade)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Especialidade = especialidade;
            DataContratacao = DateTime.Now;
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
        public string CPF { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória")]
        [StringLength(100)]
        public string Especialidade { get; set; }

        public DateTime DataContratacao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}