conexão com o banco

Ref - https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio#add-a-model-class

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

