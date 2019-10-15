CREATE DATABASE db_cadastro;
GO 
USE db_cadastro;
GO 
CREATE TABLE alunos
(
	id_aluno INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nome NVARCHAR(90),
	endereco NVARCHAR(180),
	email NVARCHAR(190),
	telefone NVARCHAR(40)
);

insert into dbo.alunos 
(nome, endereco, email, telefone) 
values 
('bruno','dfads','dfasd','4234'),
('Fernanda','dsfasdf','dfad','645');


