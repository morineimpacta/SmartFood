

USE SmartFood;

--Drop Table dbo.ItemMenu;
--Drop Table dbo.Categoria;
--Drop Table dbo.Estabelecimento;
--Drop Table dbo.Usuario;


Create Table Usuario
(
    Id int identity primary key not null,
    Nome varchar(100) not null,
    Login varchar(20) not null, 
    Email varchar(100) not null,
    Senha varchar(100) not null, 
    CPF decimal(11) not null,
    NumeroCelular decimal(11) not null,
    ExpiracaoSenha datetime, 
    DataNascimento datetime, 
);

Create Table Estabelecimento
(
    Id int identity primary key not null,
    RazaoSocial varchar(100) not null,
    NomeFantasia varchar(100) not null,
    Login varchar(20) not null, 
    Email varchar(100) not null,
    Senha varchar(100) not null, 
    CNPJ decimal(11) not null,
    NomeContato varchar(100) not null, 
    NumeroCelular decimal(11) not null,
    ExpiracaoSenha datetime
);

Create Table Categoria 
(
    Id int primary key not null,
    Descricao varchar(100) not null, 
    Prioridade int,
    Ativo bit not null default(1)
)

Create Table ItemMenu
(
    Id int identity primary key not null,
    Titulo varchar(100) not null,
    Descricao varchar(100) not null,
    Imagem varbinary(max),
    QuantidadePessoas int,
    Calorias Decimal,
    Peso Decimal,
    Preco Decimal(12, 2) not null,
    TempoPreparo varchar(100),
    LinkVideo varchar(200),
    IdCategoria int not null,
    IdEstabelecimento int not null,
    Ativo bit not null default(1),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria (Id),
    FOREIGN KEY (IdEstabelecimento) REFERENCES Estabelecimento (Id)
);

--SELECT CAST('teste123' as varbinary(max))

insert into dbo.Usuario values ('Tiago Morine Baganha', 'tibaganha', 'tiago.baganha@aluno.faculdadeimpacta.com.br', 'dGVzdGUxMjM=', 33344455599, 11999944444, Getdate() + 90, '1986-01-01');

insert into dbo.Estabelecimento values ('Sabor Paulista Ltda', 'Sabor Paulista', 'saborpaulista', 'saborpaulista@gmail.com', 'dGVzdGUxMjM=', 324344343, 'Pedro', 11999998888, Getdate() + 90);

insert into dbo.Categoria(Id, Descricao, Prioridade) values (1, 'Entrada', 1);
insert into dbo.Categoria(Id, Descricao, Prioridade) values (2, 'Prato Principal', 2);
insert into dbo.Categoria(Id, Descricao, Prioridade) values (3, 'Sobremesa', 3);
insert into dbo.Categoria(Id, Descricao, Prioridade) values (4, 'Aperitivos', 4);
insert into dbo.Categoria(Id, Descricao, Prioridade) values (5, 'Bebidas', 5);
insert into dbo.Categoria values (6, 'Promocao', 6, 0);

insert into dbo.ItemMenu values ('Ceviche', 'Ceviche de peixe branco e camarão', 123, 1, 200, 150, 35.50, '15 min', 'https://www.youtube.com/watch?v=hvAhk_9tl00', 1, 1, 1);


--String to Base64
SELECT CAST('teste123' as varbinary(max)) FOR XML PATH(''), BINARY BASE64

--Base64 to String
SELECT CAST( CAST( 'dGVzdGUxMjM=' as XML ).value('.','varbinary(max)') AS varchar(max) )

