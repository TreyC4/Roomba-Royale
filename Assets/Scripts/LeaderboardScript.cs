using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro; 

public class LeaderboardScript : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;

    private List<ScoreEntry> scores = new List<ScoreEntry>();
    private const int maxEntries = 10; // Maximum number of entries in the leaderboard

    private void Start()
    {
        LoadScores();
        UpdateLeaderboardUI();
    }

    public void AddScore(string playerName, int score)
    {
        ScoreEntry newScore = new ScoreEntry
        {
            playerName = playerName,
            score = score
        };
        scores.Add(newScore);
        scores.Sort((x, y) => y.score.CompareTo(x.score)); // Sort scores in descending order

        if (scores.Count > maxEntries)
        {
            scores.RemoveAt(scores.Count - 1); // Remove the last entry if more than maxEntries
        }

        SaveScores();
        UpdateLeaderboardUI();
    }

    private void UpdateLeaderboardUI()
    {
        leaderboardText.text = "Leaderboard:\n";

        for (int i = 0; i < scores.Count; i++)
        {
            leaderboardText.text += (i + 1) + ". " + scores[i].playerName + " - " + scores[i].score + "\n";
        }
    }

    private void SaveScores()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/leaderboard.dat");
        formatter.Serialize(file, scores);
        file.Close();
    }

    private void LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/leaderboard.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/leaderboard.dat", FileMode.Open);
            scores = (List<ScoreEntry>)formatter.Deserialize(file);
            file.Close();
        }
    }
}
