-- CRIAR O BANCO DE DADOS
CREATE DATABASE programacao_do_zero;

--USAR O BANCO DE DADOS
USE programacao_do_zero;

--CRIAR TABELA USUARIO
CREATE TABLE usuario(
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR (30) NOT NULL,
	sobrenome VARCHAR (100) NOT NULL,
	telefone VARCHAR (15) NOT NULL,
	email VARCHAR (50) NOT NULL,
	genero VARCHAR (20) NOT NULL,
	senha VARCHAR (30) NOT NULL,
	PRIMARY KEY (id)
);

--CRIAR TABELA ENDEREÇO

CREATE TABLE endereco(
	id INT NOT NULL AUTO_INCREMENT,
	rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
    cidade VARCHAR(200) NOT NULL,
    complemento VARCHAR(100) NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY (id)
);

--ALTERAR TABELA ENDEREÇO 

ALTER TABLE endereco ADD usuario_id INT NOT NULL;

--ADICIONAR CHAVE ESTRANGEIRA 

ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--INSERIR USUARIO

INSERT INTO usuario
(nome, sobrenome, telefone, email, genero, senha) 
VALUES 
('Vinicius', 'Xavier', '65 984484095', 'primexavier1910@gmail.com', 'masculino', '387152')

--SELECIONAR TODOS OS USUARIOS

SELECT * FROM usuario;

--SELECIONAR UM USUARIO ESPECIFICO 

SELECT * FROM usuario WHERE telefone = '984484095';

--ALTERAR USUARIO

SELECT * FROM usuario ; --PARA RODAR DEPOIS DE ALTERAR
UPDATE usuario SET senha = 'nana123' WHERE id = 3; -- cÓDIGO PARA ALTERAR (ATENÇÃO PARA COLOCAR A ID CORRETA)

--EXCLUIR USUARIO 

DELETE FROM usuario WHERE id = 2

--EXCLUIR TODOS OS USUARIOS COM ID MAIOR QUE 'X'

DELETE FROM usuario WHERE id > 2