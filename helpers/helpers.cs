// these are not used in the Console App in Program.cs, but are included in the training
// https://learn.microsoft.com/en-us/training/modules/work-azure-blob-storage/6-set-retrieve-properties-metadata-rest


///
/// Read Container Properties
/// 
private static async Task ReadContainerPropertiesAsync(BlobContainerClient container)
{
    try
    {
        // Fetch some container properties and write out their values.
        var properties = await container.GetPropertiesAsync();
        Console.WriteLine($"Properties for container {container.Uri}");
        Console.WriteLine($"Public access level: {properties.Value.PublicAccess}");
        Console.WriteLine($"Last modified time in UTC: {properties.Value.LastModified}");
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}

///
/// Add Container Metadata
/// 
/// The name of your metadata must conform to the naming conventions for C# identifiers. 
/// Metadata names preserve the case with which they were created, but are case-insensitive when set or read. 
/// If two or more metadata headers with the same name are submitted for a resource, 
/// Blob storage comma-separates and concatenates the two values and returns HTTP response code 200 (OK).
/// 
/// The following code example sets metadata on a container.
/// 
public static async Task AddContainerMetadataAsync(BlobContainerClient container)
{
    try
    {
        IDictionary<string, string> metadata =
           new Dictionary<string, string>();

        // Add some metadata to the container.
        metadata.Add("docType", "textDocuments");
        metadata.Add("category", "guidance");

        // Set the container's metadata.
        await container.SetMetadataAsync(metadata);
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}

///
/// The GetProperties and GetPropertiesAsync methods are used to retrieve metadata in addition to properties as shown earlier.
/// 
/// The following code example retrieves metadata from a container.
/// 
public static async Task ReadContainerMetadataAsync(BlobContainerClient container)
{
    try
    {
        var properties = await container.GetPropertiesAsync();

        // Enumerate the container's metadata.
        Console.WriteLine("Container metadata:");
        foreach (var metadataItem in properties.Value.Metadata)
        {
            Console.WriteLine($"\tKey: {metadataItem.Key}");
            Console.WriteLine($"\tValue: {metadataItem.Value}");
        }
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}