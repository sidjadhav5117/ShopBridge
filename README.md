# ShopBridge

This application contains the CRUD operation using ASP.NET Core Blazor, ASP.NET CORE Web API and Entity Framework.

**Technologies**
* ASP.NET Core Web API
* Entity Framework
* ASP.NET Core Blazor
* XUnit Testing Framework

**Functionality**
* It basically includes the CRUD Operation of the Product.
* It has the xunit test cases as well for the web api controllers.
* Use of Web API.
* Global exception handling.

**How to run the project**
* Download the proeject in your local and do the setup.
* Make the ShopBridgeApi project as your startup project.
* Go to appsetting.json file in ShopBridgeApi project and replace the connection string with your string. Than go to Package Manager Console and run the Migration with the following command.
  * _update-database_
* Copy your localhost address of the ShopBridgeApi project and paste in the the ShopBridgeWeb->Program.cs 
  * `builder.Services.AddHttpClient<IProductService, ProductService>(client=> client.BaseAddress = new Uri("Your localhost address of the ShopBridgeApi project.));`
