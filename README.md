
# Migration
- Api Katmanında aşağıdaki kodları çalıştır.
  - dotnet ef migrations add initialize --context AppDbContext
  - dotnet ef database update --context AppDbContext
