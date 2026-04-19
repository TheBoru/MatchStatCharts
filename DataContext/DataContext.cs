using System.Collections;

namespace MatchStatCharts.DataContext
{
    public class PieChartStat:IEnumerable<PieChartStat>
    {
        public int team1count { get; set; }
        public int team2count { get; set; }
    

        public string team1name { get; set; }
        public string team2name { get; set; }

        public IEnumerator<PieChartStat> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
