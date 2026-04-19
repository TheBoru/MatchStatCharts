using MatchStatCharts.Model;
using System.Text.Json;

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MatchStatCharts.Model;

namespace MatchStatCharts.Services;
public  interface IMatchTrackerService
{
    MatchDetails? Load(string path);

    Task<MatchDetails?> LoadAsync(string path);

    void Save(string path, MatchDetails data);

    Task SaveAsync(string path, MatchDetails data);

}
