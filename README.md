### ShortURL

ShortURL is a fast and lightweight URL shortening service built with .NET 9 Web API. The project provides an easy way to shorten long URLs and manage them efficiently. ([Project idea](https://roadmap.sh/projects/url-shortening-service))

### Getting Started

Follow these steps to set up and run the project locally:

#### Prerequisites

- .NET 9
- SQL Server (or any other supported database)
- Visual Studio or any other preferred IDE(or code editor)

#### Installation
1. Clone the repository:

   ```
   git clone https://github.com/zaminalili/shorturl.git
   ```
2. Restore dependencies:
   ```
   dotnet restore
   ```
3. Set up the database connection string in `appsettings.Development.json`
4. Apply migrations:
   ```
   dotnet ef database update
   ```
5. Run the project:
   ```
   dotnet run
   ```

### API Endpoints

* **`POST /api/shorten`**
  - Body: 
``
{
  "OriginalUrl": "https://www.example.com/some/long/url"
}
``

* **`GET /api/shorten/{shortCode}`**

* **`PUT /api/shorten/{shortCode}`**
  - Body:
``
{
  "originalUrl": "https://www.example.com/some/updated/url"
}
``

* **`DELETE /api/shorten/{shortCode}`**
