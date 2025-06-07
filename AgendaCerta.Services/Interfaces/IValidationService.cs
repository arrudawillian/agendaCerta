namespace AgendaCerta.Services.Interfaces
{
    public interface IValidationService
    {
        Task<bool> IsCPFUniqueAsync(string cpf);
    }
}