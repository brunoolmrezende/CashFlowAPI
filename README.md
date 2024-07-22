## Sobre o projeto

Esta **API**, desenvolvida com **.NET 8**, segue os princípios do **Domain-Driven Design (DDD)** para proporcionar uma solução estruturada e eficaz no gerenciamento de despesas pessoais. Seu objetivo principal é permitir que os usuários registrem despesas com informações detalhadas como título, data e hora, descrição, valor e tipo de pagamento, armazenando os dados de forma segura em um banco de dados **MySQL**.

A arquitetura da **API** é baseada em **REST**, utilizando métodos **HTTP** padrão para uma comunicação eficiente. Além disso, conta com documentação **Swagger**, proporcionando uma interface gráfica interativa para que os desenvolvedores possam explorar e testar os endpoints facilmente.

Entre os pacotes NuGet utilizados, destacam-se:

**AutoMapper**: Facilita o mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo.

**FluentAssertions**: Torna as verificações nos testes de unidade mais legíveis e compreensíveis.

**FluentValidation**: Implementa regras de validação de forma simples e intuitiva nas classes de requisições, mantendo o código limpo e fácil de manter.

**EntityFramework**: Atua como um ORM (Object-Relational Mapper), simplificando as interações com o banco de dados e permitindo o uso de objetos .NET para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.

Essa combinação de tecnologias e práticas garante uma API robusta, segura e fácil de usar e manter.