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

/*
To add a new Nuget package enter at a command prompt the command: 
*/

  dotnet add package [packageName]





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
 *                  .Net Console application                        *
 ********************************************************************/


//use the dotnet utility from the command line.

    //To create a new .NET Core project enter at a command prompt the command (optionally add project name i.e. "WebAPIClient"): 

dotnet new console --name WebAPIClient
dotnet new console -n WebAPIClient

//To open the console project in Visual Studio
cd WebAPIClient // Navigate into the new project directory
WebAPIClient.csproj     // type the name of the project followed by .csproj


//To compile a .NET Core project enter at a command prompt the command: 
//  dotnet build


//To compile and execute a .NET Core project enter at a command prompt the command: 
//  dotnet run
// 



#region Middleware


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

#endregion


#region DI

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

#endregion

#region Migrations

/********************************************************************
 *                      Entity Framework Migrations                 *
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
// Or using Package Manager Console in VS
Install-Package Microsoft.EntityFrameworkCore.Tools

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

        // using Package Manager Console 
        Add-Migration InitialCreate
        Update-Database

        // using terminal CLI
        dotnet ef migrations add InitialCreate
        dotnet ef database update


    //  To undo this action, use:
        dotnet ef migrations remove

    //  The update command runs the Up method in migrations that have not been applied
        dotnet ef database update

    // Add a migration to add a new Schema field ('rating' is arbitrary and is used to name the migration file)
        dotnet ef migrations add rating
        dotnet ef database update

    // Drop the Database (all the data will be gone, do a backup before)
    dotnet ef database drop


// InitialCreate Migration auto-generated class
public partial class InitialCreate : Migration
{
    // apply
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Authors",
            columns: table => new {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Authors", x => x.Id));
    }

    // rollback
    protected override void Down(MigrationBuilder migrationBuilder)
        => migrationBuilder.DropTable("Authors");
}

#endregion

#region Project Struct

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


#endregion



#region EF DbContext

/*****************************************************************************
 *                    Entity Framework DbContexts                            *
 *****************************************************************************/
        // DbContext has a Scoped service lifetime because:
        // 1. It ensures that a new instance of DbContext is created per request
        // 2. DB connections are a limited and expensive resource
        // 3. DbContext is not thread-safe. Scoped avoids concurrency issues
        // 4. Makes it easier to manage transactions and ensure data consistency
        // 5. Reusing a DbContext instance can lead to increased memory usage

// Add the EF Core namespace in your DbContext class
// using Microsoft.EntityFrameworkCore;

// Register the database context within DI container.
builder.Services.AddDbContext<YourApiContext>();    

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
var readOnlyProducts = dbContext.Products.AsNoTracking().ToList();

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


        // Eager loading

// Load related data upfront with the main query
var books = context.Books
    .Include(b => b.Author)
    .ThenInclude(a => a.Publisher)
    .ToList();


        // Lazy Loading

// Load related data only when you actually access it. triggers one query per row
// N+1 query problem
var name = book.Authors.ToList();


        // EF ChangeTracker State

// Entity States: Added, Modified, Deleted, Unchanged, Detached

//to get the Entity State
var state = context.Entity(book).State;

// EF Core's change tracker
var entries = dbContext.ChangeTracker.Entries();

foreach(var entry in entries)
{
    Console.WriteLine($"{entry.Entity.GetType().Name} - {entry.State}");    
}

// detecting all Tracker changes
var changes = dbContext.ChangeTracker.DetectChanges();

// New object (Detached state)
var newBook = new Book
{
    Id = 1,
    Title = "Clean Code",
    Price = 45
};

context.Entity(newBook).State; // Detached

// Adding object - start being tracked by dbContext EF Core
context.Books.Attach(newBook);
context.Books.Add(newBook);

// Attach() vs Add()

context.Books.Add(book); // => Status Added => SaveChanges() → INSERT

context.Books.Attach(book); // Status Unchanged => Start tracking =>  SaveChanges() → No action

// Explicit EF Core Entity State change
dbContext.Entry(book).State = "Modified";


            // Explicit database transaction

// Either all the database operations inside the transaction succeed, or they are rolled back.


using var transaction = dbContext.Database.BeginTransaction();

try
{
    dbContext.Books.Add(newBook);
    dbContext.SaveChanges();
    transaction.Commit();
}
catch
{
    transaction.Rollback();
    throw;
}

            // Managing SQL Server Db - Optimistic Concurrency

public class Book
{
    [Timestamp] // concurrency token
    public byte[] RowVersion { get; set; }
}

// When there is a simultaneous change, EF Core throws DbUpdateConcurrencyException

try
{
    context.SaveChanges();
}
catch (DbUpdateConcurrencyException ex) // Resolve the conflict
{
    var entry = ex.Entries.Single(); // EF Core's tracking information (Entity, CurrentValues, OriginalValues, State)
    var client = (Book)entry.Entity;

    var databaseValues = await entry.GetDatabaseValuesAsync();

    if (databaseValues is null)
        throw new InvalidOperationException(
            "The Book was deleted by another user.");

    var dbBook = (Book)databaseValues.ToObject();

    // Merge rule: take highest price
    client.Price = Math.Max(client.Price, dbBook.Price);

    // Update original RowVersion so EF can retry
    entry.OriginalValues.SetValues(databaseValues);

    await db.SaveChangesAsync();
}

// EF Core configuring concurrency

protected override void OnModelCreating(
    ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>()
        .Property(b => b.RowVersion)
        .IsRowVersion()
        .IsConcurrencyToken();
}

public class Book
{
    public byte[] RowVersion { get; set; } // Then no need to add Data Annotation
}


            // Shadow Properties


// Properties that exist in EF model and DB table but are not defined on the C# entity class

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }
}

// LastModified  ← Shadow Property
// LastModified only exists in EF Core's tracking/model metadata
modelBuilder.Entity<Book>().Property<DateTime>("LastModified");

var book = new Book();
book.LastModified = DateTime.Now; // ❌ This won't compile

// Setting a Shadow Property
_dbContext.Entry(book).Property("LastModified").CurrentValue = DateTime.UtcNow;

// Reading a Shadow Property
var lastModified = _dbContext.Entry(book).Property<DateTime>("LastModified").CurrentValue;

// Querying a Shadow Property
var recentlyModifiedBooks = _dbContext.Books
    .Where(book => EF.Property<DateTime>(book, "LastModified") > DateTime.UtcNow.AddDays(-7))
    .ToList();


            // Global Query Filter

// It's a condition that EF Core automatically applies to every query 

// example: every EF Core Book queries automatically return only books where IsDeleted is false
modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);

var books = context.Books
    .Where(b => !b.IsDeleted) // this query is added automatically by EF
    .ToList();

// override a Global Query Filter
var allBooks = context.Books
    .IgnoreQueryFilters()
    .ToList();

// Multi-tenancy
modelBuilder.Entity<Book>().HasQueryFilter(b => b.TenantId == _currentTenantId);


            // raw SQL in EF Core

var books = context.Books
    .FromSqlRaw("SELECT * FROM Books WHERE Price > {0}", 20)
    .ToList();

context.Database.ExecuteSqlRaw("UPDATE Books SET Price = Price * 1.1");


#endregion



#region EF Models

/***************************************************************************
 *                        EF Model Configurations                           *
 ***************************************************************************/


// The database context is the main class that coordinates EF functionality for a data model
public class YourApiContext : DbContext
{   
    public DbSet<YourModel> YourModels { get; set; } = null!;

    // Option 1 - DbContext receives its configuration from outside.
    // Preferable for ASP.NET Core applications
    public YourApiContext(DbContextOptions<YourApiContext> options) : base(options)
    {}

    // Option 2 - use it when DbContext is responsible for configuring itself.
    // Then we can create the context directly: using var context = new YourApiContext();
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("connection-string-here");

    // configure your model Entities here (classes)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use inline method entityType configuration for extensive entity property config
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");
            entity.HasKey(c => c.Id);
            //...
        });

        // Use Entity Type builder chain methods to configure entity Relationships
        // One-to-one
        modelBuilder.Entity<Order>()
            .HasOne(o => o.ShippingAddress)
            .WithOne(sa => sa.Order)
            .HasForeignKey<ShippingAddress>(sa => sa.OrderId);

        // configure Entity Primary key
        entity.HasKey(x => x.Id);

        // Composite key (combination of both => primary key)
        entity.HasKey(x => new
        {
            x.OrderId,
            x.ProductId
        });

        // Required property
        entity.Property(x => x.Name)
            .IsRequired();

        // Maximum length
        entity.Property(x => x.Name)
            .HasMaxLength(100);

        // Decimal precision (100000.00)
        entity.Property(x => x.Price)
            .HasPrecision(18, 2);

        // One-to-many (start from the entity that contains the foreign key)
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        // Many-to-many
        modelBuilder.Entity<Product>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Products);

        // Index
        entity.HasIndex(x => x.Email);

        // Unique index
        entity.HasIndex(x => x.Email)
            .IsUnique();

        // Delete related entities automatically.
        modelBuilder.Entity<Product>().OnDelete(DeleteBehavior.Cascade);

        //Prevent deletion when related entities exist.
        modelBuilder.Entity<Product>().OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);

        // Data Seeding
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FirstName = "J.K.", LastName = "Rowling" },
            new Customer { Id = 2, FirstName = "Jim", LastName = "Carrey" }
        );
    }
}


            // Entity Relationships

// One-to-Many

public class Book
{
    public Author Author {get; set;}
}

public class Author
{
    public ICollection<Book> Books {get; set;}
}


// Many-to-many (no join entity needed)
public class Student
{
    public ICollection<Course> Courses { get; set; }
}

public class Course
{
    public ICollection<Student> Student { get; set; }
}


// Creating a separate Entity Type Configuration class

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.ToTable("Customers");
        entity.HasKey(c => c.Id);
        
        // ... and more configuration steps
    }
}

// Then your DbContext becomes much cleaner
public class YourApiContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); => automatically finds configuration classes in the assembly
        base.OnModelCreating(modelBuilder);
    }
}


#endregion




#region EF WebAPI 

/********************************************************************
 *                       ASP.NET Core Web API                        *
 ********************************************************************/




// Create a Web API project
// dotnet new webapi --use-controllers -o TodoApi

// Need to go to the new directory project
// cd TodoApi

// If not using scaffolding, add EF Core manually with Package Manager Console
// Install-Package Microsoft.EntityFrameworkCore

// Add a NuGet package for InMemory DB
// dotnet add package Microsoft.EntityFrameworkCore.InMemory

// Add a NuGet package for SQL Server
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// Or with Package Manager Console
// Install-Package Microsoft.EntityFrameworkCore.SqlServer

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

#endregion

#region Minimal API

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
    var product = await svc.GetByIdAsync(id);
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


#endregion

#region Architecture


/********************************************************************
 *                      Architectural Patterns                      *
 ********************************************************************/

            // Repository pattern

// An abstraction between business logic (Domain) and ORM (Object Relational Mapping)
// Principles: Decoupling, Testability, Abstraction

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetAllAsync();
    Task AddAsync(Product product);
    void Update(Product product);
    void Delete(Product product);
}

public class ProductRepository : IProductRepository
{
    private readonly ApiDbContext _context;

    //private readonly DbSet<Product> _set; // Can optionally add the EF Set

    public ProductRepository(ApiDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.AsNoTracking().FindAsync(new object[] { id });
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    // And so on...
}


            // Unit of Work pattern

// UOF handles business operations on repositories and saves all changes as a single transaction
public interface IUnitOfWork
{
    IProductRepository Products { get; }
    Task<int> SaveChangesAsync();
}

public class UnitOfWork : IUnitOfWork
{
    public readonly AppDbContext _dbContext;
    public IProductRepository Products { get; }

    public UnitOfWork(AppDbContext context, IProductRepository products)
    {
        _dbContext = context ?? throw new ArgumentNullExcpetion(nameof(context));
        Products = products;
        // Products = _dbContext.Products;
        // Products = new ProductRepository(_dbContext);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}


            // Unit of Work & Repository pattern combined

public class ProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork(_dbContext);
    }

    public async Task CheckoutAsync(int orderId)
    {
        try
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);

            // Perform validation and other operations...

            foreach(var item in orders.Items)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
                // product.Stock -= item.Quantity; // Can do some operations with the Entity
                _unitOfWork.Products.Uptade(product);
            }

            // Saves all repository changes in 1 single transaction
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
            
    }
}

#endregion