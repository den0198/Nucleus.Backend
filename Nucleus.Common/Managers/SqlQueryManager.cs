using System.Reflection;

namespace Nucleus.Common.Managers;

public static class SqlQueryManager
{
    private static readonly string sqlQueriesDirectory = Path
        .Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "SqlQueries");
    
    public static string GetProductInCatalogs { get; }

    static SqlQueryManager()
    {
        GetProductInCatalogs = getQueryFromFile("GetProductInCatalogs.sql");
    }

    private static string getQueryFromFile(string nameFile)
    {
        var path = Path.Combine(sqlQueriesDirectory, nameFile);
        
        return File.ReadAllText(path);
    } 
}