/********************************************************************
 *                  .Net Razor Web application                      *
 ********************************************************************/


//use the dotnet utility from the command line.

/*
To Create a Razor Pages project enter at a command prompt the command (optionally add project name i.e. "WebAPIClient"): 
*/

 dotnet new webapp
 dotnet new webapp -o RazorPagesMovie

/* 
To compile a .NET Core project enter at a command prompt the command: 
*/

  dotnet build


/*
To compile and execute a .NET Core project enter at a command prompt the command: 
*/

  dotnet run

/* 
    Entity Framework (EF) Core Migrations
*/

    //  migrations command generates code to create the initial database schema
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