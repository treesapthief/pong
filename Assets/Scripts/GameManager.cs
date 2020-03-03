using UnityEngine;

public enum GameState
{
    WaitForStart,
    InGame,
    Paused,
    GameOver
}

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
    public event OnStateChangeHandler OnStateChange;
    public GameState GameState { get; private set; }

    private static GameManager _instance = null;

    protected GameManager()
    {
        ScoreManager = ScoreManager.Instance;
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;
        }
    }

    public ScoreManager ScoreManager { get; set; }

    public void SetGameState(GameState state)
    {
        GameState = state;
        OnStateChange?.Invoke();
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

    private void OnApplicationQuit()
    {
        _instance = null;
    }
}
