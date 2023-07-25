using System.Reflection;

namespace Nucleus.Common.Managers;

public static class FileManager
{
    public static async Task<string> GetTextFromFile(params string[] paths)
    {
        var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var path = Path.Combine(currentDirectory, paths[0]);

        for (var i = 1; i < paths.Length; i++)
        {
            path = Path.Combine(path, paths[i]);
        }
        
        return await File.ReadAllTextAsync(path);
    }
}