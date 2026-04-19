using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MatchStatCharts.Model;

namespace MatchStatCharts.Services;
public sealed class MatchTrackerService : IMatchTrackerService
{
    private readonly JsonSerializerOptions _options;

    public MatchTrackerService()
    {
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        // Global converter (in addition to attribute usage)
        _options.Converters.Add(new FlexibleStringConverter());
    }

    public MatchDetails? Load(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Match file not found", path);

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<MatchDetails>(json, _options);
    }

    public async Task<MatchDetails?> LoadAsync(string path)
    {
        using var stream = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<MatchDetails>(stream, _options);
    }

    public void Save(string path, MatchDetails data)
    {
        var json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(path, json);
    }

    public async Task SaveAsync(string path, MatchDetails data)
    {
        using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, data, _options);
    }

}
