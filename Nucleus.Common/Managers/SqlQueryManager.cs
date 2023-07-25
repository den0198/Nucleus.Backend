namespace Nucleus.Common.Managers;

public static class SqlQueryManager
{
    public static string GetProductInCatalogs { get; private set; } = null!;
    
    public static async Task Init()
    {
        GetProductInCatalogs = await getQueryFromFile("GetProductInCatalogs.sql");
    }

    private static async Task<string> getQueryFromFile(string nameFile)
    {
        return await FileManager.GetTextFromFile("SqlQueries", nameFile);
    } 
}