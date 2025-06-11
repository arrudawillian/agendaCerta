using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;
using AgendaCerta.Services.DTOs;

namespace MCPServer
{
    [McpServerToolType]
    public static class AgendaCertaTools
    {
        #region Cliente Tools

        [McpServerTool, Description("Busca todos os clientes cadastrados")]
        public static async Task<string> ObterClientes(AgendaCertaApiClient agendaCertaApiClient)
        {
            try
            {
                var clientes = await agendaCertaApiClient.ObterClientesAsync();
                return clientes.Count == 0
                    ? "Nenhum cliente encontrado"
                    : JsonSerializer.Serialize(clientes);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar clientes: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca um cliente pelo ID")]
        public static async Task<string> ObterClientePorId(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do cliente")] int id)
        {
            try
            {
                var cliente = await agendaCertaApiClient.ObterClientePorIdAsync(id);
                return cliente is null
                    ? "Cliente não encontrado"
                    : JsonSerializer.Serialize(cliente);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar cliente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca um cliente pelo CPF")]
        public static async Task<string> ObterClientePorCPF(AgendaCertaApiClient agendaCertaApiClient,
            [Description("CPF do cliente")] string cpf)
        {
            try
            {
                var cliente = await agendaCertaApiClient.ObterClientePorCPFAsync(cpf);
                return cliente is null
                    ? "Cliente não encontrado"
                    : JsonSerializer.Serialize(cliente);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar cliente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca um cliente pelo email")]
        public static async Task<string> ObterClientePorEmail(AgendaCertaApiClient agendaCertaApiClient,
            [Description("Email do cliente")] string email)
        {
            try
            {
                var cliente = await agendaCertaApiClient.ObterClientePorEmailAsync(email);
                return cliente is null
                    ? "Cliente não encontrado"
                    : JsonSerializer.Serialize(cliente);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar cliente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Criar/Cadastrar um cliente")]
        public static async Task<string> CadastrarCliente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("Dados para criação do cliente")] ClienteRequest cliente)
        {
            try
            {
                var clienteCriado = await agendaCertaApiClient.CriarClienteAsync(cliente);
                return clienteCriado is null
                    ? "Não foi possível cadastrar o cliente"
                    : JsonSerializer.Serialize(clienteCriado);
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar cliente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Atualizar os dados de um cliente")]
        public static async Task<string> AtualizarCliente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do cliente")] int id,
            [Description("Dados para atualização do cliente")] ClienteRequest cliente)
        {
            try
            {
                var clienteAtualizado = await agendaCertaApiClient.AtualizarClienteAsync(id, cliente);
                return clienteAtualizado is null
                    ? "Não foi possível atualizar o cliente"
                    : JsonSerializer.Serialize(clienteAtualizado);
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar cliente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Excluir um cliente pelo ID")]
        public static async Task<string> ExcluirCliente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do cliente")] int id)
        {
            try
            {
                var sucesso = await agendaCertaApiClient.ExcluirClienteAsync(id);
                return sucesso
                    ? "Cliente excluído com sucesso"
                    : "Cliente não encontrado ou erro ao excluir";
            }
            catch (Exception ex)
            {
                return $"Erro ao excluir cliente: {ex.Message}";
            }
        }

        #endregion

        #region Atendente Tools

        [McpServerTool, Description("Busca todos os atendentes cadastrados")]
        public static async Task<string> ObterAtendentes(AgendaCertaApiClient agendaCertaApiClient)
        {
            try
            {
                var atendentes = await agendaCertaApiClient.ObterAtendentesAsync();
                return atendentes.Count == 0
                    ? "Nenhum atendente encontrado"
                    : JsonSerializer.Serialize(atendentes);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar atendentes: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca um atendente pelo ID")]
        public static async Task<string> ObterAtendentePorId(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do atendente")] int id)
        {
            try
            {
                var atendente = await agendaCertaApiClient.ObterAtendentePorIdAsync(id);
                return atendente is null
                    ? "Atendente não encontrado"
                    : JsonSerializer.Serialize(atendente);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar atendente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca um atendente pelo CPF")]
        public static async Task<string> ObterAtendentePorCPF(AgendaCertaApiClient agendaCertaApiClient,
            [Description("CPF do atendente")] string cpf)
        {
            try
            {
                var atendente = await agendaCertaApiClient.ObterAtendentePorCPFAsync(cpf);
                return atendente is null
                    ? "Atendente não encontrado"
                    : JsonSerializer.Serialize(atendente);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar atendente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca atendentes por especialidade")]
        public static async Task<string> ObterAtendentesPorEspecialidade(AgendaCertaApiClient agendaCertaApiClient,
            [Description("Especialidade do atendente")] string especialidade)
        {
            try
            {
                var atendentes = await agendaCertaApiClient.ObterAtendentesPorEspecialidadeAsync(especialidade);
                return atendentes.Count == 0
                    ? "Nenhum atendente encontrado para esta especialidade"
                    : JsonSerializer.Serialize(atendentes);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar atendentes: {ex.Message}";
            }
        }

        [McpServerTool, Description("Criar/Cadastrar um atendente")]
        public static async Task<string> CadastrarAtendente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("Dados para criação do atendente")] AtendenteRequest atendente)
        {
            try
            {
                var atendenteCriado = await agendaCertaApiClient.CriarAtendenteAsync(atendente);
                return atendenteCriado is null
                    ? "Não foi possível cadastrar o atendente"
                    : JsonSerializer.Serialize(atendenteCriado);
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar atendente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Atualizar os dados de um atendente")]
        public static async Task<string> AtualizarAtendente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do atendente")] int id,
            [Description("Dados para atualização do atendente")] AtendenteRequest atendente)
        {
            try
            {
                var atendenteAtualizado = await agendaCertaApiClient.AtualizarAtendenteAsync(id, atendente);
                return atendenteAtualizado is null
                    ? "Não foi possível atualizar o atendente"
                    : JsonSerializer.Serialize(atendenteAtualizado);
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar atendente: {ex.Message}";
            }
        }

        [McpServerTool, Description("Excluir um atendente pelo ID")]
        public static async Task<string> ExcluirAtendente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do atendente")] int id)
        {
            try
            {
                var sucesso = await agendaCertaApiClient.ExcluirAtendenteAsync(id);
                return sucesso
                    ? "Atendente excluído com sucesso"
                    : "Erro ao excluir atendente";
            }
            catch (Exception ex)
            {
                return $"Erro ao excluir atendente: {ex.Message}";
            }
        }

        #endregion

        #region Agendamento Tools

        [McpServerTool, Description("Busca todos os agendamentos cadastrados")]
        public static async Task<string> ObterAgendamentos(AgendaCertaApiClient agendaCertaApiClient)
        {
            try
            {
                var agendamentos = await agendaCertaApiClient.ObterAgendamentosAsync();
                return agendamentos.Count == 0
                    ? "Nenhum agendamento encontrado"
                    : JsonSerializer.Serialize(agendamentos);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar agendamentos: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca um agendamento pelo ID")]
        public static async Task<string> ObterAgendamentoPorId(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do agendamento")] int id)
        {
            try
            {
                var agendamento = await agendaCertaApiClient.ObterAgendamentoPorIdAsync(id);
                return agendamento is null
                    ? "Agendamento não encontrado"
                    : JsonSerializer.Serialize(agendamento);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar agendamento: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca agendamentos por cliente")]
        public static async Task<string> ObterAgendamentosPorCliente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do cliente")] int clienteId)
        {
            try
            {
                var agendamentos = await agendaCertaApiClient.ObterAgendamentosPorClienteAsync(clienteId);
                return agendamentos.Count == 0
                    ? "Nenhum agendamento encontrado para este cliente"
                    : JsonSerializer.Serialize(agendamentos);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar agendamentos: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca agendamentos por atendente")]
        public static async Task<string> ObterAgendamentosPorAtendente(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do atendente")] int atendenteId)
        {
            try
            {
                var agendamentos = await agendaCertaApiClient.ObterAgendamentosPorAtendenteAsync(atendenteId);
                return agendamentos.Count == 0
                    ? "Nenhum agendamento encontrado para este atendente"
                    : JsonSerializer.Serialize(agendamentos);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar agendamentos: {ex.Message}";
            }
        }

        [McpServerTool, Description("Busca agendamentos por data")]
        public static async Task<string> ObterAgendamentosPorData(AgendaCertaApiClient agendaCertaApiClient,
            [Description("Data do agendamento (formato: yyyy-MM-dd)")] DateTime data)
        {
            try
            {
                var agendamentos = await agendaCertaApiClient.ObterAgendamentosPorDataAsync(data);
                return agendamentos.Count == 0
                    ? "Nenhum agendamento encontrado para esta data"
                    : JsonSerializer.Serialize(agendamentos);
            }
            catch (Exception ex)
            {
                return $"Erro ao buscar agendamentos: {ex.Message}";
            }
        }

        [McpServerTool, Description("Criar/Cadastrar um agendamento")]
        public static async Task<string> CadastrarAgendamento(AgendaCertaApiClient agendaCertaApiClient,
            [Description("Dados para criação do agendamento")] AgendamentoRequest agendamento)
        {
            try
            {
                var agendamentoCriado = await agendaCertaApiClient.CriarAgendamentoAsync(agendamento);
                return agendamentoCriado is null
                    ? "Não foi possível cadastrar o agendamento"
                    : JsonSerializer.Serialize(agendamentoCriado);
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar agendamento: {ex.Message}";
            }
        }

        [McpServerTool, Description("Atualizar os dados de um agendamento")]
        public static async Task<string> AtualizarAgendamento(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do agendamento")] int id,
            [Description("Dados para atualização do agendamento")] AgendamentoUpdateRequest agendamento)
        {
            try
            {
                var agendamentoAtualizado = await agendaCertaApiClient.AtualizarAgendamentoAsync(id, agendamento);
                return agendamentoAtualizado is null
                    ? "Não foi possível atualizar o agendamento"
                    : JsonSerializer.Serialize(agendamentoAtualizado);
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar agendamento: {ex.Message}";
            }
        }

        [McpServerTool, Description("Excluir um agendamento pelo ID")]
        public static async Task<string> ExcluirAgendamento(AgendaCertaApiClient agendaCertaApiClient,
            [Description("ID do agendamento")] int id)
        {
            try
            {
                var sucesso = await agendaCertaApiClient.ExcluirAgendamentoAsync(id);
                return sucesso
                    ? "Agendamento excluído com sucesso"
                    : "Erro ao excluir agendamento";
            }
            catch (Exception ex)
            {
                return $"Erro ao excluir agendamento: {ex.Message}";
            }
        }

        #endregion
    }
}