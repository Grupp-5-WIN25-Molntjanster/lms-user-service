# lms-user-service

Det här är min user/profile-service till vårt LMS-projekt i kursen Molntjänster och distribuerade system.

Servicen ansvarar för användarens profilsida och hanterar bland annat:

* profilinformation
* skills
* achievements
* profilbild
* uppladdning av bilder till Azure Blob Storage

Projektet är byggt i ASP.NET Core Web API med Entity Framework Core och SQL Server.

# Funktioner

Just nu finns stöd för:

* Hämta profil
* Uppdatera profil
* Lägga till och ta bort skills
* Lägga till och ta bort achievements
* Ladda upp profilbild till Azure Blob Storage

# Tekniker som används

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Azure App Service
* Azure SQL Database
* Azure Blob Storage
* Swagger/OpenAPI

# API-endpoints

## Profile

GET
`/api/profile`

PUT
`/api/profile`

POST
`/api/profile/upload-image`

## Skills

GET
`/api/profile/skills`

POST
`/api/profile/skills`

DELETE
`/api/profile/skills/{id}`

## Achievements

GET
`/api/profile/achievements`

POST
`/api/profile/achievements`

DELETE
`/api/profile/achievements/{id}`

# Köra projektet lokalt

1. Klona repot
2. Öppna solutionen i Visual Studio
3. Kör migrations om databasen saknas
4. Starta projektet med HTTPS-profilen
5. Swagger öppnas automatiskt

# Azure

Projektet är deployat till Azure App Service.

Databasen körs via Azure SQL Database och bilder sparas i Azure Blob Storage.

Secrets och connection strings ligger i Azure App Service settings och pushas inte till GitHub.

# Frontend

Frontenddelen är byggd separat i Next.js och kommunicerar med denna service via API-anrop.

Exempel på base URL:

`https://lms-user-service-ayler-a9h4g0b9gterfhca.germanywestcentral-01.azurewebsites.net`

# Kommentar

Fokus i projektet har varit att hålla lösningen enkel, tydlig och fungerande inom den begränsade tidsramen för kursen.
