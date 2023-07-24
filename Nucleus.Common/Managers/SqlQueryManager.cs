using System.Reflection;

namespace Nucleus.Common.Managers;

public static class SqlQueryManager
{
    private static readonly string sqlQueriesDirectory = Path
        .Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "SqlQueries");

    public static string GetProductInCatalogs { get; private set; } = null!;
    
    public static async Task Init()
    {
        GetProductInCatalogs = await getQueryFromFile("GetProductInCatalogs.sql");
    }

    private static async Task<string> getQueryFromFile(string nameFile)
    {
        var path = Path.Combine(sqlQueriesDirectory, nameFile);
        
        return await File.ReadAllTextAsync(path);
    } 
}