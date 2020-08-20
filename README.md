## Mestre dos códigos
### 1. Segurança
Um Arquiteto de Software deve garantir e prezar pela segurança da aplicação sob sua responsabilidade. Este tópico aborda questões de ambiente, aplicação e análise de vulnerabilidades comumente divulgados pela OWASP.

#### TOP 1 OWASP - Injection
c#
```c#
public async Task<User> GetByLoginAndPasswordAsync(string login, string password)
{
    var query = "SELECT * FROM Users WHERE Login = '" + login + "' AND Password = '" + password + "'";

    var result = await _owaspDbContext.Users.FromSqlRaw(query).FirstOrDefaultAsync();

    return result;
}
```
request json
```json
{
    "login": "db1global' --",
    "password": "qualquersenha"
}
```

## Para devs

### Informações
* O projeto foi criado em .NET Core
* Entity Framewok como ORM (Object-Relational Mappers)
* SQLite como base de dados

### EF Core
Alguns comandos para uso de migrations
```dotnet ef migrations add Initial --context MDC.Owasp.API.Infrastructure.OwaspDbContext -o Infrastructure/Migrations```
```dotnet ef database update```

### Seed
Dados previamente cadastrados

```c#
var users = new List<User>
{
    new User("db1global", "123456", "DB1 Global Software"),
    new User("db1group", "123456", "DB1 Group"),
    new User("timbot", "123456", "Timbot")
};
```
