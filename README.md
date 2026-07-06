# StreamBox - Movie Streaming Management Platform

## Overview

StreamBox is a full-stack movie management platform inspired by modern streaming services such as Netflix. The application was developed using ASP.NET Core MVC and ASP.NET Core Web API, following a service-oriented architecture where the MVC application communicates exclusively with the RESTful API instead of accessing the database directly. This structure improves separation of concerns, maintainability, scalability, and reflects real-world enterprise software development practices.

The backend API was built with Dapper as the data access technology, providing lightweight and high-performance SQL operations. All database operations, including CRUD processes, relational queries, and reports, are handled through the API layer. The MVC application consumes these API endpoints using HttpClient, which keeps the presentation layer independent from the database.

The system allows users to browse movies, view movie details, register, and log in. Administrators can access a dedicated management panel through session-based authentication. The admin panel includes movie, category, actor, and movie-actor management modules. It also provides statistical reports, PDF export, and Excel export features.

This project demonstrates practical experience with ASP.NET Core MVC, ASP.NET Core Web API, Dapper, RESTful API development, SQL Server, Repository Pattern, HttpClient, session authentication, relational database design, reporting, and responsive interface development.

---

## Architecture

The application consists of two main projects.

### StreamBox API

The API project is responsible for database communication and business operations.

- RESTful Web API
- Dapper ORM
- Repository Pattern
- SQL Server LocalDB
- CRUD Operations
- JOIN Queries
- GROUP BY Reports
- JSON Responses

### StreamBox MVC

The MVC project works as the presentation layer and communicates with the API using HttpClient.

- ASP.NET Core MVC
- HttpClient API Integration
- Login and Register
- Session-Based Authentication
- Responsive User Interface
- Admin Dashboard
- Movie Detail Pages
- PDF Export
- Excel Export

---

## Technologies

- ASP.NET Core MVC (.NET 10)
- ASP.NET Core Web API (.NET 10)
- C#
- Dapper
- SQL Server LocalDB
- RESTful API
- HttpClient
- Repository Pattern
- Bootstrap 5
- HTML5
- CSS3
- JavaScript
- LINQ
- Newtonsoft.Json
- QuestPDF
- ClosedXML

---

## NuGet Packages

- Dapper
- Microsoft.Data.SqlClient
- Newtonsoft.Json
- QuestPDF
- ClosedXML
- Swashbuckle.AspNetCore
- Microsoft.AspNetCore.Session

---

## Database Design

The project uses a relational SQL Server database with four connected tables.

| Table | Description |
|------|-------------|
| Categories | Stores movie category information |
| Movies | Stores movie details |
| Actors | Stores actor information |
| MovieActors | Junction table between Movies and Actors |

### Relationships

- Categories and Movies have a one-to-many relationship.
- Movies and Actors have a many-to-many relationship.
- MovieActors is used as the junction table between Movies and Actors.

---

## Features

### User Features

- Browse movies
- View movie details
- Register
- Login
- Responsive movie platform interface

### Admin Features

- Admin dashboard
- Movie management CRUD
- Category management CRUD
- Actor management CRUD
- Movie actor management CRUD
- Statistical reports
- PDF export
- Excel export

---

## Reports

The project includes ten different reports generated from SQL Server using Dapper queries.

- Total movie count
- Total category count
- Total actor count
- Movie actor count
- Oldest movie
- Newest movie
- Movie count by category
- Actor count by country
- Movie category list
- Movie actor list

---

## API Endpoints

### Movies

- GET
- POST
- PUT
- DELETE

### Categories

- GET
- POST
- PUT
- DELETE

### Actors

- GET
- POST
- PUT
- DELETE

### MovieActors

- GET
- POST
- PUT
- DELETE

### Reports

- MovieCount
- CategoryCount
- ActorCount
- MovieCountByCategory
- ActorCountByCountry
- MovieCategoryList
- MovieActorList
- OldestMovie
- NewestMovie
- MovieActorCount

---

## Project Screenshots

### Home Page

![Home](https://github.com/adenyabasak/StreamBox/blob/main/images/home.png)

The home page presents movies in a modern Netflix-inspired interface and allows users to browse the platform easily.

---

### Movie Details

![Movie Details](https://github.com/adenyabasak/StreamBox/blob/main/images/detay.png)

Displays detailed information about the selected movie, including category, release year, description, and related content.

---

### Login

![Login](https://github.com/adenyabasak/StreamBox/blob/main/images/login.png)

Users can securely log into the system through a clean and responsive authentication page.

---

### Register

![Register](https://github.com/adenyabasak/StreamBox/blob/main/images/register.png)

Allows new users to create an account before accessing the movie platform.

---

### Admin Dashboard

![Admin Dashboard](https://github.com/adenyabasak/StreamBox/blob/main/images/admindashboard.png)

The admin dashboard provides statistics and quick access to management modules.

---

### Movie Management

![Movie Management](https://github.com/adenyabasak/StreamBox/blob/main/images/filmyonetimi.png)

Administrators can add, update, delete, and list movies through the management panel.

---

### Category Management

![Category Management](https://github.com/adenyabasak/StreamBox/blob/main/images/kategoriyonetimi.png)

Provides category management operations for organizing movies.

---

### Actor Management

![Actor Management](https://github.com/adenyabasak/StreamBox/blob/main/images/oyuncuyonetimi.png)

Allows administrators to manage actor records.

---

### Movie Actor Management

![Movie Actor Management](https://github.com/adenyabasak/StreamBox/blob/main/images/filmoyunculari.png)

Manages the many-to-many relationship between movies and actors.

---

### Reports

![Reports](https://github.com/adenyabasak/StreamBox/blob/main/images/raporlar.png)

Displays statistical reports generated with SQL queries and Dapper.

---

### PDF Export

![PDF Export](https://github.com/adenyabasak/StreamBox/blob/main/images/pdf.png)

Exports report data into PDF format using QuestPDF.

---

### Excel Export

![Excel Export](https://github.com/adenyabasak/StreamBox/blob/main/images/excel.png)

Exports application data and reports into Microsoft Excel format using ClosedXML.

---

## Learning Outcomes

During the development of this project, I gained practical experience with:

- ASP.NET Core MVC
- ASP.NET Core Web API
- Dapper
- RESTful API Design
- Repository Pattern
- SQL Server
- HttpClient
- Session Authentication
- CRUD Operations
- JOIN Queries
- GROUP BY Queries
- Relational Database Design
- Admin Dashboard Development
- PDF Generation
- Excel Export
- Responsive UI Design
- Enterprise Application Architecture

---

## Developer

Başak Erdoğan

Backend Developer

ASP.NET Core MVC | ASP.NET Core Web API | Dapper | SQL Server | RESTful API
