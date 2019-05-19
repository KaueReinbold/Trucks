# Truck App

##### Versão 1.0.0

O objetivo do aplicativo é possibilitar o usuário realizar o gerenciamento do cadastro de caminhões. Você pode acessa-lo [aqui](http://trucksapp.azurewebsites.net/).

Onde será possível: 

1. Visualizar
2. Atualizar
3. Excluir
4. Inserir

Um caminhão tem os seguintes atributos:

1. Chassis
   1. Obrigatório
   2. Texto 
   3. Limite de 17 caracteres
      1. 13 primeiras posições variam de A-HJ-NPR-Z0-9 
      2. 4 últimas posições variam de 0-9 
2. Modelo
   1. Obrigatório
   2. Número
   3. Valores fixos FH (1) ou FM (2)
4. Complemento do Modelo
   1. Opcional
   2. Texto 
   3. Informações adicionais do Modelo
5. Ano
   1. Obrigatório
   2. Número 
   3. Ano atual do cadastro
6. Ano do Modelo
   1. Obrigatório
   2. Número
   3. Ano atual do cadastro ou subsequente.

## Iniciando

O projeto está disponível no [GitHub](https://github.com/KaueReinbold/Trucks), após clonar o repositório o aplicativo poderá ser executado de três formas:

1. Utilizando o [Visual Studio](https://visualstudio.microsoft.com/downloads/)
2. Utilizando o [Visual Studio Code](https://code.visualstudio.com/download)
3. Através de [.Net CLI](https://docs.microsoft.com/pt-br/dotnet/core/tools/?tabs=netcore2x) 

### Pré-requisitos

O aplicativo foi desenvolvido utilizando o [.Net Core v2.2](https://dotnet.microsoft.com/download), então será necessário que seja instalado essa versão ou superior no ambiente.
Também será necessário uma versão do [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) ou superior para visualização do código fonte e depuração.

Para persistencia de dados foi utlizado o [SQL Server](https://docs.microsoft.com/pt-br/sql), será necessário ter uma instância disponível e um usuário com a permissão de `dbcreator`.

### Configurando

Para armezenamento de dados foi utilizado o ORM (Object Relational Mapping) [Entity Framework Core v.2.2](https://docs.microsoft.com/pt-br/ef/core/) e configurado a funcionalidade [Migrations](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/) o que permite que a aplicação crie o banco de dados assim que seja executada.

Caso não exista uma intância do SQL Server disponível para utilização podera ser usuado um banco de dados em memória.
Para isso basta entrar no arquivo [Startup.cs](https://github.com/KaueReinbold/Trucks/1%20-%20Presentation/Trucks.Mvc/Startup.cs)

Alterar de `services.AddDatabase` para `services.AddDatabaseInMemory`

Usando SQL Server - Nesse caso é necessário adicionar uma string de conexão valida no arquivo [appsettings.json](https://github.com/KaueReinbold/Trucks/1%20-%20Presentation/Trucks.Mvc/appsettings.json)
```csharp
services.AddDatabase(Configuration.GetConnectionString("DefaultConnection"));
```

Usando Banco de Dados em memória.
```csharp
services.AddDatabaseInMemory("DefaultConnection");
```

## Rodando Unit Tests

Os testes poderão ser executados de duas formas:

1. Através do [Test Explorer](https://docs.microsoft.com/pt-br/visualstudio/test/run-unit-tests-with-test-explorer) no Visual Studio
2. .Net Cli [dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)

Os testes estão cobrindo os métodos das classes:

1. [TruckController](https://github.com/KaueReinbold/Trucks/TruckController.cs)
2. [TruckService](https://github.com/KaueReinbold/Trucks/TruckService.cs)

| Classe          | Método                             | 
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

## Desenvolvído com:

### Tecnologia 
* [.Net Core](https://docs.microsoft.com/pt-br/dotnet/core/) - O .NET Core é uma plataforma desenvolvida pela Microsoft com código aberto.
* [ASP.Net MVC Core](https://docs.microsoft.com/en-us/aspnet/core/mvc) - Model-View-Controller.
* [MSTest](https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-mstest) - Test Unitários.
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) - ORM (Object Relational Mapping - Mapeador de Objeto Relacional)
* [.NET Core Dependency Injection](https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection) - IoC (Inversion of Control - Inversão de Controle)
* [AutoMapper](https://automapper.org/) - Mapeamento entre objetos.

### Arquitetura
* [SoC](https://pt.wikipedia.org/wiki/Separa%C3%A7%C3%A3o_de_conceitos) - Sepração de Conceito.
* [SOLID](https://www.eduardopires.net.br/2013/04/orientacao-a-objeto-solid/) - Separação de responsabilidade, Aberto-fechado, Substituição de Liskov , Segregação de Interface e Injeção de Dependencia.
* [DDD](https://www.devmedia.com.br/ddd-domain-driven-design-com-net/14416) - Domain Driven Design.
* [TDD](https://pt.wikipedia.org/wiki/Test_Driven_Development) - Test Driven Development.
* [Repository](https://docs.microsoft.com/pt-br/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design) - Padrão Repository.
* [Unit of Work](https://docs.microsoft.com/pt-br/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application) - Seperação em Unidade de Trabalho.

## Autor

* **Kaue Reinbold** - [GitHub](https://github.com/KaueReinbold)