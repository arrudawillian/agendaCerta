using System.ComponentModel.DataAnnotations;

namespace AgendaCerta.Services.DTOs
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O telefone deve ter 10 ou 11 dígitos")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
    }
}