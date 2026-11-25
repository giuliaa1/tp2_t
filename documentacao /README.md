# Etapa 2 – Backend da Locadora de Veículos

Projeto ASP.NET Core Web API com Entity Framework Core, SQL Server Express e Swagger.

## Entidades
1. Fabricante
2. Categoria
3. Veículo
4. Cliente
5. Aluguel

## Requisitos atendidos
- CRUD REST para as 5 entidades.
- Entity Framework Core conectado ao SQL Server Express.
- Validações por DataAnnotations e validações de negócio.
- Middleware para tratamento de exceções.
- Swagger habilitado para testes.
- 5 rotas de filtros usando INNER JOIN e LEFT JOIN.
- Rota adicional para registrar devolução e atualizar quilometragem/valor total.

## Configuração
A string padrão usa `Server=.\\SQLEXPRESS`. Se sua instância tiver outro nome, altere `appsettings.json`.

## Criar banco com migrations
No terminal, dentro da pasta do projeto:

    dotnet restore
    dotnet tool install --global dotnet-ef
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    dotnet run

Abra o endereço `/swagger` mostrado no terminal.

## CRUD
- `/api/Fabricantes`
- `/api/Categorias`
- `/api/Veiculos`
- `/api/Clientes`
- `/api/Alugueis`

Todos possuem GET, GET por id, POST, PUT e DELETE.

## 5 filtros com JOIN
1. `GET /api/filtros/veiculos-por-fabricante/{fabricanteId}` – INNER JOIN Veículo/Fabricante.
2. `GET /api/filtros/alugueis-por-cliente/{clienteId}` – INNER JOIN Aluguel/Cliente/Veículo.
3. `GET /api/filtros/veiculos-disponiveis` – INNER JOIN Veículo/Categoria/Fabricante.
4. `GET /api/filtros/clientes-com-quantidade-alugueis` – LEFT JOIN Cliente/Aluguel.
5. `GET /api/filtros/veiculos-com-ultimo-aluguel` – LEFT JOIN Veículo/Aluguel.

## Devolução
`POST /api/Alugueis/{id}/devolver?quilometragemFinal=12345`
Registra a data de devolução, calcula o valor total, atualiza a quilometragem e libera o veículo.
