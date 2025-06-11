using MCPServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole(consoleLogOptions =>
{
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

var serverInfo = new Implementation { Name = "MCPServer", Version = "1.0.0" };

builder.Services
    .AddMcpServer(mcp => { mcp.ServerInfo = serverInfo; })
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(AgendaCertaTools).Assembly);

builder.Services.AddHttpClient<AgendaCertaApiClient>(client => { client.BaseAddress = new Uri("http://localhost:5135/api/"); });

await builder.Build().RunAsync();