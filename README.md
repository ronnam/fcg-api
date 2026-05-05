
# 🎮 GameStore API – Fase 1

API REST desenvolvida em **.NET 8** como parte do **Desafio da Fase 1** da disciplina **Arquitetura de Sistemas .NET – FIAP**.

O projeto representa o **MVP (Minimum Viable Product)** de uma plataforma de games educacionais (**FCG – FIAP Game Center**), com foco no gerenciamento de **usuários** e de seus **jogos adquiridos**, servindo como base para futuras expansões do ecossistema.

---

## 📌 Objetivo do Projeto

Construir uma API REST seguindo **boas práticas de desenvolvimento**, garantindo:

- Persistência de dados
- Qualidade de software
- Segurança
- Organização arquitetural
- Base escalável para próximas fases (matchmaking, gerenciamento de servidores, etc.)

---

## 🛠️ Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**
- **JWT Bearer Authentication**
- **Swagger / OpenAPI**
- **ILogger** para logs estruturados

---

## 🧱 Arquitetura

O projeto segue uma separação clara de responsabilidades, inspirada em princípios de **Clean Architecture**, promovendo manutenibilidade, clareza e escalabilidade.

### Camadas Principais

- **Api**  
  Controllers, middlewares, configuração da aplicação, autenticação e autorização.

- **Application**  
  Serviços de negócio, interfaces, validações e regras de aplicação.

- **Domain**  
  Entidades, Value Objects e exceções de domínio.

- **Infrastructure**  
  Repositórios, acesso a dados e persistência utilizando Entity Framework Core.

---

## 📁 Estrutura de Pastas

```text
GameStore
│
├── GameStore.Api
│   ├── Controllers
│   ├── Middlewares
│   ├── Program.cs
│   └── appsettings.json
│
├── GameStore.Application
│   ├── Services
│   ├── Interfaces
│   ├── Helpers
│   └── DTOs
│
├── GameStore.Domain
│   ├── Entities
│   ├── ValueObjects
│   └── Exceptions
│
└── GameStore.Infrastructure
    ├── Persistence
    ├── Repositories
    └── Seed

```

## 🔐 Segurança

- Autenticação via **JWT Bearer**
- Controle de acesso utilizando:
  - `[Authorize]`
  - `[Authorize(Roles = "Admin")]`
- Middleware global para tratamento de exceções
- Logs estruturados utilizando `ILogger`

---

## 🔑 Níveis de Acesso

### 👤 User

- Pode se autenticar na plataforma
- Pode consultar e alterar seus próprios dados (ex.: email e senha)

### 🛡️ Admin

- Pode listar todos os usuários
- Pode administrar usuários (alterar dados e **role**)
- Pode remover usuários

> **Por padrão, todo usuário registrado é criado com a role `User`.**  
> A role `Admin` é atribuída posteriormente por outro administrador ou via seed/manualmente no banco, garantindo maior segurança.

---

## 🔐 Autenticação com JWT

Após o login (`POST /auth/login`), o usuário recebe um **token JWT**, que deve ser enviado nas requisições protegidas no header:

```http
Authorization: Bearer {token}
As roles são incluídas como claims no token e utilizadas pelo ASP.NET Core para controle de acesso aos endpoints.

## 🔗 Endpoints Principais

✅ Autenticação
Login
POST /auth/login

Body
JSON{  "email": "user@email.com",  "password": "Senha@123"}Show more lines

## 👤 Usuários
Criar usuário
POST /users

JSON{  "name": "João",  "email": "joao@email.com",  "password": "Senha@123"}Show more lines
Listar usuários
GET /users

Buscar usuário por ID
GET /users/{id}

---

## 🛡️ Administração (Admin)

Listar usuários
GET /admin/users

Atualizar role do usuário
PUT /admin/users/{id}/role

JSON{  "role": "Admin"}Show more lines
Roles possíveis:

User
Admin

Remover usuário
DELETE /admin/users/{id}


## 📘 Documentação e Testes

Swagger / OpenAPI
A API possui documentação automática gerada com Swagger, disponível em:
/swagger

Por meio do Swagger é possível:

Visualizar todos os endpoints disponíveis
Ver parâmetros e respostas esperadas
Testar requisições diretamente pela interface
Autenticar usando JWT pelo botão Authorize


## ⚠️ Tratamento de Erros

A API utiliza um middleware global de exceções, responsável por:

Capturar exceções de domínio (ex: NotFoundException)
Traduzir exceções para os códigos HTTP adequados (400, 404, 500)
Retornar respostas JSON padronizadas
Registrar logs estruturados


## 🪵 Logs Estruturados

Os logs são registrados com ILogger, permitindo:

Logs de erro (LogError)
Logs de aviso (LogWarning)
Logs informativos (LogInformation)
Identificação de requisições através de traceId


## 🗄️ Banco de Dados

SQLite
Entity Framework Core
Criação e versionamento do banco via Migrations
Arquivo do banco gerado automaticamente em ambiente de desenvolvimento


## ▶️ Como Executar o Projeto

Pré-requisitos

.NET SDK 8 ou superior
SQLite
EF Core CLI (opcional)

Execução
Acesse:
https://localhost:5001/swagger


## ✅ Considerações Finais

Este projeto foi desenvolvido com foco em:

Boas práticas REST
Segurança e autenticação
Clareza arquitetural
Facilidade de manutenção
Escalabilidade para futuras fases do desafio


## 👥 Squad 8 – Turma 12NETT

Integrantes

Heloa Guizzo Cardoso
Luiz Gustavo Dionizio Soares
Yan Santos Wendt
Luiz Valmir Teixeira Braga Junior
Ronnam de Lima da Silva
