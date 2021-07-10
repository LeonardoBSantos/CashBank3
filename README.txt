conexão com o banco

REF1 - https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio#add-a-model-class

- adicionei a pasta models
- adicionei a classe cliente
- nuGet Microsoft. EntityFrameworkCore. inmemory(desativada)
- criei a classe ClienteContext
- Registrar o contexto do banco na startup
- Scafold um controller
	- erro1 : adicionar a [Key] para indicar a chave primária na classe cliente com a ref using System.ComponentModel.DataAnnotations; 
- Alterei o appsettings.json para iniciar com a url ~api/Clientes
- Rodei a Aplicação
- Testei o verbo post com o postman

---------------||---------------------------

Conectando com o banco de dados
REF2 - https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-3.1&tabs=visual-studio

Adicionando o ef cli 
REF3 - https://docs.microsoft.com/en-us/ef/core/cli/dotnet


----------------------------------------------------------------------------------------------------------------------------
A CLASSE MODELO

Um modelo é um conjunto de classes que representam os dados gerenciados pelo aplicativo. As propriedades da classe são os 
campos da tabela. 

O CONTEXTO

O contexto de banco de dados é a classe principal que coordena a funcionalidade do Entity Framework para um modelo de dados.
No contexto configuramos as restrições e relacionamento dos campos declarados no modelo. Escrever essas configurações dessa 
forma é chamado de fluent Api.

REGISTRO NA CLASSE STARTUP
No ASP.NET Core, serviços como o contexto de BD precisam ser registrados no contêiner de injeção de dependência. O 
contêiner fornece o serviço aos controladores. Nesse registro,  também especificamos não só o banco de dados que será usado
mas também o newtonSoft para resolver problemas na serialização.

O CONTROLLER
Para lidar com solicitações, uma API Web usa controladores. O controller gerado marca a classe com o atributo [ApiController]. 
Esse atributo indica se o controlador responde às solicitações da API Web. 

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