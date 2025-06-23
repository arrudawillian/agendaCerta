# AgendaCerta

## Sobre o Projeto
O AgendaCerta é uma API de exemplo desenvolvida em .NET que demonstra a implementação de um sistema simples de agendamento de consultas, integrado com um servidor MCP (Model-Controller-Presenter).

## Funcionalidades
- Gerenciamento de clientes
- Cadastro de profissionais (atendentes)
- Agendamento de consultas
- Controle de status dos agendamentos

## Tecnologias Utilizadas
- .NET
- Entity Framework Core
- SQLite (banco de dados)
- Servidor MCP

## Estrutura do Projeto
- **AgendaCerta.API**: Camada de apresentação com os controllers e configurações da API
- **AgendaCerta.Domain**: Camada de domínio com as entidades do sistema
- **AgendaCerta.Data**: Camada de acesso a dados com repositórios e contexto
- **AgendaCerta.Services**: Camada de serviços com a lógica de negócios
- **MCPServer**: Implementação do servidor MCP para interação com a API

## Como Executar
1. Clone o repositório
2. Abra a solução no Visual Studio
3. Execute as migrações do banco de dados
4. Inicie o projeto AgendaCerta.API
5. Execute o servidor MCP para interagir com a API

## Exemplos de Uso
O projeto inclui exemplos de:
- Cadastro e consulta de clientes
- Gerenciamento de profissionais por especialidade
- Agendamento e atualização de consultas
- Geração de relatórios em CSV

## Observações
Este é um projeto de exemplo criado para fins didáticos, demonstrando a integração entre uma API REST e um servidor MCP.
