#Azure-Bootcamp
Azure Boot-camp  Exercises 

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

