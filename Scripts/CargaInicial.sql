

USE alunoimpacta4s;

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



select * from sys.tables where name = 'Usuario'
select * from sys.columns where object_id = 1717581157
select * from system_type where 







select * from REstaurante

update restaurante set url = 'https://static-images.ifood.com.br/image/upload/t_high/logosgde/15266cdd-0857-4b8f-bc3c-f6e0121b9760/201906271941_2QRM_i.jpg'
where id_restaurante = 7;

sp_help Usuario

insert into dbo.PRATO_PEDIDO values (17, 1)
insert into dbo.PRATO_PEDIDO values (11, 1)
    

--String to Base64
SELECT CAST('teste123' as varbinary(max)) FOR XML PATH(''), BINARY BASE64

--Base64 to String
SELECT CAST( CAST( 'dGVzdGUxMjM=' as XML ).value('.','varbinary(max)') AS varchar(max) )


SELECT 
    pp.Pedido_id as pedido1_1_1_, pp.Prato_id as prato2_1_1_, pr.ID_PRATO as id1_2_0_, pr.NOME_PRATO as nome2_2_0_, pr.DESC_PRATO as desc3_2_0_, pr.AVALIACAO as avaliacao4_2_0_, pr.PEDIDOS as pedidos5_2_0_, pr.PRECO as preco6_2_0_, pr.ID_RESTAURANTE as id7_2_0_ 
    FROM dbo.PRATO_PEDIDO pp 
    left outer join dbo.Prato pr on pp.Prato_id=pr.ID_PRATO