using UnityEngine;
using System.Collections.Generic;

public static class LeaderboardManager
{
    public static List<OfflineLeaderboard.ScoreEntry> scoreEntries;

    public static void LoadLeaderboard()
    {
        scoreEntries = new List<OfflineLeaderboard.ScoreEntry>();

        for (int i = 0; i < OfflineLeaderboard.maxScores; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName" + i, "Player");
            int score = PlayerPrefs.GetInt("Score" + i, 0);
            scoreEntries.Add(new OfflineLeaderboard.ScoreEntry(playerName, score));
        }

        // Sort the leaderboard by score
        scoreEntries.Sort((x, y) => y.score.CompareTo(x.score));
    }

    public static void AddScore(string playerName, int score)
    {
        // Add the new score
        scoreEntries.Add(new OfflineLeaderboard.ScoreEntry(playerName, score));

        // Sort the leaderboard by score
        scoreEntries.Sort((x, y) => y.score.CompareTo(x.score));

        // Truncate to the maximum number of scores
        if (scoreEntries.Count > OfflineLeaderboard.maxScores)
        {
            scoreEntries.RemoveAt(scoreEntries.Count - 1);
        }

        // Update PlayerPrefs
        for (int i = 0; i < scoreEntries.Count; i++)
        {
            PlayerPrefs.SetString("PlayerName" + i, scoreEntries[i].playerName);
            PlayerPrefs.SetInt("Score" + i, scoreEntries[i].score);
        }
    }
}
