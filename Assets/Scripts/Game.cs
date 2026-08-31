using UnityEngine;

public class Game : MonoBehaviour
{
    private float _stopGame = 0;
    private float _startGame = 1;
    [SerializeField] private Bird _bird;
    [SerializeField] private ColumnPool _columnPool;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endGameScreen;


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
        _bird.GameOver += StopGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _bird.GameOver -= StopGame;
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
        _endGameScreen.Open();
        Time.timeScale = _stopGame;
    }

    private void StartGame()
    {
        _columnPool.ReleaseAll();

        Time.timeScale = _startGame;
        _bird.Reset();
    }
}
