using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private TMP_Text _leaderboardText;

    private readonly List<LeaderboardEntry> _fakeEntries = new()
    {
        new LeaderboardEntry("ACE", 27),
        new LeaderboardEntry("MAVERICK", 20),
        new LeaderboardEntry("FALCON", 8),
        new LeaderboardEntry("GHOST", 4)
    };

    public void Show(int playerScore)
    {
        List<LeaderboardEntry> entries = new(_fakeEntries)
        {
            new LeaderboardEntry("YOU", playerScore)
        };

        entries = entries.OrderByDescending(entry => entry.Score).ToList();

        _leaderboardText.text = "LEADERBOARD\n\n";

        for (int i = 0; i < entries.Count; i++)
        {
            LeaderboardEntry entry = entries[i];

            _leaderboardText.text += $"{i + 1}. {entry.Name}     {entry.Score}\n";
        }
    }
}