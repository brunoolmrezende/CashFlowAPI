## Sobre o projeto

Esta **API**, desenvolvida com **.NET 8**, segue os princípios do **Domain-Driven Design (DDD)** para proporcionar uma solução estruturada e eficaz no gerenciamento de despesas pessoais. Seu objetivo principal é permitir que os usuários registrem despesas com informações detalhadas como título, data e hora, descrição, valor e tipo de pagamento, armazenando os dados de forma segura em um banco de dados **MySQL**.

A arquitetura da **API** é baseada em **REST**, utilizando métodos **HTTP** padrão para uma comunicação eficiente. Além disso, conta com documentação **Swagger**, proporcionando uma interface gráfica interativa para que os desenvolvedores possam explorar e testar os endpoints facilmente.

Dentre os pacotes NuGet utilizados, o **AutoMapper** facilita o mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo e manual. O **FluentAssertions** é empregado nos testes de unidade, tornando as verificações mais legíveis e ajudando a escrever testes claros e compreensíveis. Para as validações, o **FluentValidation** implementa regras de forma simples e intuitiva nas classes de requisições, mantendo o código limpo e fácil de manter. Por fim, o **EntityFramework** atua como um ORM (Object-Relational Mapper), simplificando as interações com o banco de dados e permitindo o uso de objetos .NET para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.

### Features

- **Domain-Driven Design (DDD):** Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- **Testes de Unidade:** Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- **Geração de Relatórios:** Capacidade de exportar relatórios detalhados para **PDF** e **Excel**, oferecendo uma análise visual e eficaz das despesas.
- **RESTful API com Documentação Swagger:** Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

## Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio versão 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOS com [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) instalado
* MySql Server

### Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/brunoolmrezende/CashFlowAPI.git
    ```

2. Preencha as informações no arquivo `appsettings.Development.json`.
3. Execute a API e aproveite o seu teste :)

