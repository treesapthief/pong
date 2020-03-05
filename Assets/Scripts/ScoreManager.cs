using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject Player1ScoreText;
    public GameObject Player2ScoreText;

    public int PointsToWin = 7;

    private int _player1Score;
    private int _player2Score;
    private int _winningPlayerNumber;

    private static ScoreManager _instance = null;

    protected ScoreManager()
    {
    }

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreManager();
            }

            return _instance;
        }
    }

    public void GivePointsToPlayer(int playerNumber, int pointsToGive)
    {
        var currentScore = 0;

        if (playerNumber == 1)
        {
            currentScore = _player1Score;
        }
        else if (playerNumber == 2)
        {
            currentScore = _player2Score;
        }

        var score = currentScore + pointsToGive;
        SetPlayerScore(score, playerNumber);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void SetPlayerScore(int score, int playerNumber)
    {
        if (playerNumber == 1)
        {
            _player1Score = score;
            var text = Player1ScoreText.GetComponent<Text>();
            text.text = _player1Score.ToString();
        }
        else if (playerNumber == 2)
        {
            _player2Score = score;
            var text = Player2ScoreText.GetComponent<Text>();
            text.text = _player2Score.ToString();
        }
        else
        {
            Debug.LogWarning($"Invalid Player Number: {playerNumber}");
        }

        if (_player1Score >= PointsToWin)
        {
            SetWinningPlayerNumber(1);
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
        else if (_player2Score >= PointsToWin)
        {
            SetWinningPlayerNumber(2);
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
    }

    public int GetWinningPlayerNumber()
    {
        return _winningPlayerNumber;
    }

    private void SetWinningPlayerNumber(int playerNumber)
    {
        _winningPlayerNumber = playerNumber;
    }

    public void Reset()
    {
        SetPlayerScore(0, 1);
        SetPlayerScore(0, 2);
        SetWinningPlayerNumber(0);
    }
}
