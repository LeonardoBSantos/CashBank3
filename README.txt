conex�o com o banco

REF1 - https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio#add-a-model-class

- adicionei a pasta models
- adicionei a classe cliente
- nuGet Microsoft. EntityFrameworkCore. inmemory(desativada)
- criei a classe ClienteContext
- Registrar o contexto do banco na startup
- Scafold um controller
	- erro1 : adicionar a [Key] para indicar a chave prim�ria na classe cliente com a ref using System.ComponentModel.DataAnnotations; 
- Alterei o appsettings.json para iniciar com a url ~api/Clientes
- Rodei a Aplica��o
- Testei o verbo post com o postman

---------------||---------------------------

Conectando com o banco de dados
REF2 - https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-3.1&tabs=visual-studio

Adicionando o ef cli 
REF3 - https://docs.microsoft.com/en-us/ef/core/cli/dotnet


----------------------------------------------------------------------------------------------------------------------------
A CLASSE MODELO

Um modelo � um conjunto de classes que representam os dados gerenciados pelo aplicativo. As propriedades da classe s�o os 
campos da tabela. 

O CONTEXTO

O contexto de banco de dados � a classe principal que coordena a funcionalidade do Entity Framework para um modelo de dados.
No contexto configuramos as restri��es e relacionamento dos campos declarados no modelo. Escrever essas configura��es dessa 
forma � chamado de fluent Api.

REGISTRO NA CLASSE STARTUP
No ASP.NET Core, servi�os como o contexto de BD precisam ser registrados no cont�iner de inje��o de depend�ncia. O 
cont�iner fornece o servi�o aos controladores. Nesse registro,  tamb�m especificamos n�o s� o banco de dados que ser� usado
mas tamb�m o newtonSoft para resolver problemas na serializa��o.

O CONTROLLER
Para lidar com solicita��es, uma API Web usa controladores. O controller gerado marca a classe com o atributo [ApiController]. 
Esse atributo indica se o controlador responde �s solicita��es da API Web. 

Mais info - https://docs.microsoft.com/pt-br/aspnet/core/web-api/?view=aspnetcore-5.0

VERBOS HTTP (CONTROLLER CLIENTE)

GET
Lista os clientes e sua carteira 

GET/email_proprietario
Lista o cliente pelo email_proprietario selecionado

PUT
Atualiza apenas o nome e sobrenome do cliente

POST
Cadastra um novo cliente

DELETE
Deleta um cliente 

-------------------------------------------------------------------------------------------------------------------
Criando a entidade transa��o

1) criar o modelo da tabela transa��o
2) fazer o relacionamento 1 para muitos com a tabela carteira (campo id_carteira) - n�o declarando esse campo da tabela transa��o como unico 
3) gerar o controller 
4) fazer um trigger para atualizar o valor do saldo na tabela carteira ap�s a inser��o de uma transa��o
	testar o trigger no sql 
	adicionar a migration
5) o update n�o pode deixar a tabela negativa

Ref - https://pt.stackoverflow.com/questions/310703/update-utilizando-valores-contidos-em-outra-tabela
