using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";

    public int BestScore => PlayerPrefs.GetInt(BestScoreKey, 0);

    public void SaveScore(int score)
    {
        if (score <= BestScore)
            return;

        PlayerPrefs.SetInt(BestScoreKey, score);
        PlayerPrefs.Save();
    }
}
