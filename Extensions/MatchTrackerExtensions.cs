using MatchStatCharts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchStatCharts.Extensions
{
    public static class MatchTrackerExtensions
    {
        // -----------------------------
        // EVENT FILTERING
        // -----------------------------

        public static IEnumerable<MatchEvent> EventsByTeam(
            this MatchDetails match,
            string teamName)
        {
            return match.Events?
                .Where(e => string.Equals(e.team, teamName, StringComparison.OrdinalIgnoreCase))
                ?? Enumerable.Empty<MatchEvent>();
        }

        public static IEnumerable<MatchEvent> EventsByStat(this MatchDetails match, string stat)
        {
            return match.Events?
                .Where(e =>
                    string.Equals(e.action01?.stat, stat, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(e.action02?.stat, stat, StringComparison.OrdinalIgnoreCase))
                ?? Enumerable.Empty<MatchEvent>();
        }

        public static IEnumerable<MatchEvent> ScoringEvents(this MatchDetails match)
        {
            return match.Events?
                .Where(e =>
                    e.action01?.stat is "goal" or "point" or "2 pointer")
                ?? Enumerable.Empty<MatchEvent>();
        }

        public static IEnumerable<MatchEvent> PlayerEvents(
            this MatchDetails match,
            string playerName)
        {
            return match.Events?
                .Where(e => string.Equals(e.player?.name, playerName, StringComparison.OrdinalIgnoreCase))
                ?? Enumerable.Empty<MatchEvent>();
        }

        // -----------------------------
        // SCORE HELPERS
        // -----------------------------

        public static int TotalScoreForTeam(this MatchDetails match, string team)
        {
            if (match.Scores is null)
                return 0;

            return team.Equals(match.Scores.ATeam, StringComparison.OrdinalIgnoreCase)
                ? (match.Scores.ATeamGoals ?? 0) * 3 + (match.Scores.ATeamPoints ?? 0)
                : (match.Scores.BTeamGoals ?? 0) * 3 + (match.Scores.BTeamPoints ?? 0);
        }

        public static (int Goals, int Points) ScoreBreakdown(this MatchDetails match, string team)
        {
            if (match.Scores is null)
                return (0, 0);

            return team.Equals(match.Scores.ATeam, StringComparison.OrdinalIgnoreCase)
                ? (match.Scores.ATeamGoals ?? 0, match.Scores.ATeamPoints ?? 0)
                : (match.Scores.BTeamGoals ?? 0, match.Scores.BTeamPoints ?? 0);
        }

        // -----------------------------
        // TIME-BASED HELPERS
        // -----------------------------
        
        


        public static IEnumerable<MatchEvent> EventsInPeriod(
            this MatchDetails match,
            string period)
        {
            return match.Events?
                .Where(e => string.Equals(e.period, period, StringComparison.OrdinalIgnoreCase))
                ?? Enumerable.Empty<MatchEvent>();
        }
       


        public static IEnumerable<MatchEvent> EventsAfterMinute(
            this MatchDetails match,
            int minute)
        {
            return match.Events?
                .Where(e =>
                {
                    if (string.IsNullOrWhiteSpace(e.time))
                        return false;

                    var parts = e.time.Split(':');
                    if (parts.Length != 2)
                        return false;

                    return int.TryParse(parts[0], out int m) && m >= minute;
                })
                ?? Enumerable.Empty<MatchEvent>();
        }
    
    }
}
