USE Imobiliaria;

SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;
SELECT * FROM Aluguel;
SELECT * FROM Situacao;

SELECT Aluguel.IdAluguel, Usuario.Nome, Usuario.Telefone, 
		Usuario.CPF,Aluguel.Endereco, Aluguel.DataVencimento, Aluguel.Valor, Situacao.TipoSituacao FROM Aluguel
		INNER JOIN Usuario ON Usuario.IdUsuario = Aluguel.IdUsuario
		INNER JOIN Situacao ON Situacao.IdSituacao = Aluguel.IdSituacao