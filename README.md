lms-user-service

Owner: Ayler Sabbagh

This is the user/profile service for our LMS project in the course Molntjänster och distribuerade system.
The service is responsible for the user's profile page and handles profile information:

* profile information
* skills
* achievements
* image uploads to Azure Blob Storage

The project is built using ASP.NET Core Web API, Entity Framework Core, and SQL Server.

Features

* Get profile
* Update profile
* Add and delete skills
* Add and delete achievements
* Upload profile image to Azure Blob Storage

Tech Stack

 * ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Azure App Service
* Azure SQL Database
* Azure Blob Storage
* Swagger/

API Endpoints 

Profile

GET /api/profile
PUT /api/profile
POST /api/profile/upload-image

Skills

GET /api/profile/skills
POST /api/profile/skills
DELETE /api/profile/skills/{id}

Achievements

GET /api/profile/achievements
POST /api/profile/achievements
DELETE /api/profile/achievements/{id}

How to run the project locally:

Clone the repository, open the solution in Visual Studio, run the database migrations if the database does not exist, and start the project using the HTTPS profile. Swagger will open automatically when the application starts. 

Azure

The project is deployed to Azure App Service. The database runs on Azure SQL Database and images are stored in Azure Blob Storage. Secrets and connection strings are stored in Azure App Service settings and are not pushed to GitHub. 

Frontend

The frontend is built separately using Next.js and communicates with this service through API requests. 

Base URL:

https://lms-user-service-ayler-a9h4g0b9gterfhca.germanywestcentral-01.azurewebsites.net

 Environment variable:
 
NEXT_PUBLIC_API_BASE=https://lms-user-service-ayler-a9h4g0b9gterfhca.germanywestcentral-01.azurewebsites.net
