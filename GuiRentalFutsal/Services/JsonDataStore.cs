using System.Text.Json;
using System.Text.Json.Serialization;

namespace GuiRentalFutsal.Services;

public class JsonDataStore<T> where T : class
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    public JsonDataStore(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path tidak boleh kosong.", nameof(filePath));
        }

        _filePath = filePath;
        string? directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        _options.Converters.Add(new TimeOnlyConverter());
        _options.Converters.Add(new JsonStringEnumConverter()); // optional: keep enums human-readable
    }

    public virtual List<T> Load()
    {
        if (!File.Exists(_filePath))
        {
            return new List<T>();
        }

        string json = File.ReadAllText(_filePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<T>();
        }

        return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
    }

    public virtual void Save(List<T> data)
    {
        ArgumentNullException.ThrowIfNull(data);
        string json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(_filePath, json);
    }
}