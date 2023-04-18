using AirportExample.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AirportExample.Repositories;

public interface IFileSystemRepository
{
    public Result<T> Read<T>(string filePath);
    public Result<bool> Write(string filePath, object content);
}

public class FileSystemRepository : IFileSystemRepository
{
    private readonly ILogger<AirportsRepository> _logger;
    public FileSystemRepository(ILogger<AirportsRepository> logger)
    {
        _logger = logger;
    }

    public Result<T> Read<T>(string filePath)
    {
        Result<T> result;
        try
        {
            var stringContent = File.ReadAllText(filePath);
            var deserializedObject = JsonConvert.DeserializeObject<T>(stringContent);
            result = Result<T>.Create(deserializedObject);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            result = Result<T>.CreateWithError(e.Message);
        }
        return result;
    }

    public Result<bool> Write(string filePath, object content)
    {
        Result<bool> result;
        try
        {
            var stringContent = JsonConvert.SerializeObject(content);
            File.WriteAllText(filePath, stringContent);
            result = Result<bool>.Create(true);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            result = Result<bool>.CreateWithError(e.Message);
        }
        return result;
    }
}