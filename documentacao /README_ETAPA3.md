# Etapa 3 – Testes e Documentação

Este pacote contém o backend da locadora e os materiais da Etapa 3.

## Conteúdo
- API ASP.NET Core com Entity Framework Core e SQL Server.
- Swagger/Swagger UI já integrado em `Program.cs`.
- `Documentacao/Documentacao_Endpoints.md`: documentação das rotas, métodos, parâmetros e respostas.
- `Documentacao/Relatorio_de_Testes_Swagger.md`: roteiro/relatório para evidenciar as chamadas e retornos.
- `Evidencias_Swagger/`: pasta destinada aos prints reais do Swagger.

## Como executar
1. Ajuste `DefaultConnection` em `appsettings.json` para a instância do SQL Server Express do computador.
2. Restaure os pacotes (`dotnet restore`).
3. Caso ainda não tenha criado o banco via migrations, use `dotnet ef migrations add InitialCreate` e `dotnet ef database update`.
4. Execute `dotnet run`.
5. Abra no navegador o endereço mostrado no terminal acrescentando `/swagger`.
6. Execute os testes descritos no relatório e salve os prints na pasta `Evidencias_Swagger`.


