# ShippingApi

 This is the documentation for AE Backend Code Challenge, written by Developer Team of WerqLAbs.

### Introduction
The aim of the project is to find the nearest port from a ship based on the geological locations and calculate the estimated time of arrival of the ship provided by the velocity of the ship.

### Features
- We have used the latest version of .NET Core 6 as it comes with new features, performance improvements, and bug fixes.
- We have used repository pattern to make loosely coupled architecture.
- We have added dependency Injection to make the code more testable, maintainable, and scalable. .NET Core 6 has built-in DI support.
- We have implemented security measures such as authentication in your web API to protect it from malicious attacks. 
- We have used HTTP verbs such as GET, POST, PUT for the corresponding actions. This will make your API more intuitive and easier to use.
- We have used the HTTP response codes such as 200 OK, 201 Created, 400 Bad Request, 401 Unauthorized, etc., for the corresponding situations. This will help the API   consumers to understand what happened with their request.
- We have used  API versioning to manage changes to your web API over time. This will help the API consumers to upgrade their application smoothly.
- We have used automated testing to ensure the quality of your web API. Used testing frameworks like xUnit to write unit tests and integration tests.

### Technologies
- Visual Studio 2022
- dot Net Core 6.0
- MS SQL 18.0
- Nugget Packages Third Party -> XUnit 2.4.1, Moq 4.18.4, Swagger 6.2.3, Microsoft.Data.SqlClient (5.1.0)

### Installations
- First Install Microsoft SQL 2018
- Install visual studio 2022

### Setup For Database
- Go to Source code ShippingApiApp
- Click on Database folder
- Select ShippingDBProject
- Find the scripts for sql tables and stored procedures
- Run the table script on your sql server followed by stored procedures. 

###### Note: For this project we have already created sql sever on azure and have added connectionstring in appsetting.json for the same.

### Setup For Dot net
- Open the given solution file ShippingApiApp.sln in visual studio 2022
- Build and run the application
- You will get this url "https://localhost:7297/swagger/index.html"
- Copy the  APIKey from the email which we have sent. 
- Click Authorize button and Paste the APIKey inside value textbox 
- Click Tryout to test the individual api.



