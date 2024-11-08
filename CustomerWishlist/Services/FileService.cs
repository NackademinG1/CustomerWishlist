using CustomerWishlist.Interfaces;

namespace CustomerWishlist.Services;

public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;
    public string GetFromFile(string filePath)
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                var content = sr.ReadToEnd();
                return content;
            }
        }
        catch {}
        return null!;
    }

    public bool SaveToFile(string filePath, string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);

                return true;
            };
        }
        catch 
        {
            return false;
        }
    }
}
