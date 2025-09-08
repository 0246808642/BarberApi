✂️ Descrição
💈 Barber API é uma API desenvolvida para gerenciar os processos de uma barbearia, incluindo clientes, serviços e agendamentos, com autenticação de usuários e boas práticas de desenvolvimento.
⚙️ Ela foi construída com .NET 8, Entity Framework Core e .NET Identity, garantindo segurança, escalabilidade e manutenção facilitada.

🚀 Funcionalidades
- 🔹 CRUD completo para Agendamento, Cliente e Serviço
- 🔐 Autenticação de usuários com registro e login via .NET Identity
- 📌 Controle de versões da API para facilitar manutenção e evolução
- ✅ Validações robustas com Data Annotations em entidades e DTOs
- 📊 Enums para controlar tipos de serviço e status de agendamentos
- 📂 DTOs separados em Create, Update e Read para melhor organização
- ⚡ Automapper para mapeamento automático entre DTOs e entidades
- 📝 Swagger integrado com suporte à autorização via JWT
- 🔑 User Secrets para informações sensíveis, como tokens e connection strings
- 🔗 Relacionamentos entre entidades:
  - Um Agendamento possui um Serviço
  - Um Cliente pode ter vários Agendamentos

🏗 Estrutura do Projeto
Controllers
- 🗂 AgendamentoController – CRUD de agendamentos
- 🗂 ClienteController – CRUD de clientes
- 🗂 ServicoController – CRUD de serviços
- 🗂 AutorizacaoController – endpoints de login e registro
> Todos os controladores usam Services que implementam interfaces, garantindo padronização e facilidade de testes.

Services
- 🔹 AgendamentoService
- 🔹 ClienteService
- 🔹 ServicoService
- 🔹 UsuarioService
> Registrados como Scoped no Program.cs para gerenciar o ciclo de vida dos objetos e permitir injeção de dependências.

DTOs
- 📌 Create, Update e Read para Agendamento, Cliente e Serviço
- ✅ Validações com Data Annotations para garantir integridade de dados

Entities & Database
- 💾 Dois DbContexts separados:
  - Um para entidades da barbearia (Agendamento, Cliente, Serviço)
  - Outro para usuários via .NET Identity
- 🔗 Relacionamentos:
  - Um Agendamento está associado a um Serviço
  - Um Cliente pode ter vários Agendamentos
- 📝 Migrations independentes para cada contexto

Configurações
- 🔑 JWT Token: validade de 2 horas
- 📚 Swagger configurado com autenticação via JWT
- 🗝 Connection Strings e dados sensíveis gerenciados via User Secrets

🛠 Tecnologias Utilizadas
- ⚡ .NET 8 – Plataforma principal de desenvolvimento
- 🗄 Entity Framework Core 8 – ORM para gerenciamento de banco de dados
- 🔐 .NET Identity – Autenticação e gerenciamento de usuários
- 🔄 Automapper – Mapeamento automático entre DTOs e entidades
- 📄 Swagger – Documentação interativa da API
- ✅ Data Annotations – Validação de dados e regras de negócio

🏷 Enumerações
- 💈 Tipos de Serviço – Define os serviços disponíveis para o cliente
- ⏳ Status de Agendamento – Cada agendamento inicia com um status padrão definido por enum

📌 Observações
- 🏛 Arquitetura pensada com Clean Architecture, separando responsabilidades entre Controllers, Services e DTOs
- 🚀 Preparada para expansão, manutenção contínua e fácil integração com frontend
- 🧭 Rotas documentadas e testáveis via Swagger
- 🔗 Relacionamentos claros entre Clientes, Agendamentos e Serviços, garantindo consistência e integridade dos dados
