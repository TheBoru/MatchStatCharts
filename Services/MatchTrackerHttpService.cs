using MatchStatCharts.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace MatchStatCharts.Services
{
    public class MatchTrackerHttpService(IServiceScopeFactory serviceScopeFactory) : IMatchTrackerHttpService
    {
        //private HttpClient Http = new HttpClient();
        public List<MatchEvent> MatchEventList;
        private MatchDetails? matchDetails;
               
        public MatchDetails? MatchDetails { get => matchDetails; set => matchDetails = value; }

        

        public async Task<List<MatchEvent>> GetMatchEventList()
        {
            if (MatchEventList.Count == 0)
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();
                var Http = scope.ServiceProvider.GetRequiredService<HttpClient>();
                MatchEventList = (await Http.GetFromJsonAsync<MatchDetails>("D1R2 Graiguecullen 17042026.gaaapps.txt")).Events.ToList();
            }
            
            return MatchEventList;
        }

        public async Task<MatchDetails> GetMatch()
        {
            if (MatchDetails is null)
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();
                var Http = scope.ServiceProvider.GetRequiredService<HttpClient>();
                MatchDetails = await Http.GetFromJsonAsync<MatchDetails>("D1R2 Graiguecullen 17042026.gaaapps.txt");
            }

            return MatchDetails;
        }

        public async Task GetMatch(MatchDetails matchDetails)
        {
            if (matchDetails is null)
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();
                var Http = scope.ServiceProvider.GetRequiredService<HttpClient>();
                matchDetails = await Http.GetFromJsonAsync<MatchDetails>("D1R2 Graiguecullen 17042026.gaaapps.txt");
            }

            return;
        }
    }
}
