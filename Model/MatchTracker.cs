using System.Collections.Generic;
using System.Text.Json.Serialization;
using MatchStatCharts.Services;


namespace MatchStatCharts.Model
{
    public sealed record MatchDetails
    {
        [JsonPropertyName("MATCH_TRACKER_SETTINGS")]
        public MatchTrackerSettings? Settings { get; init; }

        [JsonPropertyName("MATCH_TRACKER_MATCH_TIMER")]
        public MatchTrackerMatchTimer? Timer { get; init; }

        [JsonPropertyName("MATCH_TRACKER_MATCH_SCORES")]
        public MatchTrackerMatchScores? Scores { get; init; }

        [JsonPropertyName("MATCH_TRACKER_MATCH_EVENTS")]
        public IReadOnlyList<MatchEvent>? Events { get; init; }

        public MatchDetails() { }

        public MatchDetails(
            MatchTrackerSettings? settings,
            MatchTrackerMatchTimer? timer,
            MatchTrackerMatchScores? scores,
            IReadOnlyList<MatchEvent>? events)
        {
            Settings = settings;
            Timer = timer;
            Scores = scores;
            Events = events;
        }
    }

    public sealed record MatchTrackerSettings
    {
        public string? teamAColorBG { get; init; }
        public string? teamAColorText { get; init; }
        public string? teamBColorBG { get; init; }
        public string? teamBColorText { get; init; }
        public int? layoutMaxWidth { get; init; }
        public int? fontSize { get; init; }
        public bool? showPause { get; init; }
        public string? currentPage { get; init; }
        public bool? show2Points { get; init; }
        public IReadOnlyList<IReadOnlyList<MatchAction>>? matchActions { get; init; }
        public string? shareOption { get; init; }
        public IReadOnlyList<ShareScoreConfig>? shareScoreConfig { get; init; }
        public IReadOnlyList<ShareConfig>? shareConfig { get; init; }
        public string? shareTags { get; init; }
        public string? sport { get; init; }
        public string? mode { get; init; }
        public bool? useLongPress { get; init; }
        public int? pressDelay { get; init; }
        public bool? useGAAScoresFormat { get; init; }
        public int? eventColumns { get; init; }
        public bool? useTeamLayout { get; init; }
        public int? eventFont { get; init; }
        public bool? isMatchReload { get; init; }
        public bool? showSummaryStats { get; init; }
        public bool? showStats2Teams { get; init; }
        public bool? showPlayerMiss { get; init; }
        public bool? showTeamMiss { get; init; }
        public bool? showPreview { get; init; }
        public int? eventModalHeight { get; init; }
        public bool? useFullPanelInTeamLayout { get; init; }

        public MatchTrackerSettings() { }

        public MatchTrackerSettings(
            string? teamAColorBG,
            string? teamAColorText,
            string? teamBColorBG,
            string? teamBColorText,
            int? layoutMaxWidth,
            int? fontSize,
            bool? showPause,
            string? currentPage,
            bool? show2Points,
            IReadOnlyList<IReadOnlyList<MatchAction>>? matchActions,
            string? shareOption,
            IReadOnlyList<ShareScoreConfig>? shareScoreConfig,
            IReadOnlyList<ShareConfig>? shareConfig,
            string? shareTags,
            string? sport,
            string? mode,
            bool? useLongPress,
            int? pressDelay,
            bool? useGAAScoresFormat,
            int? eventColumns,
            bool? useTeamLayout,
            int? eventFont,
            bool? isMatchReload,
            bool? showSummaryStats,
            bool? showStats2Teams,
            bool? showPlayerMiss,
            bool? showTeamMiss,
            bool? showPreview,
            int? eventModalHeight,
            bool? useFullPanelInTeamLayout)
        {
            this.teamAColorBG = teamAColorBG;
            this.teamAColorText = teamAColorText;
            this.teamBColorBG = teamBColorBG;
            this.teamBColorText = teamBColorText;
            this.layoutMaxWidth = layoutMaxWidth;
            this.fontSize = fontSize;
            this.showPause = showPause;
            this.currentPage = currentPage;
            this.show2Points = show2Points;
            this.matchActions = matchActions;
            this.shareOption = shareOption;
            this.shareScoreConfig = shareScoreConfig;
            this.shareConfig = shareConfig;
            this.shareTags = shareTags;
            this.sport = sport;
            this.mode = mode;
            this.useLongPress = useLongPress;
            this.pressDelay = pressDelay;
            this.useGAAScoresFormat = useGAAScoresFormat;
            this.eventColumns = eventColumns;
            this.useTeamLayout = useTeamLayout;
            this.eventFont = eventFont;
            this.isMatchReload = isMatchReload;
            this.showSummaryStats = showSummaryStats;
            this.showStats2Teams = showStats2Teams;
            this.showPlayerMiss = showPlayerMiss;
            this.showTeamMiss = showTeamMiss;
            this.showPreview = showPreview;
            this.eventModalHeight = eventModalHeight;
            this.useFullPanelInTeamLayout = useFullPanelInTeamLayout;
        }
    }

    public sealed record MatchAction
    {
        public string? stat { get; init; }
        public bool? isTotal { get; init; }
        public bool? showFromPlay { get; init; }
        public bool? countAsMiss { get; init; }

        public MatchAction() { }

        public MatchAction(string? stat, bool? isTotal, bool? showFromPlay, bool? countAsMiss)
        {
            this.stat = stat;
            this.isTotal = isTotal;
            this.showFromPlay = showFromPlay;
            this.countAsMiss = countAsMiss;
        }
    }

    public sealed record ShareScoreConfig
    {
        public string? value { get; init; }
        public bool? isSelected { get; init; }
        public bool? selectable { get; init; }

        public ShareScoreConfig() { }

        public ShareScoreConfig(string? value, bool? isSelected, bool? selectable)
        {
            this.value = value;
            this.isSelected = isSelected;
            this.selectable = selectable;
        }
    }

    public sealed record ShareConfig
    {
        public string? value { get; init; }
        public bool? isSelected { get; init; }

        public ShareConfig() { }

        public ShareConfig(string? value, bool? isSelected)
        {
            this.value = value;
            this.isSelected = isSelected;
        }
    }

    public sealed record MatchTrackerMatchTimer
    {
        public string? period { get; init; }
        public string? startTime { get; init; }
        public int? minsPerHalf { get; init; }
        public int? pauseTime { get; init; }
        public string? pauseStartTime { get; init; }
        public bool? timerRunning { get; init; }

        public MatchTrackerMatchTimer() { }

        public MatchTrackerMatchTimer(
            string? period,
            string? startTime,
            int? minsPerHalf,
            int? pauseTime,
            string? pauseStartTime,
            bool? timerRunning)
        {
            this.period = period;
            this.startTime = startTime;
            this.minsPerHalf = minsPerHalf;
            this.pauseTime = pauseTime;
            this.pauseStartTime = pauseStartTime;
            this.timerRunning = timerRunning;
        }
    }

    public sealed record MatchTrackerMatchScores
    {
        public string? ATeam { get; init; }
        public int? ATeamGoals { get; init; }
        public int? ATeam2Points { get; init; }
        public int? ATeamPoints { get; init; }
        public string? BTeam { get; init; }
        public int? BTeamGoals { get; init; }
        public int? BTeam2Points { get; init; }
        public int? BTeamPoints { get; init; }
        public string? matchComment { get; init; }

        public MatchTrackerMatchScores() { }

        public MatchTrackerMatchScores(
            string? ATeam,
            int? ATeamGoals,
            int? ATeam2Points,
            int? ATeamPoints,
            string? BTeam,
            int? BTeamGoals,
            int? BTeam2Points,
            int? BTeamPoints,
            string? matchComment)
        {
            this.ATeam = ATeam;
            this.ATeamGoals = ATeamGoals;
            this.ATeam2Points = ATeam2Points;
            this.ATeamPoints = ATeamPoints;
            this.BTeam = BTeam;
            this.BTeamGoals = BTeamGoals;
            this.BTeam2Points = BTeam2Points;
            this.BTeamPoints = BTeamPoints;
            this.matchComment = matchComment;
        }
    }

    public sealed record MatchEvent
    {
        public long? id { get; init; }
        public bool? isMessage { get; init; }
        public string? message { get; init; }
        public string? time { get; init; }
        public string? period { get; init; }
        public string? team { get; init; }
        public MatchAction? action01 { get; init; }
        public MatchAction? action02 { get; init; }
        public Player? player { get; init; }

        public MatchEvent() { }

        public MatchEvent(
            long? id,
            bool? isMessage,
            string? message,
            string? time,
            string? period,
            string? team,
            MatchAction? action01,
            MatchAction? action02,
            Player? player)
        {
            this.id = id;
            this.isMessage = isMessage;
            this.message = message;
            this.time = time;
            this.period = period;
            this.team = team;
            this.action01 = action01;
            this.action02 = action02;
            this.player = player;
        }
    }

    public sealed record Player
    {
        public string? name { get; init; }

        [JsonConverter(typeof(FlexibleStringConverter))]
        public string? jerseyNumber { get; init; }

        public int? positionNumber { get; init; }
        public string? club { get; init; }

        public Player() { }

        public Player(string? name, string? jerseyNumber, int? positionNumber, string? club)
        {
            this.name = name;
            this.jerseyNumber = jerseyNumber;
            this.positionNumber = positionNumber;
            this.club = club;
        }
    }
}
