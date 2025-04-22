### Info

-   AZ-204 - C# Console App that connects to an Azure Storage Container, creates a BlobServiceClient, creates a container, writes a file to it, downloads the file and then deletes the blob and container.

### Setting up

Perform the following actions to prepare Azure, and your local environment, for the exercise.

Start Visual Studio Code and open a terminal window by selecting Terminal from the top application bar, then selecting New Terminal.

Sign in to Azure by using the following command. A browser window should open letting you choose which account to sign in with.

`az login`

Create a resource group for the resources needed for this exercise. Replace <myLocation> with a region near you.

`az group create --location <myLocation> --name az204-blob-rg`

Create a storage account. Create a storage account to use in the application. Replace <myLocation> with the same region you used for the resource group. Replace <myStorageAcct> with a unique name.

`` Note: US-East is `eastus` in Azure CLI ``

`az storage account create --resource-group az204-blob-rg --name <myStorageAcct> --location <myLocation> --sku Standard_LRS`

Note

Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only. Your storage account name must be unique within Azure. No two storage accounts can have the same name.

Get credentials for the storage account.

Navigate to the Azure portal.
Locate the storage account created.
Select Access keys in the Security + networking section of the navigation pane. Here, you can view your account access keys and the complete connection string for each key.
Find the Connection string value under key1, and select the Copy button to copy the connection string. You'll add the connection string value to the code in the next section.
In the Blob section of the storage account overview, select Containers. Leave the windows open so you can view changes made to the storage as you progress through the exercise.

### Run the app

`dotnet build`
`dotnet run`
