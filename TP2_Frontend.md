# Trabalho Prático 2 — Front-end da Locadora ViaDrive

## 1. Objetivo
Desenvolver a interface web do sistema de locação de veículos da Etapa 3, consumindo a API ASP.NET Core e mantendo a persistência no SQL Server por meio do Entity Framework Core.

## 2. Wireframes e protótipo de alta fidelidade
Os wireframes estruturais estão disponíveis em `wwwroot/wireframes.html`. Após iniciar a API, abra `https://localhost:xxxx/wireframes.html` (substitua pela URL exibida pelo `dotnet run`). A aplicação de alta fidelidade está na raiz `https://localhost:xxxx/`; o link de navegação “Abrir aplicação” permite alternar entre o planejamento visual e o sistema implementado.

**Telas previstas:**
- Visão geral: indicadores de frota, disponibilidade, clientes e aluguéis ativos; lista de aluguéis recentes.
- Veículos: listagem, pesquisa por modelo, placa, fabricante e categoria; cadastro, edição e exclusão.
- Clientes: listagem, pesquisa por nome, CPF, e-mail e telefone; cadastro, edição e exclusão.
- Aluguéis: listagem, pesquisa por cliente, veículo e datas; cadastro, edição, exclusão e registro de devolução.
- Categorias: listagem, pesquisa por nome e valor da diária; cadastro, edição e exclusão.
- Fabricantes: listagem, pesquisa por nome e país de origem; cadastro, edição e exclusão.
- Consultas e relatórios: execução das cinco consultas com JOIN criadas no back-end.

Para compartilhar publicamente, publique o repositório e disponibilize a aplicação em um servidor que execute ASP.NET Core; então substitua os endereços locais acima pela URL pública no documento final. No ZIP, os wireframes e a aplicação estão no diretório `wwwroot`.

## 3. Integração com a API
O front-end utiliza `fetch` e as rotas documentadas na Etapa 3. Como os arquivos são servidos pelo próprio ASP.NET Core, a interface e a API compartilham a mesma origem, não sendo necessário habilitar CORS para esta configuração.

| Entidade | Listagem | Cadastro | Edição | Exclusão |
|---|---|---|---|---|
| Fabricante | GET `/api/Fabricantes` | POST `/api/Fabricantes` | PUT `/api/Fabricantes/{id}` | DELETE `/api/Fabricantes/{id}` |
| Categoria | GET `/api/Categorias` | POST `/api/Categorias` | PUT `/api/Categorias/{id}` | DELETE `/api/Categorias/{id}` |
| Cliente | GET `/api/Clientes` | POST `/api/Clientes` | PUT `/api/Clientes/{id}` | DELETE `/api/Clientes/{id}` |
| Veículo | GET `/api/Veiculos` | POST `/api/Veiculos` | PUT `/api/Veiculos/{id}` | DELETE `/api/Veiculos/{id}` |
| Aluguel | GET `/api/Alugueis` | POST `/api/Alugueis` | PUT `/api/Alugueis/{id}` | DELETE `/api/Alugueis/{id}` |

## 4. Filtros e consultas com JOIN
A área “Consultas e relatórios” executa as rotas específicas existentes:

1. `GET /api/filtros/veiculos-por-fabricante/{fabricanteId}` — INNER JOIN Veículo/Fabricante.
2. `GET /api/filtros/alugueis-por-cliente/{clienteId}` — INNER JOIN Aluguel/Cliente/Veículo.
3. `GET /api/filtros/veiculos-disponiveis` — INNER JOIN Veículo/Categoria/Fabricante.
4. `GET /api/filtros/clientes-com-quantidade-alugueis` — LEFT JOIN Cliente/Aluguel.
5. `GET /api/filtros/veiculos-com-ultimo-aluguel` — LEFT JOIN Veículo/Aluguel.

As telas de cadastro também oferecem filtros personalizados em pelo menos dois campos por entidade. Os resultados são obtidos da API e filtrados na interface, sem inserir registros fictícios.

## 5. Regras de negócio
- Um aluguel só pode ser cadastrado para cliente existente e veículo disponível, conforme validação do back-end.
- Ao iniciar um aluguel, o back-end altera a disponibilidade do veículo.
- A devolução é registrada pela rota `POST /api/Alugueis/{id}/devolver?quilometragemFinal={km}`. A API calcula o total, atualiza a quilometragem e libera o veículo.
- Exclusões e operações inválidas exibem o retorno de erro recebido da API.

## 6. Tecnologias
HTML5, CSS3, JavaScript (Fetch API), ASP.NET Core 8, Entity Framework Core e SQL Server Express.

## 7. Como executar
1. Configure `ConnectionStrings:DefaultConnection` em `appsettings.json` para a instância local do SQL Server.
2. No terminal, dentro de `Etapa3_LocadoraVeiculos`, execute `dotnet restore`.
3. Se o banco ainda não existir, crie/aplique a migration conforme o README da Etapa 3.
4. Execute `dotnet run`.
5. Abra no navegador a URL indicada pelo terminal. A tela inicial e o Swagger estarão disponíveis no mesmo host.
