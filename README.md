# Truck App

##### Vers�o 1.0.0

O objetivo do aplicativo � possibilitar o usu�rio realizar o gerenciamento do cadastro de caminh�es. Voc� pode acessa-lo [aqui](http://trucksapp.azurewebsites.net/).

Onde ser� poss�vel: 

1. Visualizar
2. Atualizar
3. Excluir
4. Inserir

Um caminh�o tem os seguintes atributos:

1. Chassis
   1. Obrigat�rio
   2. Texto 
   3. Limite de 17 caracteres
      1. 13 primeiras posi��es variam de A-HJ-NPR-Z0-9 
      2. 4 �ltimas posi��es variam de 0-9 
2. Modelo
   1. Obrigat�rio
   2. N�mero
   3. Valores fixos FH (1) ou FM (2)
4. Complemento do Modelo
   1. Opcional
   2. Texto 
   3. Informa��es adicionais do Modelo
5. Ano
   1. Obrigat�rio
   2. N�mero 
   3. Ano atual do cadastro
6. Ano do Modelo
   1. Obrigat�rio
   2. N�mero
   3. Ano atual do cadastro ou subsequente.

## Iniciando

O projeto est� dispon�vel no [GitHub](https://github.com/KaueReinbold/Trucks), ap�s clonar o reposit�rio o aplicativo poder� ser executado de tr�s formas:

1. Utilizando o [Visual Studio](https://visualstudio.microsoft.com/downloads/)
2. Utilizando o [Visual Studio Code](https://code.visualstudio.com/download)
3. Atrav�s de [.Net CLI](https://docs.microsoft.com/pt-br/dotnet/core/tools/?tabs=netcore2x) 

### Pr�-requisitos

O aplicativo foi desenvolvido utilizando o [.Net Core v2.2](https://dotnet.microsoft.com/download), ent�o ser� necess�rio que seja instalado essa vers�o ou superior no ambiente.
Tamb�m ser� necess�rio uma vers�o do [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) ou superior para visualiza��o do c�digo fonte e depura��o.

Para persistencia de dados foi utlizado o [SQL Server](https://docs.microsoft.com/pt-br/sql), ser� necess�rio ter uma inst�ncia dispon�vel e um usu�rio com a permiss�o de `dbcreator`.

### Configurando

Para armezenamento de dados foi utilizado o ORM (Object Relational Mapping) [Entity Framework Core v.2.2](https://docs.microsoft.com/pt-br/ef/core/) e configurado a funcionalidade [Migrations](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/) o que permite que a aplica��o crie o banco de dados assim que seja executada.

Caso n�o exista uma int�ncia do SQL Server dispon�vel para utiliza��o podera ser usuado um banco de dados em mem�ria.
Para isso basta entrar no arquivo [Startup.cs](https://github.com/KaueReinbold/Trucks/1%20-%20Presentation/Trucks.Mvc/Startup.cs)

Alterar de `services.AddDatabase` para `services.AddDatabaseInMemory`

Usando SQL Server - Nesse caso � necess�rio adicionar uma string de conex�o valida no arquivo [appsettings.json](https://github.com/KaueReinbold/Trucks/1%20-%20Presentation/Trucks.Mvc/appsettings.json)
```csharp
services.AddDatabase(Configuration.GetConnectionString("DefaultConnection"));
```

Usando Banco de Dados em mem�ria.
```csharp
services.AddDatabaseInMemory("DefaultConnection");
```

## Rodando Unit Tests

Os testes poder�o ser executados de duas formas:

1. Atrav�s do [Test Explorer](https://docs.microsoft.com/pt-br/visualstudio/test/run-unit-tests-with-test-explorer) no Visual Studio
2. .Net Cli [dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)

Os testes est�o cobrindo os m�todos das classes:

1. [TruckController](https://github.com/KaueReinbold/Trucks/TruckController.cs)
2. [TruckService](https://github.com/KaueReinbold/Trucks/TruckService.cs)

| Classe          | M�todo                             | 
| --------------- | ---------------------------------- |
| TruckController | Create_ShouldReturnValidationError |
| TruckController | Edit_ShouldGetItem                 |
| TruckController | Create_ShouldThrowException        |
| TruckController | Delete_ShouldDeleteItem            |
| TruckController | Edit_ShouldThrowException          |
| TruckController | Create_ShouldReturnViewWithYear    |
| TruckController | ModelValidate                      |
| TruckController | Details_ShouldGetItem              |
| TruckController | Create_ShouldCreateItem            |
| TruckController | Create_ShouldReturnView            |
| TruckController | Delete_ShouldThrowException        |
| TruckController | Delete_ShouldGetItem               |
| TruckController | Edit_ShouldEditItem                |
| TruckController | Edit_ShouldReturnValidationError   |
| TruckController | Index_ShouldGetList                |
| TruckService    | Find_ShouldFindItem                |
| TruckService    | Add_ShouldAddNewItem               |
| TruckService    | Remove_ShouldRemoveItem            |
| TruckService    | GetAll_ShouldListAllItems          |
| TruckService    | Update_ShouldUpdateItem            |

## Desenvolv�do com:

### Tecnologia 
* [.Net Core](https://docs.microsoft.com/pt-br/dotnet/core/) - O .NET Core � uma plataforma desenvolvida pela Microsoft com c�digo aberto.
* [ASP.Net MVC Core](https://docs.microsoft.com/en-us/aspnet/core/mvc) - Model-View-Controller.
* [MSTest](https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-mstest) - Test Unit�rios.
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) - ORM (Object Relational Mapping - Mapeador de Objeto Relacional)
* [.NET Core Dependency Injection](https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection) - IoC (Inversion of Control - Invers�o de Controle)
* [AutoMapper](https://automapper.org/) - Mapeamento entre objetos.

### Arquitetura
* [SoC](https://pt.wikipedia.org/wiki/Separa%C3%A7%C3%A3o_de_conceitos) - Sepra��o de Conceito.
* [SOLID](https://www.eduardopires.net.br/2013/04/orientacao-a-objeto-solid/) - Separa��o de responsabilidade, Aberto-fechado, Substitui��o de Liskov , Segrega��o de Interface e Inje��o de Dependencia.
* [DDD](https://www.devmedia.com.br/ddd-domain-driven-design-com-net/14416) - Domain Driven Design.
* [TDD](https://pt.wikipedia.org/wiki/Test_Driven_Development) - Test Driven Development.
* [Repository](https://docs.microsoft.com/pt-br/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design) - Padr�o Repository.
* [Unit of Work](https://docs.microsoft.com/pt-br/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application) - Sepera��o em Unidade de Trabalho.

## Autor

* **Kaue Reinbold** - [GitHub](https://github.com/KaueReinbold)