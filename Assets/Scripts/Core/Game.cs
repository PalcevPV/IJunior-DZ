using UnityEngine;

public class Game : MonoBehaviour
{
    private float _stopGame = 0;
    private float _startGame = 1;
    [SerializeField] private Airplane _airplane;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private ColumnPool _columnPool;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endGameScreen;
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private Leaderboard _leaderboard;

    private void Start()
    {
        Time.timeScale = _stopGame;
        _startScreen.Open();
        _endGameScreen.Close();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClicked;
        _airplane.GameOver += StopGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _airplane.GameOver -= StopGame;
    }

    private void OnRestartButtonClicked()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StopGame()
    {
        _score.SaveBestScore();
        _leaderboard.Show(_score.Score);
        _endGameScreen.Open();
        Time.timeScale = _stopGame;
    }

    private void StartGame()
    {
        _enemyPool.ReleaseAll();
        _bulletPool.ReleaseAll();
        _columnPool.ReleaseAll();

        Time.timeScale = _startGame;
        _airplane.Reset();
        _score.Reset();
    }
}