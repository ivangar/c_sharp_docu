#pragma warning disable CS8321 // Local function is declared but never used
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS0219 // Variable is assigned but its value is never used

/********************************************************************
 *                       .Net Core Fundamentals                      *
 ********************************************************************/

/*

ASP.NET Core
│
├── MVC
├── Web API
├── Razor Pages
├── Minimal APIs
├── Authentication
├── Authorization
├── Dependency Injection
├── Configuration
├── Middleware
├── Logging
├── Entity Framework Core
├── Identity
├── SignalR
├── Background Services
└── Hosting

*/

/* 
To compile a .NET Core project enter at a command prompt the command: 
*/

using System.Threading.Tasks;

dotnet build

/*
To compile and execute a .NET Core project enter at a command prompt the command: 
*/

  dotnet run


/*
To automatically rebuild and re-runs your application (hot reload) enter at a command prompt the command: 
*/

  dotnet watch


/********************************************************************
 *                   SDK default project templates                   *
 ********************************************************************/


/*
// type the following command in a terminal to list all the templates available: 
    dotnet new list

// To view all customization options for a specific template, use the following command
    dotnet new <template-name> --help

// Common ASP.NET Core default project templates include:

Template Name                              Short Name                    Language    Tags
-----------------------------------------  ----------------------------  ----------  ----------------------------------
API Controller                             apicontroller                 [C#]        Web/ASP.NET
ASP.NET Core Empty                         web                           [C#],F#     Web/Empty
ASP.NET Core gRPC Service                  grpc                          [C#]        Web/gRPC/API/Service
ASP.NET Core Web API                       webapi                        [C#],F#     Web/Web API/API/Service
ASP.NET Core Web API (native AOT)          webapiaot                     [C#]        Web/Web API/API/Service
ASP.NET Core Web App (Model-View-Contr...  mvc                           [C#],F#     Web/MVC
ASP.NET Core Web App (Razor Pages)         webapp,razor                  [C#]        Web/MVC/Razor Pages
Blazor Web App                             blazor                        [C#]        Web/Blazor/WebAssembly
Blazor WebAssembly Standalone App          blazorwasm                    [C#]        Web/Blazor/WebAssembly/PWA
Class Library                              classlib                      [C#],F#,VB  Common/Library
Console App                                console                       [C#],F#,VB  Common/Console
dotnet gitattributes file                  gitattributes,.gitattributes              Config
dotnet gitignore file                      gitignore,.gitignore                      Config
Dotnet local tool manifest file            tool-manifest                             Config
EditorConfig file                          editorconfig,.editorconfig                Config
global.json file                           globaljson,global.json                    Config
MSBuild Directory.Build.props file         buildprops                                MSBuild/props
MSBuild Directory.Build.targets file       buildtargets                              MSBuild/props
MSBuild Directory.Packages.props file      packagesprops                             MSBuild/packages/props/CPM
MSTest Playwright Test Project             mstest-playwright             [C#]        Test/MSTest/Playwright/Desktop/Web
MSTest Test Class                          mstest-class                  [C#],F#,VB  Test/MSTest
MSTest Test Project                        mstest                        [C#],F#,VB  Test/MSTest/Desktop/Web
MVC Controller                             mvccontroller                 [C#]        Web/ASP.NET
MVC ViewImports                            viewimports                   [C#]        Web/ASP.NET
MVC ViewStart                              viewstart                     [C#]        Web/ASP.NET
NuGet Config                               nugetconfig,nuget.config                  Config
NUnit Playwright Test Project              nunit-playwright              [C#]        Test/NUnit/Playwright/Desktop/Web
NUnit Test Item                            nunit-test                    [C#],F#,VB  Test/NUnit
NUnit Test Project                         nunit                         [C#],F#,VB  Test/NUnit/Desktop/Web
Protocol Buffer File                       proto                                     Web/gRPC
Razor Class Library                        razorclasslib                 [C#]        Web/Razor/Library
Razor Component                            razorcomponent                [C#]        Web/ASP.NET
Razor Page                                 page                          [C#]        Web/ASP.NET
Razor View                                 view                          [C#]        Web/ASP.NET
Solution File                              sln,solution                              Solution
Solution Filter File                       slnf,solutionfilter                       Solution
Web Config                                 webconfig                                 Config
Windows Forms App                          winforms                      [C#],VB     Common/WinForms
Windows Forms Class Library                winformslib                   [C#],VB     Common/WinForms
Windows Forms Control Library              winformscontrollib            [C#],VB     Common/WinForms
Worker Service                             worker                        [C#],F#     Common/Worker/Web
WPF Application                            wpf                           [C#],VB     Common/WPF
WPF Class Library                          wpflib                        [C#],VB     Common/WPF
WPF Custom Control Library                 wpfcustomcontrollib           [C#],VB     Common/WPF
WPF User Control Library                   wpfusercontrollib             [C#],VB     Common/WPF
xUnit Test Project                         xunit                         [C#],F#,VB  Test/xUnit/Desktop/Web

*/




/********************************************************************
 *                            Middlewares                           *
 ********************************************************************/

// Middleware can be thought of as a pipeline that the request flows through, 
// and each middleware layer can run code before and after the next layer in the pipeline

// Middleware is implemented as a delegate that takes an HttpContext object and returns a Task

            // Task Middleware(HttpContext context)

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello World");   
});

app.Run();

// It is equivalent to writing a normal method:

async Task MyMiddleware(HttpContext context)
{
    await context.Response.WriteAsync("Hello World");
}

app.Run(MyMiddleware);


            // Terminal vs Nonterminal middleware

// The order in which you add middleware components to the pipeline is important
// Nonterminal middleware processes the request and then calls the next middleware in the pipeline
// Terminal middleware is the last middleware in the pipeline

// app.Use()

// Delegates added with app.Use() can be terminal or nonterminal middleware.
// Params: HttpContex object, RequestDelegate object
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello from middleware 1. Passing to the next middleware!\r\n");

    // Call the next middleware in the pipeline
    await next.Invoke();

    await context.Response.WriteAsync("Hello from middleware 1 again!\r\n");
});

// app.Run()
// Delegates added with app.Run() are always terminal middleware
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from middleware 2!\r\n");
});

            // Built-in middleware

// adds middleware component to catch exceptions and return error page
app.UseExceptionHandler("/Error", createScopeForErrors: true);

// adds a middleware component that sets the Strict-Transport-Security header.
app.UseHsts();

// adds a middleware component that redirects HTTP requests to HTTPS
app.UseHttpsRedirection();

// adds a middleware component that prevents cross-site request forgery (CSRF) attacks.
app.UseAntiForgery();

// This serves static files such as: CSS, JS, Images, Fonts
app.MapStaticAssets();

// adds a URL rewriter middleware component that redirects requests from /history to /about
app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

            // HttpContext

// represents the current HTTP request and response

// context.Request
string path = context.Request.Path;
string method = context.Request.Method;

// context.Response
context.Response.StatusCode = 200;

// write into the HTTP response body
await context.Response.WriteAsync("Hello");

// Authentication information
context.User;

// Request services
context.RequestServices;

// Items shared between middleware
context.Items;





/********************************************************************
 *                       Dependency injection                       *
 ********************************************************************/

// The dependency injection pattern is a form of Inversion of Control (IoC)
// This pattern decouples the code from the dependency, which makes code easier to test and maintain.


var builder = WebApplication.CreateBuilder(args);
    
// creates a new instance of the PersonService class when the app starts,
// provide that instance to any component that needs it
builder.Services.AddSingleton<PersonService>();
var app = builder.Build();

// PersonService implicitly provided by the service container
app.MapGet("/", (PersonService personService) => 
    {
        return $"Hello, {personService.GetPersonName()}!";
    }
);
    
app.Run();


// you can configure a service for a specific interface and then depend just on the interface
builder.Services.AddSingleton<IPersonService, PersonService>();

app.MapGet("/",  (IPersonService personService) => ...);


            // Service lifetimes

// Singleton lifetime
// Service created once when the app starts and are reused for the lifetime of the app
builder.Services.AddSingleton<>();

// Scoped lifetime
// Service created once per configured scope (once per request)
builder.Services.AddScoped<>();

// Transient lifetime
// Service created each time it is requested
builder.Services.AddTransient<>();





/********************************************************************
 *                    .Net Entity Framework (EF)                    *
 ********************************************************************/


//use the dotnet utility from the command line.

/*
To Add the EF package in VS Code 
*/
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

/*
To Add the EF package tools in VS Code 
*/
dotnet add package Microsoft.EntityFrameworkCore.Tools

/*
To restore packages in VS Code 
*/
dotnet restore

/*
Instal EF CLI Tool globally in the project
*/

dotnet tool install --global dotnet-ef

/* 
    Entity Framework (EF) Core Migrations
*/

    //  migrations command generates code to create the initial database schema (might need to have running the project first)
    //   The InitialCreate argument is used to name the migrations
        dotnet ef migrations add InitialCreate


    //  To undo this action, use:
        dotnet ef migrations remove

    //  The update command runs the Up method in migrations that have not been applied
        dotnet ef database update

    // Add a migration to add a new Schema field ('rating' is arbitrary and is used to name the migration file)
        dotnet ef migrations add rating
        dotnet ef database update

    // Drop the Database (all the data will be gone, do a backup before)
    dotnet ef database drop





/********************************************************************
 *                .NET Project File Structures                       *
 ********************************************************************/

            // ASP.NET Core Web API

/*

MyApp.Api/
├── MyApp.Api.csproj
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── Properties/
│   └── launchSettings.json
├── Controllers/
│   ├── ProductsController.cs
│   └── OrdersController.cs
├── Endpoints/                  # if using minimal APIs instead of/alongside controllers
│   └── ProductEndpoints.cs
├── Models/
│   ├── Entities/
│   │   └── Product.cs
│   └── Dtos/
│       ├── ProductRequest.cs
│       └── ProductResponse.cs
├── Services/
│   ├── IProductService.cs
│   └── ProductService.cs
├── Data/
│   ├── AppDbContext.cs
│   └── Migrations/
│       └── 20260101_InitialCreate.cs
├── Repositories/
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Filters/
│   └── ValidateModelFilter.cs
├── Validators/
│   └── ProductRequestValidator.cs
├── bin/
└── obj/

*/

            // ASP.NET Core MVC

/*

MyApp.Mvc/
├── MyApp.Mvc.csproj
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── Properties/
│   └── launchSettings.json
├── Controllers/
│   ├── HomeController.cs
│   └── ProductsController.cs
├── Models/
│   ├── Product.cs
│   └── ErrorViewModel.cs
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── Products/
│   │   ├── Index.cshtml
│   │   ├── Details.cshtml
│   │   └── Edit.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   ├── lib/                    # third-party static assets (bootstrap, jquery, etc.)
│   └── images/
├── Services/
├── Data/
├── bin/
└── obj/

*/

            // Multi-Project (Clean / Onion Architecture) Pattern

/*

MyApp.sln
├── MyApp.Api/                  # presentation layer
│   ├── MyApp.Api.csproj
│   ├── Program.cs
│   ├── appsettings.json
│   ├── Controllers/
│   └── Middleware/
├── MyApp.Core/                 # a.k.a. MyApp.Domain
│   ├── MyApp.Core.csproj
│   ├── Entities/
│   │   └── Product.cs
│   ├── Interfaces/
│   │   ├── IProductRepository.cs
│   │   └── IProductService.cs
│   └── Exceptions/
├── MyApp.Application/          # optional separate layer for use-cases/CQRS
│   ├── MyApp.Application.csproj
│   ├── Services/
│   ├── Dtos/
│   └── Validators/
├── MyApp.Infrastructure/       # EF Core, external services, implementations
│   ├── MyApp.Infrastructure.csproj
│   ├── Data/
│   │   ├── AppDbContext.cs
│   │   └── Migrations/
│   ├── Repositories/
│   │   └── ProductRepository.cs
│   └── ExternalServices/
│       └── EmailSender.cs
└── MyApp.Tests/
    ├── MyApp.Tests.csproj
    ├── UnitTests/
    │   └── ProductServiceTests.cs
    └── IntegrationTests/
        └── ProductsControllerTests.cs

*/

            // Console Application

/*

MyApp.Console/
├── MyApp.Console.csproj        # <OutputType>Exe</OutputType>
├── Program.cs                  # top-level statements (no Main wrapper needed)
├── appsettings.json             # optional, if using Generic Host / config binding
├── Services/
│   ├── IDataProcessor.cs
│   └── DataProcessor.cs
├── Models/
│   └── RecordItem.cs
├── Commands/                    # if using a CLI framework (System.CommandLine, Spectre.Console)
│   ├── ImportCommand.cs
│   └── ExportCommand.cs
├── Workers/                     # if built as a worker/background service
│   └── ProcessingWorker.cs
├── bin/
└── obj/

*/








/********************************************************************
 *                           EF DbContexts                            *
 ********************************************************************/
        // DbContext has a Scoped service lifetime because:
        // 1. It ensures that a new instance of DbContext is created per request
        // 2. DB connections are a limited and expensive resource
        // 3. DbContext is not thread-safe. Scoped avoids to concurrency issues
        // 4. Makes it easier to manage transactions and ensure data consistency
        // 5. Reusing a DbContext instance can lead to increased memory usage


            // key patterns to internalize

    // SaveChangesAsync()

// Persists all pending tracked changes (Add, Modify, Delete) to the database in a single transaction.
// The two-step rule for CUD operations: 
//      1 . call the EF method to stage the change
//      2 . flush it to the database in a transaction

await dbContext.SaveChangesAsync();

// Check affected rows when needed
int rows = await dbContext.SaveChangesAsync();

    // BeginTransactionAsync()

// use for explicit transactions spanning multiple SaveChanges calls
dbContext.Database.BeginTransactionAsync();

    // AsNoTracking()

// use for GET operations. EF skips the overhead of watching the entity for changes
await dbContext.Products.AsNoTracking();

    // ExecuteUpdateAsync()

// EF Core 7+: updates rows directly in the database without loading entities into memory.
// UPDATE ... WHERE like semantics of  SQL
await dbContext.Products.ExecuteUpdateAsync(s => s.SetProperty(p => p.Price, dto.Price));

    // ExecuteDeleteAsync()

// EF Core 7+: deletes rows directly without loading entities first.
// DELETE ... WHERE like semantics of SQL   
await dbContext.Products.ExecuteDeleteAsync();

    // AnyAsync()

// Asynchronously determines whether a sequence has any element
await db.Todos.AnyAsync();
// !await db.Todos.AnyAsync(); // Check for no element


            // GET

// Fetch a collection or a single entity. These are LINQ extension methods executed against a DbSet.

    // ToListAsync()

// GET /api/products — fetch all
var products = await dbContext.Products
    .AsNoTracking() //Use AsNoTracking for read-only queries 
    .ToListAsync();


    // FindAsync()

// Look up an entity by its primary key. Checks the change tracker cache first, then the database.
// Prefer FindAsync() for by-PK lookups in write operations
// GET /api/products/{id}
var product = await dbContext.Products.FindAsync(id);
if(product == null) return NotFound();

    // FirstOrDefaultAsync()

// Use when filtering by non-PK columns
// GET /api/products/{name} - fetch one
var product = await dbContext.Products
    .AsNoTracking()
    .FirstOrDefaultAsync(p => p.Name == name);


            // POST

// Marks a new entity as Added. Changes are persisted when SaveChangesAsync() is called

    // AddAsync() / Add()

//AddAsync() is only preferable over Add() when using custom value generators that require async I/O. In most cases, Add() is fine.

// POST /api/products
var product = new Product { Name = dto.Name, Price = dto.Price };
dbContext.Products.Add(product); 
await dbContext.SaveChangesAsync();
/* return CreatedAtAction(nameof(GetById), new { id = product.Id }, product); */

    // AddRangeAsync()

// Adds multiple entities in one call — useful for bulk insert endpoints.

// POST /api/products/bulk
var products = dto.Items.Select(d => new Product { Name = d.Name });
await dbContext.Products.AddRangeAsync(products);
await dbContext.SaveChangesAsync();


            // PUT

// Marks an entity (or all its properties) as Modified. Used for full-resource replacement.

    // Update()

// If the entity was fetched via FindAsync() or FirstOrDefaultAsync() (tracked), just mutate its properties — EF detects the change automatically. 
// Call Update() only for disconnected/detached entities.

// PUT /api/products/{id}
var product = await dbContext.Products.FindAsync(id);
if (product == null) return NotFound();

product.Name = dto.Name;
product.Price = dto.Price;
//// No need to call Update() — tracked entity is auto-detected
await dbContext.SaveChangesAsync();

    // ExecuteUpdateAsync()

// EF Core 7+: updates rows directly in the database without loading entities into memory.
// Bypass change tracking entirely — great for high-throughput or bulk update scenarios.
await dbContext.Products
    .Where(p => p.Id == id)
    .ExecuteUpdateAsync(s => 
        s.SetProperty(p => p.Price, dto.Price));


            // DELETE

// Marks a tracked entity as Deleted. The DELETE SQL runs on SaveChangesAsync()

    // Remove()

// DELETE /api/products/{id}
var product = await dbContext.Products.FindAsync(id);
if(product == null) return NotFound();

dbContext.Products.Remove(product);
await dbContext.SaveChangesAsync();
/* return NoContent(); */

    // ExecuteDeleteAsync()

// EF Core 7+: deletes rows directly without loading entities first.
var deleted = await dbContext.Products
    .Where(p => p.Id == id)
    .ExecuteDeleteAsync();

if(deleted == 0) return NotFound();
/* return NoContent(); */




/********************************************************************
 *                       ASP.NET Core Web API                        *
 ********************************************************************/




// Create a Web API project
// dotnet new webapi --use-controllers -o TodoApi

// Need to go to the new directory project
// cd TodoApi

// Add a NuGet package for InMemory DB
// dotnet add package Microsoft.EntityFrameworkCore.InMemory

// Add a NuGet package for SQL Server
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// Add a NuGet package for MySQL
// dotnet add package Microsoft.EntityFrameworkCore.MySql

// Add a NuGet package for SQLite
// dotnet add package Microsoft.EntityFrameworkCore.Sqlite

// Add a NuGet package for PostgreSQL
// dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

// Trust the HTTPS development certificate
// dotnet dev-certs https --trust

// Run the following command to start the app on the https profile
// dotnet run --launch-profile https

// Install Swagger with Swashbuckle
// dotnet add package Swashbuckle.AspNetCore

// Install Swagger with NSwag
// dotnet add package NSwag.AspNetCore

// Scaffold a controller
/*
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
*/

// Install the scaffolding engine
/*
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator
*/

            // Program.cs

// The entire application startup is contained in Program.cs

                //ASP.NET Core startup code

/*
+-------------------+-------------------------------------------+
| Action            | Description                               |
+-------------------+-------------------------------------------+
| Add               | Registers services (Dependency Injection) | 
| Use               | middleware  in HTTP request pipeline      | 
| Map               | create endpoints/routes                   | 
+-------------------+-------------------------------------------+
*/ 


        // 1. Create the Builder

// This creates the application host and initializes: Configuration, Logging, DI Container, Web server
var builder = WebApplication.CreateBuilder(args);

        // 2. Register Services

// Add Controllers
builder.Services.AddControllers();

// Register the database context within DI container.
builder.Services.AddDbContext<YourApiContext>();

// Register an InMemory EF DB
builder.Services.AddDbContext<YourApiContext>(opt => opt.UseInMemoryDatabase("TodoList"));

// Register an SQL Server EF DB
var sqlConnString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<YourApiContext>(opt => opt.UseSqlServer(sqlConnString));

// Register an MySQL EF DB
var mySqlConnString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<YourApiContext>(opt =>
    opt.UseMySql(
        mySqlConnString,
        ServerVersion.AutoDetect(mySqlConnString)
    ));

// Register an SQLite EF DB
builder.Services.AddDbContext<YourApiContext>(opt => opt.UseSqlite("Data Source=yourapi.db"));

// Register a PostgreSQL EF DB
var postgreConnection = builder.Configuration.GetConnectionString("PostgreConnection");
builder.Services.AddDbContext<YourApiContext>(opt => opt.UseNpgsql(postgreConnection));

// Add OpenAPI Support - Newer .NET Web API Template
builder.Services.AddOpenApi();

// Register OpenAPI endpoint discovery
builder.Services.AddEndpointsApiExplorer();

// Generate Swagger/OpenAPI documents
builder.Services.AddSwaggerGen();

// Dependency Injection (DI)
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddTransient<IEmailService, EmailService>();

        // 3. Build the Application => This creates the actual WebApplication

var app = builder.Build();
// At this point: DI container is built, Services are ready, Configuration is loaded

        // 4. Configure the Request Pipeline

// generates the OpenAPI document, but does not include Swagger UI
app.MapOpenApi(); // Newer .NET Web API Template

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enables routing to map requests to endpoints.
app.UseRouting();

// It verifies the user's identity. (JWT, Identity, OAuth...)
// Does not decide access
app.UseAuthentication();

// Authorization Middleware, checks if you are allowed to access this resource
app.UseAuthorization();

// Map Controllers - Find all controllers and create routes for them
app.MapControllers();

// Enable Swagger middleware (usually only for Development env)
app.UseSwagger();

// Enable Swagger UI (usually only for Development env)
app.UseSwaggerUI();

//Configure Swagger middleware - using NSwag.AspNetCore
app.UseSwaggerUi(options =>
{
    options.DocumentPath = "/openapi/v1.json";
});

// This serves static files such as: CSS, JS, Images, Fonts
app.MapStaticAssets();


        // 5. Run the Application

//Starts the web server and begins listening for requests.
app.Run();

            // DbContext
    
// The database context is the main class that coordinates Entity Framework functionality for a data model
public class YourApiContext : DbContext
{
    public YourApiContext(DbContextOptions<YourApiContext> options) : base(options)
    {}

    public DbSet<YourModel> YourModels { get; set; } = null!;

}

            // Api Controllerss

[ApiController]  // Enables automatic model validation, binding inference
[Route("api/[controller]")]  // Defines URL template
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
        => _service = service;

    [HttpGet]                          // GET api/products
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]                  // GET api/products/5
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]                         // POST api/products
    public async Task<IActionResult> Create([FromBody] ProductDto dto) // Binds from request body (JSON)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]                  // PUT api/products/5
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
    {
        if (!await _service.UpdateAsync(id, dto)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]               // DELETE api/products/5
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _service.DeleteAsync(id)) return NotFound();
        return NoContent();
    }
}





/********************************************************************
 *                    ASP.NET Core Minimal API                      *
 ********************************************************************/
// Recommended approach for building fast HTTP APIs
// Fully functioning REST endpoints with minimal code and configuration - Less boilerplate code
// Easier testing - Simplified unit and integration testing
// Fluently declare API routes and actions


//Here's a simple example that creates an API at the root of the web app:
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World");

app.Run();

// Most APIs accept parameters as part of the route
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Seed in-memory database with initial Todo items
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoDb>();

    // Ensure database is created (for InMemory provider this is a no-op but safe)
    await db.Database.EnsureCreatedAsync();

    //Todos here is the DB entity for Todo
    if (!await db.Todos.AnyAsync())
    {
        db.Todos.AddRange(
            new Todo { Name = "Buy groceries", IsComplete = false, Secret = "seed-1" },
            new Todo { Name = "Call Alice", IsComplete = true, Secret = "seed-2" },
            new Todo { Name = "Walk the dog", IsComplete = false, Secret = "seed-3" }
        );
        await db.SaveChangesAsync();
    }
}

app.MapGet("/users/{userId}/books/{bookId}",
    (int userId, int bookId) => $"userId: {userId}. bookId: {bookId}");

app.Run();

// Creates a RouteGroupBuilder for defining endpoints all prefixed with the specified
var group = app.MapGroup("/api");

group.MapGet("/", async (IProductService svc) => await svc.GetAllAsync());

group.MapGet("/{id}", async (int id, IProductService svc) => 
{   
    var product = await _service.GetByIdAsync(id);
    ProductDto productDto = MapProduct(product);
    return game is null ? Results.NotFound() : Results.Ok(productDto);
});

group.MapPost("/", async (ProductDto dto, IProductService svc) => {
    var created = await svc.CreateAsync(dto);
    ProductDto productDto = MapProduct(created);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = productDto.Id }, productDto);
});

group.MapPut("/{id}", async (
    int id,
    ProductDto dto,
    IProductService svc) =>
{
    if (!await svc.UpdateAsync(id, dto)) 
        return Results.NotFound();
    
    return NoContent();
});

group.MapDelete("/{id}", async (int id, IProductService svc) =>
{
    if (!await svc.DeleteAsync(id)) 
        return Results.NotFound();
    
    return Results.NoContent();
});

// Route handler methods instead of using lambdas

group.MapGet("/", GetAll);

static async Task<IResult> GetAll(TodoDb dbContext)
{
    return Results.Ok(await dbContext.Todos
        .Select(t => new TodoItemDto(t))
        .AsNoTracking()
        .ToListAsync());
}

group.MapGet("/{id}", GetById);

static async Task<IResult> GetById(int id, TodoDb dbContext)
{
    var item = await dbContext.Todos.FindAsync(id);
    if (item is null)
        return Results.NotFound();
    else
        return Results.Ok(new TodoItemDto(item));
}


            // Model Validation

// can also be a Record class
public class ProductDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Range(0.01, 10000)]
    public decimal Price { get; set; }
}
// [ApiController] auto-returns 400 if validation fails