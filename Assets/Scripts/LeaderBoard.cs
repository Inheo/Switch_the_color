using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System;

public static class LeaderBoard
{
    public static bool IsAuthenticated
    {
        get
        {
            if (PlayGamesPlatform.Instance != null) return PlayGamesPlatform.Instance.IsAuthenticated();
            return false;
        }
    }
    public static bool SavesUIOpened { get; private set; }

    public static void Initialize(bool debug)
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = debug;
        PlayGamesPlatform.Activate();
    }

    public static void Auth(Action<bool> onAuth)
    {
        Social.localUser.Authenticate((success) =>{});
    }

    public static void AddScoreToLeaderboard(int score)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, GPS.leaderboard_highscore, success => { });
        }
    }

    public static void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }
}
