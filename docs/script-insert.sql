-- INSERT DATA TESTS
--=================================================

-- INSERT FROTA
INSERT INTO [wa-desafio-ecommerce].dbo.Frota
(Nome, Descricao, PlacaVeiculoUtilizado)
VALUES('Mercado Entregas GRU', 'Serviço de entregas p/ GRU', 'EJL-6985');

-- INSERT PEDIDO
INSERT INTO [wa-desafio-ecommerce].dbo.Pedido
(FrotaId, Status, DataEntrega, DataCriacao, DataAtualizacao, DataDelecao)
VALUES(1, 'entregue', '2022-10-09 16:30:00.173', '2022-10-06 11:23:00.173', null, null);

-- INSERT ENDERECO
INSERT INTO [wa-desafio-ecommerce].dbo.Endereco
(PedidoId, CEP, Logradouro, Numero, Complemento, Bairro, Cidade, UF)
VALUES(1, '07123-100', 'Rua Belo Jardim', 613, null, 'Jd Santa Clara', 'Guarulhos', 'SP');

-- INSERT PRODUTO
INSERT INTO [wa-desafio-ecommerce].dbo.Produto
(PedidoId, Nome, Descricao, Valor)
VALUES(1, 'Sapato Ferracini', 'Sapato social masculino em couro na cor café, modelo italiano.', 380);
