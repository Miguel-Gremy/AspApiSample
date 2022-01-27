AspApiSample
============

## WHAT IS THIS ?
**AspApiSample** is a project from where you can start, to create a much more complex application, which include login part.

This solution is composed of tree projects, a Library, an API and a WEB site (using the API obviously).

I used C# with .NET 5 and ASP.NET because i'd like to improve my knowledge into this technologie. Another reason is that I don't like dealing with PHP or JavaScript, and I used C# before, for example when I cerated an application (for windows) with WPF.

I'd like to update the project to use .NET 6, but for now I concentrate myself to finish this sample application, and after that update it to the .NET 6.

## HOW TO INSTALL
To install (or maybe just run the solution ?), you have to install .NET 5 on your computer. No other dependancies are required to make this project work (except an internet connection to download solution's Nuget packages).

## HOW TO USE THE SOLUTION
### WHAT ARE THESE ?
- Library
    - This project is where we add our models, where we have our DbContxt (IdentityDbContext in this case) and where we have our migrations (for the database changes).
    - This project does not have references other than required for the ORM (EntityFrmaework), and Microsoft Identity Manager to work.
- API
    - This project references the Library project, because that's the only one wich know about the models we created. This is the only project in the complete solution which can access the database, and all other project have to deal with its client (generated with SwaggerCodegen).
- WEB
    - This project references the generated API's client. The client offer the possibility to deal with the API, without dealing with headers, endpoint Url, etc...

### I UNDERSTOOD, BUT NOW, HOW CAN I USE THE SOLUTION !?
Ok ok ok, calm down, to use the solution ? Build the SwaggerCodegen libraries (in the SwaggerCodegen/Lib folder, with build.sh or build.bat depending on your OS). After that, you just have to run first the API, and secondly run the WEB client.

/!\ : **PLEASE** do not use the IIS start configuration, it has not been configured yet. Instead, use the other solution.<br>
/!\ : Obviously, you have to configure something.
- API project
    - Database
        - DbProvider : 
            You have the choice, for now the API project support tree database providers :
            - SQLServer
                - To use SQLServer, enter 'mssql' in the 'DbProvider' value section
            - SqLite3
                - To use SqLite3, enter 'sqlite3' in the 'DbProvider' value section
            - Postgresql
                - To use Postgresql, enter 'psql' in the 'DbProvider' value section
        - DbConnection :
            Here is where you can type your connection string. You can find connection string easily on internet.
    - Email
        - EmailParameters
            - From
                - This is the address from where you'll send emails. (ex : email@example.com).
            - Password
                - This is the password associated with the email.
            - Host
                - The host is the url of your smtp server (ex for gmail : smtp.gmail.com).
            - Port
                - This is the port provided by your smtp server to access its services.
- WEB project
    - API
        - ApiParameters
            - Path
                - The path configuration define the base path of your API ; By default, for a local usage, the address is localhost:5001. In production, you'll maybe have to set it to a domain name or an IP address, don't forget to specify the port of your API otherwise that's not gonna work at all. 
            - UseHttps
                - This configuration specify if the WEB application must check the SSL configuration of the API or not. Set it to false (by default), and the WEB aplication doesn't care about the SSL configuration of the API.

## I SAW SOME SCRIPTS, DO YOU WANT TO HACK ME ?
Obviously, **yes** ;)

The script folder is here if you want to modify the solution, upgrade it, use it, or something else that I don't imagine. 

I let you see the [README.md](Scripts/README.md) of the Script folder to see what are these.

