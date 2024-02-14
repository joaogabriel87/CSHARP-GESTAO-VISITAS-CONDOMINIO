# Gestão de visita a condominio 

## Endpoints

* GET /VisitanteContext/Visitantes: Retorna a lista de todos os visitantes

* GET /VisitanteContext/VisitantesPorCPF: Retorna a lista de um visitante pesquisado pelo CPF
```
[
  {
    "cpf": "string",
  }
]
```
* POST /VisitanteContext/Cadastrar: Cadastra um novo visitante

  ```
{
  "id": 0,
  "nome": "string",
  "cpf": "string",
  "telefone": "string",
  "dataVisita": "2024-02-14",
  "visitanteAtivo": true
}
```

*PUT /VisitanteContext/Atualizar/{CPF}: Atualiza as informações do visitante


*DELETE /VisitanteContext/Remover/{CPF}: Remove um visitante
