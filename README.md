🎮 GameStore API – Fase 1
API REST desenvolvida em .NET 8 como parte do Desafio da Fase 1 da disciplina Arquitetura de Sistemas .NET – FIAP.
O objetivo do projeto é gerenciar usuários e jogos adquiridos, servindo como base para futuras funcionalidades da plataforma de games educacionais da FIAP (FCG).

📌 Objetivo do Projeto
Construir uma API REST seguindo boas práticas de desenvolvimento, garantindo:

Persistência de dados
Organização e separação de responsabilidades
Qualidade de código
Base escalável para próximas fases (matchmaking, servidores, etc.)

🛠️ Tecnologias Utilizadas

.NET 8
ASP.NET Core Web API
Entity Framework Core
SQLite (ambiente de desenvolvimento)
JWT (JSON Web Token) para autenticação
Swagger / OpenAPI
Arquitetura em camadas (Clean Architecture)

🧱 Arquitetura do Projeto
O projeto está organizado seguindo uma separação clara de responsabilidades:
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

🔹 Camadas

Api: Controllers, autenticação, middlewares e configuração da aplicação
Application: Serviços de aplicação e regras de negócio
Domain: Entidades, Value Objects e exceções de domínio
Infrastructure: Acesso a dados, repositórios e EF Core

🔐 Autenticação
A autenticação é realizada por JWT.
Endpoints protegidos exigem o envio do token no header:
Authorization: Bearer {seu_token}

🔗 Endpoints Principais
✅ Autenticação
🔹 Login
POST /auth/login

Body:
JSON{  "email": "user@email.com",  "password": "Senha@123"}Show more lines

👤 Usuários
🔹 Criar usuário
POST /users

Body:
JSON{  "name": "João",  "email": "joao@email.com",  "password": "Senha@123"}Show more lines

🔹 Listar usuários
GET /users

🔹 Buscar usuário por ID
GET /users/{id}

🛡️ Administração (Acesso restrito a Admin)
🔹 Listar usuários (Admin)
GET /admin/users

🔹 Atualizar role do usuário
PUT /admin/users/{id}/role

Body:
JSON{  "role": "Admin"}``Show more lines
Roles possíveis:

User
Admin

🔹 Remover usuário
DELETE /admin/users/{id}


🧪 Swagger
A documentação interativa da API pode ser acessada em:
/swagger

Exemplo:
https://localhost:5001/swagger


▶️ Como Executar o Projeto
Clone o repositório:
Shellgit clone <url-do-repositorio>Show more lines

Acesse a pasta do projeto:
Shellcd GameStoreShow more lines

Execute a aplicação:
Shelldotnet runShow more lines

Abra o navegador em:
https://localhost:5001/swagger

📂 Banco de Dados

Utiliza SQLite em ambiente de desenvolvimento
O banco é criado automaticamente via Entity Framework Migrations
Localização padrão:
bin/Debug/net8.0/gamestore.db

📌 Observações Importantes

Esta API representa um MVP (Minimum Viable Product)
Algumas funcionalidades serão expandidas nas próximas fases
O projeto foi desenvolvido com foco em qualidade, clareza e extensibilidade


👥 Squad 8 – Turma 12NETT
Integrantes:

Heloa Guizzo Cardoso
Luiz Gustavo Dionizio Soares
Yan Santos Wendt
Luiz Valmir Teixeira Braga Junior
Ronnam de Lima da Silva
