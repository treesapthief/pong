using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text PlayerWinsText;
    private int _winningPlayerNumber;

    private void Start()
    {
        GameManager.Instance.OnStateChange += ToggleGameOverPanel;
    }

    public void SetWinningPlayer(int playerNumber)
    {
        _winningPlayerNumber = playerNumber;
    }

    private void ToggleGameOverPanel()
    {
        var isGameOver = GameManager.Instance.GameState == GameState.GameOver;

        if (isGameOver)
        {
            PlayerWinsText.text = $"Player {_winningPlayerNumber} Wins";
        }

        GameOverPanel.SetActive(isGameOver);
    }
}
