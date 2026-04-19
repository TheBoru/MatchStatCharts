using MatchStatCharts.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace MatchStatCharts.Services
{
    public interface IMatchTrackerHttpService
    {
        Task<List<MatchEvent>> GetMatchEventList();
        Task<MatchDetails> GetMatch();

        Task GetMatch(MatchDetails matchDetails);

    }
}
