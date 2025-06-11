using System.Net.Http.Json;
using System.Text.Json;
using AgendaCerta.Services.DTOs;

namespace MCPServer
{
    public class AgendaCertaApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public AgendaCertaApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        #region Cliente Methods
        
        public async Task<List<ClienteResponse>> ObterClientesAsync()
        {
            var response = await _httpClient.GetAsync("cliente");
            
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<ClienteResponse>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ClienteResponse>>(_jsonOptions) ?? new List<ClienteResponse>();
        }

        public async Task<ClienteResponse?> ObterClientePorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"cliente/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteResponse>(_jsonOptions);
        }

        public async Task<ClienteResponse?> ObterClientePorCPFAsync(string cpf)
        {
            var response = await _httpClient.GetAsync($"cliente/cpf/{Uri.EscapeDataString(cpf)}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteResponse>(_jsonOptions);
        }

        public async Task<ClienteResponse?> ObterClientePorEmailAsync(string email)
        {
            var response = await _httpClient.GetAsync($"cliente/email/{Uri.EscapeDataString(email)}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteResponse>(_jsonOptions);
        }

        public async Task<ClienteResponse?> CriarClienteAsync(ClienteRequest cliente)
        {
            var response = await _httpClient.PostAsJsonAsync("cliente", cliente);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ClienteResponse>(_jsonOptions);
        }

        public async Task<ClienteResponse?> AtualizarClienteAsync(int id, ClienteRequest cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"cliente/{id}", cliente);
            
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ClienteResponse>(_jsonOptions);
        }

        public async Task<bool> ExcluirClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"cliente/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return false;

            response.EnsureSuccessStatusCode();
            return true;
        }

        #endregion

        #region Atendente Methods

        public async Task<List<AtendenteResponse>> ObterAtendentesAsync()
        {
            var response = await _httpClient.GetAsync("atendente");
            
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<AtendenteResponse>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AtendenteResponse>>(_jsonOptions) ?? new List<AtendenteResponse>();
        }

        public async Task<AtendenteResponse?> ObterAtendentePorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"atendente/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AtendenteResponse>(_jsonOptions);
        }

        public async Task<AtendenteResponse?> ObterAtendentePorCPFAsync(string cpf)
        {
            var response = await _httpClient.GetAsync($"atendente/cpf/{Uri.EscapeDataString(cpf)}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AtendenteResponse>(_jsonOptions);
        }

        public async Task<List<AtendenteResponse>> ObterAtendentesPorEspecialidadeAsync(string especialidade)
        {
            var response = await _httpClient.GetAsync($"atendente/especialidade/{Uri.EscapeDataString(especialidade)}");
            
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<AtendenteResponse>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AtendenteResponse>>(_jsonOptions) ?? new List<AtendenteResponse>();
        }

        public async Task<AtendenteResponse?> CriarAtendenteAsync(AtendenteRequest atendente)
        {
            var response = await _httpClient.PostAsJsonAsync("atendente", atendente);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AtendenteResponse>(_jsonOptions);
        }

        public async Task<AtendenteResponse?> AtualizarAtendenteAsync(int id, AtendenteRequest atendente)
        {
            var response = await _httpClient.PutAsJsonAsync($"atendente/{id}", atendente);
            
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AtendenteResponse>(_jsonOptions);
        }

        public async Task<bool> ExcluirAtendenteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"atendente/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        }

        #endregion

        #region Agendamento Methods

        public async Task<List<AgendamentoResponse>> ObterAgendamentosAsync()
        {
            var response = await _httpClient.GetAsync("agendamento");
            
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<AgendamentoResponse>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AgendamentoResponse>>(_jsonOptions) ?? new List<AgendamentoResponse>();
        }

        public async Task<AgendamentoResponse?> ObterAgendamentoPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"agendamento/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AgendamentoResponse>(_jsonOptions);
        }

        public async Task<List<AgendamentoResponse>> ObterAgendamentosPorClienteAsync(int clienteId)
        {
            var response = await _httpClient.GetAsync($"agendamento/cliente/{clienteId}");
            
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<AgendamentoResponse>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AgendamentoResponse>>(_jsonOptions) ?? new List<AgendamentoResponse>();
        }

        public async Task<List<AgendamentoResponse>> ObterAgendamentosPorAtendenteAsync(int atendenteId)
        {
            var response = await _httpClient.GetAsync($"agendamento/atendente/{atendenteId}");
            
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<AgendamentoResponse>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AgendamentoResponse>>(_jsonOptions) ?? new List<AgendamentoResponse>();
        }

        public async Task<List<AgendamentoResponse>> ObterAgendamentosPorDataAsync(DateTime data)
        {
            var dataFormatada = data.ToString("yyyy-MM-dd");
            var response = await _httpClient.GetAsync($"agendamento/data/{dataFormatada}");
            
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<AgendamentoResponse>();

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<AgendamentoResponse>>(_jsonOptions) ?? new List<AgendamentoResponse>();
        }

        public async Task<AgendamentoResponse?> CriarAgendamentoAsync(AgendamentoRequest agendamento)
        {
            var response = await _httpClient.PostAsJsonAsync("agendamento", agendamento);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AgendamentoResponse>(_jsonOptions);
        }

        public async Task<AgendamentoResponse?> AtualizarAgendamentoAsync(int id, AgendamentoUpdateRequest agendamento)
        {
            var response = await _httpClient.PutAsJsonAsync($"agendamento/{id}", agendamento);
            
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<AgendamentoResponse>(_jsonOptions);
        }

        public async Task<bool> ExcluirAgendamentoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"agendamento/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        }

        #endregion
    }
}