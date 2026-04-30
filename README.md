# fcg-api
# GameStore API

API REST desenvolvida em **ASP.NET Core** para gerenciamento de usuários e autenticação, com **controle de acesso por níveis (User e Admin)**, **JWT**, **Swagger/OpenAPI**, **Entity Framework Core** e **tratamento global de erros com logs estruturados**.

## Funcionalidades

### Autenticação e Autorização

- Registro de usuários
- Login com retorno de **JWT**
- Autorização baseada em **roles**
    - `User`
    - `Admin`

### Usuários

- Listar usuários (**Admin**)
- Buscar usuário por ID (**Admin**)
- Atualizar usuário (**Admin**)
- Atualizar dados do próprio usuário (**User**)
- Remover usuário (**Admin**)

### Segurança

- Autenticação via **JWT Bearer**
- Controle de acesso com `[Authorize]` e `[Authorize(Roles = "Admin")]`
- Middleware global para tratamento de exceções
- Logs estruturados usando `ILogger`

### Documentação

- **Swagger / OpenAPI** para documentação automática
- Interface interativa para testes da API

---

## Arquitetura

O projeto segue uma separação clara de responsabilidades

Camadas principais
- **Api**: Controllers, Middlewares, configuração e autenticação
- **Application**: Serviços de negócio
- **Domain**: Entidades, Value Objects e exceções de domínio
- **Infrastructure**: Repositórios e acesso a dados (EF Core)

## Níveis de Acesso

### User

- Pode se autenticar na plataforma
- Pode alterar seus próprios dados (ex: email, senha)

### Admin

- Pode listar usuários
- Pode administrar usuários (alterar dados e role)
- Pode remover usuários

> **Por padrão, todo usuário registrado é criado como `User`.**
> O papel `Admin` é atribuído posteriormente por outro administrador ou via seed/manualmente no banco, garantindo maior segurança.


## Autenticação com JWT

Após o login (`POST /auth/login`), o usuário recebe um token JWT.

Esse token deve ser enviado nas requisições protegidas.

As roles são incluídas como **claims** no token e utilizadas pelo ASP.NET Core para controle de acesso.

## Testes e Documentação com Swagger

Através do Swagger é possível:

- Visualizar todos os endpoints
- Ver parâmetros e respostas esperadas
- Testar requisições diretamente pela interface
- Autenticar usando JWT via botão **Authorize**

## Tratamento de Erros

A API utiliza um **middleware global de exceções**, responsável por:

- Capturar exceções de domínio (ex: `NotFoundException`)
- Traduzir exceções para status HTTP adequados (404, 400, 500)
- Retornar respostas JSON padronizadas
- Registrar logs estruturados

## Logs Estruturados

Os logs são registrados usando `ILogger`, permitindo:

- Logs de erro (`LogError`)
- Logs de aviso (`LogWarning`)
- Logs com contexto da requisição
- Identificação de erros via `traceId`

## Banco de Dados

- **SQLite**
- **Entity Framework Core**
- Criação e versionamento do banco via **Migrations**

## Como Executar o Projeto

### Pré-requisitos

- .NET SDK 8 ou superior
- SQLite
- EF Core CLI (opcional)

## Considerações Finais

Este projeto foi desenvolvido com foco em:

- Boas práticas REST
- Segurança
- Clareza arquitetural
- Facilidade de manutenção
- Escalabilidade

Atende aos requisitos propostos e segue padrões amplamente utilizados em aplicações .NET modernas.
