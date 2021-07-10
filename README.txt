conexão com o banco

REF1 - https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio#add-a-model-class

- adicionei a pasta models
- adicionei a classe cliente
- nuGet Microsoft. EntityFrameworkCore. inmemory
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