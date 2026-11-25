# ViaDrive — Trabalho Prático 2

Front-end integrado à API da Locadora de Veículos desenvolvida na etapa anterior.

## O que foi implementado
- Painel inicial com indicadores calculados a partir dos dados retornados pela API.
- Telas de cadastro, edição, exclusão, listagem e filtros para Fabricantes, Categorias, Clientes, Veículos e Aluguéis.
- Filtros personalizados em pelo menos dois campos por entidade.
- Tela de devolução de veículo integrada à rota específica do back-end.
- Área de consultas e relatórios que executa as cinco rotas com JOIN da Etapa 3.
- Layout responsivo para desktop e dispositivos menores.

## Como executar
Consulte `README_ETAPA3.md` para configurar SQL Server e migrations. Depois execute `dotnet restore` e `dotnet run` na pasta do projeto. Abra a URL indicada no terminal. A aplicação web será exibida na raiz e o Swagger em `/swagger`.

## Documentação da etapa
- `Documentacao/TP2_Frontend.md`: telas, wireframes, integração e requisitos atendidos.
- `Documentacao/ROTEIRO_PITCH_TP2.md`: roteiro-base para vídeo de 3 a 5 minutos.
- `Documentacao/Documentacao_Endpoints.md`: documentação das rotas da API.

## Observação
O front-end não utiliza massa de dados mockada. A execução exige o back-end e o SQL Server configurados. A API deve estar iniciada para que as telas carreguem e alterem os dados.
