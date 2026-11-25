# Relatório de Testes Manuais – Swagger

## Sistema de Aluguel de Veículos

**Objetivo:** evidenciar a execução manual das APIs no Swagger, registrando a chamada e o retorno de cada método.



## Sequência sugerida de teste e evidência

| Nº | Método | Rota | Teste/resultado esperado |
|---|---|---|---|---|
| 01 | POST | `/api/Fabricantes` | Criar fabricante; HTTP 201 | 
| 02 | GET | `/api/Fabricantes` | Listar fabricantes; HTTP 200 | 
| 03 | PUT | `/api/Fabricantes/{id}` | Atualizar fabricante; HTTP 204 | 
| 04 | DELETE | `/api/Fabricantes/{id}` | Excluir registro de teste; HTTP 204 | 
| 05 | POST | `/api/Categorias` | Criar categoria; HTTP 201 | 
| 06 | GET | `/api/Categorias` | Listar categorias; HTTP 200 | 
| 07 | PUT | `/api/Categorias/{id}` | Atualizar categoria; HTTP 204 | 
| 08 | DELETE | `/api/Categorias/{id}` | Excluir registro de teste; HTTP 204 | 
| 09 | POST | `/api/Clientes` | Criar cliente; HTTP 201 | 
| 10 | GET | `/api/Clientes` | Listar clientes; HTTP 200 | 
| 11 | PUT | `/api/Clientes/{id}` | Atualizar cliente; HTTP 204 | 
| 12 | DELETE | `/api/Clientes/{id}` | Excluir registro de teste; HTTP 204 | 
| 13 | POST | `/api/Veiculos` | Criar veículo com fabricante/categoria válidos; HTTP 201 | 
| 14 | GET | `/api/Veiculos` | Listar veículos e relacionamentos; HTTP 200 | 
| 15 | PUT | `/api/Veiculos/{id}` | Atualizar veículo; HTTP 204 | 
| 16 | POST | `/api/Alugueis` | Criar aluguel; HTTP 201 e veículo indisponível | 
| 17 | GET | `/api/Alugueis` | Listar aluguéis; HTTP 200 | 
| 18 | PUT | `/api/Alugueis/{id}` | Atualizar aluguel; HTTP 204 | 
| 19 | POST | `/api/Alugueis/{id}/devolver` | Registrar devolução; HTTP 200, valor total calculado | 
| 20 | GET | `/api/filtros/veiculos-por-fabricante/{id}` | Filtro INNER JOIN; HTTP 200 | 
| 21 | GET | `/api/filtros/alugueis-por-cliente/{id}` | Filtro INNER JOIN; HTTP 200 | 
| 22 | GET | `/api/filtros/veiculos-disponiveis` | Filtro INNER JOIN; HTTP 200 | 
| 23 | GET | `/api/filtros/clientes-com-quantidade-alugueis` | Filtro LEFT JOIN; HTTP 200 | 
| 24 | GET | `/api/filtros/veiculos-com-ultimo-aluguel` | Filtro LEFT JOIN; HTTP 200 | 
| 25 | DELETE | `/api/Alugueis/{id}` | Excluir aluguel de teste; HTTP 204 | 
| 26 | DELETE | `/api/Veiculos/{id}` | Excluir veículo de teste; HTTP 204 | 

## Corpos de requisição para os testes

### Fabricante
```json
{"nome":"Toyota","paisOrigem":"Japão"}
```

### Categoria
```json
{"nome":"Sedan","valorDiariaSugerido":180.00}
```

### Cliente
```json
{"nome":"Cliente Teste","cpf":"12345678901","email":"cliente@teste.com","telefone":"31999999999"}
```

### Veículo
Substitua `fabricanteId` e `categoriaId` pelos IDs criados.
```json
{"modelo":"Corolla","placa":"ABC1D23","anoFabricacao":2024,"quilometragem":15000,"disponivel":true,"fabricanteId":1,"categoriaId":1}
```

### Aluguel
Substitua os IDs pelos registros existentes.
```json
{"clienteId":1,"veiculoId":1,"dataInicio":"2026-10-02T10:00:00","dataFimPrevista":"2026-10-05T10:00:00","quilometragemInicial":0,"valorDiaria":180.00,"valorTotal":0}
```

### Devolução
Exemplo: `POST /api/Alugueis/1/devolver?quilometragemFinal=15350`.

## Testes de validação recomendados
- Cliente com e-mail inválido → HTTP 400.
- Veículo com fabricante inexistente → HTTP 400.
- Aluguel de veículo indisponível → HTTP 400.
- Devolução com quilometragem menor que a inicial → HTTP 400.
- Busca de ID inexistente → HTTP 404.

## Conclusão
Após executar todos os itens e anexar os prints reais na pasta `Evidencias_Swagger`, o relatório demonstra o funcionamento do CRUD, das regras de negócio, das validações e dos cinco filtros com dois tipos de JOIN.
