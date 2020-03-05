using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text PlayerWinsText;
    private int _winningPlayerNumber;

    private void Start()
    {
        GameManager.Instance.OnStateChange += ToggleGameOverPanel;
    }

    private void ToggleGameOverPanel()
    {
        var isGameOver = GameManager.Instance.GameState == GameState.GameOver;

        if (isGameOver)
        {
            var winningPlayerNumber = ScoreManager.Instance.GetWinningPlayerNumber();
            PlayerWinsText.text = $"Player {winningPlayerNumber} Wins";
        }

        GameOverPanel.SetActive(isGameOver);
    }
}
