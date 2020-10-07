USE Imobiliaria;

INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'),('Comum');

INSERT INTO Situacao (TipoSituacao)
VALUES ('Pago'),('Pendente'),('Atrasado');

INSERT INTO Usuario (Nome,Email,Senha,Telefone,CPF,IdTipoUsuario)
VALUES  ('Carlos Araujo Da Silva','carlos.araujo1980@gmail.com','12345','11934146741','36976615822',2);

INSERT INTO Aluguel (Endereco,Valor,DataVencimento,IdUsuario,IdSituacao)
VALUES ('Rua Professor Álvaro Guimarães Filho, 381','1.250,00','Dia-05',1,2);