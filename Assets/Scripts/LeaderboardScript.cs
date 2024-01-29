using UnityEngine;

using System;
using System.Collections.Generic;
using TMPro;

public class OfflineLeaderboard : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;

    public const int maxScores = 10;
    private List<ScoreEntry> scoreEntries;

    [Serializable]
    public class ScoreEntry
    {
        public string playerName;
        public int score;

        public ScoreEntry(string name, int score)
        {
            playerName = name;
            this.score = score;
        }
    }

    void Start()
    {
        // Initialize the list from PlayerPrefs
        LoadLeaderboard();
        UpdateLeaderboardUI();
    }

    void LoadLeaderboard()
    {
        scoreEntries = new List<ScoreEntry>();

        for (int i = 0; i < maxScores; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName" + i, "Player");
            int score = PlayerPrefs.GetInt("Score" + i, 0);
            scoreEntries.Add(new ScoreEntry(playerName, score));
        }

        // Sort the leaderboard by score
        scoreEntries.Sort((x, y) => y.score.CompareTo(x.score));
    }

    void UpdateLeaderboardUI()
    {
        leaderboardText.text = "Leaderboard:\n";

        for (int i = 0; i < scoreEntries.Count; i++)
        {
            leaderboardText.text += $"{i + 1}. {scoreEntries[i].playerName}: {scoreEntries[i].score}\n";
        }
    }

    public void AddScore(string playerName, int score)
    {
        // Add the new score
        scoreEntries.Add(new ScoreEntry(playerName, score));

        // Sort the leaderboard by score
        scoreEntries.Sort((x, y) => y.score.CompareTo(x.score));

        // Truncate to the maximum number of scores
        if (scoreEntries.Count > maxScores)
        {
            scoreEntries.RemoveAt(scoreEntries.Count - 1);
        }

        // Update PlayerPrefs
        for (int i = 0; i < scoreEntries.Count; i++)
        {
            PlayerPrefs.SetString("PlayerName" + i, scoreEntries[i].playerName);
            PlayerPrefs.SetInt("Score" + i, scoreEntries[i].score);
        }

        // Update UI
        UpdateLeaderboardUI();
    }
}
