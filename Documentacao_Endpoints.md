# Etapa 3 – Documentação das APIs

## Sistema de Aluguel de Veículos
Backend REST em ASP.NET Core, Entity Framework Core, SQL Server Express e Swagger.

### Códigos de resposta usados
- 200 OK: consulta ou operação concluída.
- 201 Created: registro criado.
- 204 No Content: atualização/exclusão concluída.
- 400 Bad Request: dados inválidos ou regra de negócio violada.
- 404 Not Found: registro não encontrado.
- 500 Internal Server Error: erro inesperado tratado pelo middleware.

## Fabricantes
- GET `/api/Fabricantes` — lista fabricantes. Respostas: 200, 500.
- GET `/api/Fabricantes/{id}` — busca por id. Parâmetro: `id` inteiro. Respostas: 200, 404, 500.
- POST `/api/Fabricantes` — cria fabricante. Body: `nome`, `paisOrigem`. Respostas: 201, 400, 500.
- PUT `/api/Fabricantes/{id}` — atualiza fabricante. `id` deve coincidir com o body. Respostas: 204, 400, 404, 500.
- DELETE `/api/Fabricantes/{id}` — exclui fabricante. Respostas: 204, 404, 500.

## Categorias
- GET `/api/Categorias` — lista categorias. Respostas: 200, 500.
- GET `/api/Categorias/{id}` — busca por id. Respostas: 200, 404, 500.
- POST `/api/Categorias` — cria categoria. Body: `nome`, `valorDiariaSugerido`. Respostas: 201, 400, 500.
- PUT `/api/Categorias/{id}` — atualiza categoria. Respostas: 204, 400, 404, 500.
- DELETE `/api/Categorias/{id}` — exclui categoria. Respostas: 204, 404, 500.

## Clientes
- GET `/api/Clientes` — lista clientes. Respostas: 200, 500.
- GET `/api/Clientes/{id}` — busca cliente por id. Respostas: 200, 404, 500.
- POST `/api/Clientes` — cria cliente. Body mínimo: `nome`, `cpf` com 11 caracteres e `email` válido. Respostas: 201, 400, 500.
- PUT `/api/Clientes/{id}` — atualiza cliente. Respostas: 204, 400, 404, 500.
- DELETE `/api/Clientes/{id}` — exclui cliente. Respostas: 204, 404, 500.

## Veículos
- GET `/api/Veiculos` — lista veículos, incluindo fabricante e categoria. Respostas: 200, 500.
- GET `/api/Veiculos/{id}` — busca veículo por id. Respostas: 200, 404, 500.
- POST `/api/Veiculos` — cria veículo. Body: `modelo`, `placa`, `anoFabricacao`, `quilometragem`, `disponivel`, `fabricanteId`, `categoriaId`. Fabricante e categoria precisam existir. Respostas: 201, 400, 500.
- PUT `/api/Veiculos/{id}` — atualiza veículo. Respostas: 204, 400, 404, 500.
- DELETE `/api/Veiculos/{id}` — exclui veículo. Respostas: 204, 404, 500.

## Aluguéis
- GET `/api/Alugueis` — lista aluguéis com cliente e veículo. Respostas: 200, 500.
- GET `/api/Alugueis/{id}` — busca aluguel por id. Respostas: 200, 404, 500.
- POST `/api/Alugueis` — cria aluguel. Exige cliente e veículo existentes, veículo disponível e data final prevista posterior à inicial. A quilometragem inicial é obtida do veículo e ele passa a indisponível. Respostas: 201, 400, 500.
- PUT `/api/Alugueis/{id}` — atualiza aluguel. Respostas: 204, 400, 404, 500.
- DELETE `/api/Alugueis/{id}` — exclui aluguel. Respostas: 204, 404, 500.
- POST `/api/Alugueis/{id}/devolver?quilometragemFinal={km}` — registra devolução, calcula o total, atualiza quilometragem e libera o veículo. Respostas: 200, 400, 404, 500.

## Cinco filtros com JOIN
1. GET `/api/filtros/veiculos-por-fabricante/{fabricanteId}` — INNER JOIN entre Veículo e Fabricante.
2. GET `/api/filtros/alugueis-por-cliente/{clienteId}` — INNER JOIN entre Aluguel, Cliente e Veículo.
3. GET `/api/filtros/veiculos-disponiveis` — INNER JOIN entre Veículo, Categoria e Fabricante.
4. GET `/api/filtros/clientes-com-quantidade-alugueis` — LEFT JOIN lógico (Group Join) entre Cliente e Aluguel, incluindo clientes sem aluguel.
5. GET `/api/filtros/veiculos-com-ultimo-aluguel` — LEFT JOIN entre Veículo e Aluguel, incluindo veículos nunca alugados.

## Validações
As entidades utilizam Data Annotations (`Required`, `StringLength`, `EmailAddress` e `Range`). Os controllers também validam regras de negócio, como existência de chaves estrangeiras, disponibilidade do veículo, datas e quilometragem de devolução. Exceções não tratadas são convertidas em resposta HTTP 500 pelo `ExceptionMiddleware`.
