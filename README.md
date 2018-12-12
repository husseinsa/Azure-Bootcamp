# Azure Bootcamp
Azure Boot-camp exercises. Below are simple excerises for attendees to try out during the bootcamp to get better understanding of the services explained. 

## Azure Web Apps
1.	Create an Azure Web App 
     - Create a new service plan
          - Choose the Free tier
2.   Create a new web application using visual studio
     - ASP.NET Core Web Application
     - Web Application (Model-View-Controller)
3.   Publish the  web application to the newly created Azure Web app
     - In Azure portal, go to your Web app and navigate to the overview blade
     - Download the publish profile (Get Publish Profile)
     - In Visual Studio, publish your application by importing the downloaded publish profile
     
4.   Create a new deployment slot
     - Scale up your service plan (select a service plan that provides deployment slots feature)
     - Add new slot `Staging` to your Azure web app 
     - In visual studio, go to your web.config and add a new key to your application settings section
     - In Azure Portal,  Add the same key to the two deployment slots (Production and Staging). 
         -  Settings -> Application Settings -> Add new setting (check the Slot Setting)
5.   Change your application code to display the message in your home page
     - Add the code to read the app setting in the HomeController
      
 
      private readonly IConfiguration config;
        public HomeController(IConfiguration configuration)
        {
            this.config = configuration;
        }
        public IActionResult Index()
        {
            var msg = config["MyMessage"];
            return View("Index", msg);
        }

     - Add the code to display your app setting key in `Index.cshtml`  (Views-> Home -> Index.cshtml)
    
       ```
         @model string
         @{
             ViewData["Title"] = "Home Page";
          }
         <h1> @Model </h1>
       ```  
6.  Swap deployment slots
     - Using visual studio, Deploy the application (modified version) to the staging deployment slot
     - Browse the staging web site to see your `MyMessage` value show up in your index page
     - Swap the slots (Staging <-> Production)
          - Browse your production site to see how it affects the site (it will reads you app setting key)
          - Browse to your staging site, see the old code version after swap happened
    
    
    
## Cosmo DB
1.   Create a Cosmo DB Account, Database, Collection
     - Choose the SQL API (JSON documents)
     - Create a document database collection
          - Database: Tasks
          - Collection: Items
2.  Complete the code to insert and retrieve document from Cosmos DB collection
     - Open Web application “CosmoDBApp” (find it in the repo)
     - Install the NuGet package:  Microsoft.Azure.DocumentDB.Core
     - Add required parameters (URI, Key) to initiate a connection to your collection
     - Modify the two methods in the “ItemsStore” class
          - Insert sample items in Cosmo DB  (Items)
          - Retrieve items from Cosmo DB
    
    
## Azure Blob Exercise
1.	Create a new storage account
     - Account Kind: Blob Storage
     - Performance: Standard
     - Replication: LRS
     - Access Tier: Hot
     - Encryption: Disabled
     
2.	Access Azure Blob Storage from SDK using Visual Studio
     - Navigate to Blobstorage folder and open the solution
     - Add the necessary package for the Azure Storage SDK
     - Modify the Upload Method in HomeController, so you can upload documents
     - Don’t forget to use the Keys in your storage account to authenticate you request when connecting to the Account.
     - Test and check if the documents were added as per requirements (in the comments)

## Azure Functions 
1.	Create a Function Application in your Azure account
    - Create a new function 
    - Use Azure Portal, follow the [steps](https://docs.microsoft.com/en-us/azure/azure-functions/functions-integrate-storage-queue-output-binding?tabs=csharp) in this article to add messages to an Azure Storage Queue.
    
2.  Use visual studio to create HTTP trigger and save the input data in Azure Table storage using output bindings.
    The Azure HTTP trigger will receive data from multiple sources and stores the customer profile data in a storage table named  *Customers*
    - Create a new Azure Storage Account (if doesn't exist), Create a new table *Customers*
    - Navigate to the FuncHttpToQueue folder to open the project or go through the next three steps to create the application from scratch
    - Open Visual Studio and Create an Azure Function (New Project -> Azure Functions)
    - When prompted, select the following
      - Azure Function : Http tigger
      - Storage Account: Storage Emulator
      - Access Rights: Anonymous
    - Add the *CustomerEntity* class (this represents the  entity that you will be adding to your storage table)
    
        ```
        public class CustomerEntity : TableEntity
        {
              public string Name { get; set; }
              public string City { get; set; }

              public CustomerEntity()
              {
              }

              public CustomerEntity(string name, string city)
              {
                  this.RowKey = System.Guid.NewGuid().ToString();
                  this.PartitionKey = city;
                  this.Name = name;
                  this.City = city;
              }
        }

        ```
    - Continue the rest of code to accept the customer data from the HTTP Trigger and insert it in the Azure Table.
      - Note: You need specify the table name and the connection string to your storage account. Decorate your function with additional attributes to allow inserting data to your table
      
    - Debug and test locally using visual studio
    - Call your function using Postman or any broswer and pass the required parameters
    - Use *Azure Storage Explorer* to test if the customer data was inserted to the table

