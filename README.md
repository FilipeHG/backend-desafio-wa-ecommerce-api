# Backend - DDD REST API
API modelo do projeto de e-commerce para challenge da WA.

## Getting Started
- CTRL+B | F5

* Tests/Dev => Use this JWT Bearer Token:

"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IndhLWVjb21tZXJjZS1zeXN0ZW0iLCJuYmYiOjE2NjU0NTA5NDIsImV4cCI6MTk4MTA3MDEzNywiaWF0IjoxNjY1NDUwOTQyfQ.OjzEOBfMCYw8bRC9wLbeSTwNroykPNesOH1edSCdp-c"

## Build and Test
F5

## Payloads Models

// POST (CREATE)
```json
{
  "frota": {
    "nome": "José Silveira",
    "descricao": "Motoboy dos interior",
    "placaVeiculoUtilizado": "LPQ325"
  },
  "produtos": [
    {
      "nome": "Café com pimenta",
      "descricao": "Café extra forte com toque de pimenta scorpion.",
      "valor": 67
    }
  ],
  "enderecoDeEntrega": {
    "cep": "08563-999",
    "logradouro": "Av das Tavernas",
    "numero": 789,
    "complemento": "",
    "bairro": "Monte do Gigante",
    "cidade": "Botucatu",
    "uf": "SP"
  },
  "status": "A caminho",
  "dataEntrega": "2022-10-11T04:03:04.187Z"
}
```

//============================

//PUT (UPDATE)
```json
{
  "id": 2,
  "frota": {
    "nome": "José Silveira Bianchi",
    "descricao": "Motoboy dos interior de SP",
    "placaVeiculoUtilizado": "LPQ325"
  },
  "produtos": [
    {
      "nome": "Café SEM pimenta",
      "descricao": "Café normal torra média.",
      "valor": 67
    }
  ],
  "enderecoDeEntrega": {
    "cep": "08563-999",
    "logradouro": "Av das Nações uNidas",
    "numero": 789,
    "complemento": "",
    "bairro": "Monte do Gigante",
    "cidade": "Botucatu",
    "uf": "SP"
  },
  "status": "Entregue",
  "dataEntrega": "2022-10-12T15:00:02.187Z"
}
```

### Contribute
FILIPE GONÇALVES - filipeh.goncalves@gmail.com
