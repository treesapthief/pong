using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject Player1ScoreText;
    public GameObject Player2ScoreText;

    public int PointsToWin = 7;

    private int _player1Score;
    private int _player2Score;

    private static ScoreManager _instance = null;

    protected ScoreManager()
    {
        Player1ScoreText = GameObject.Find("Player1ScoreText");
        Player2ScoreText = GameObject.Find("Player2ScoreText");
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
        if (playerNumber == 1)
        {
            _player1Score += pointsToGive;
            var text = Player1ScoreText.GetComponent<Text>();
            text.text = _player1Score.ToString();
        }
        else if (playerNumber == 2)
        {
            _player2Score += pointsToGive;
            var text = Player2ScoreText.GetComponent<Text>();
            text.text = _player2Score.ToString();
        }
        else
        {
            Debug.LogWarning($"Invalid Player Number: {playerNumber}");
        }

        if (_player1Score > PointsToWin)
        {
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
        else if (_player2Score > PointsToWin)
        {
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
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
}
