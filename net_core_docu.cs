/********************************************************************
 *                       .Net Core Fundamentals                      *
 ********************************************************************/

/* 
To compile a .NET Core project enter at a command prompt the command: 
*/

  dotnet build

/*
To compile and execute a .NET Core project enter at a command prompt the command: 
*/

  dotnet run

/********************************************************************
 *                        .Net Entity Framework                      *
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