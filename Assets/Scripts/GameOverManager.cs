using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text PlayerWinsText;

    private void Start()
    {
        GameManager.Instance.OnStateChange += ToggleGameOverPanel;
    }

    private void ToggleGameOverPanel(GameState newState)
    {
        var isGameOver = newState == GameState.GameOver;

        if (isGameOver)
        {
            var winningPlayerNumber = ScoreManager.Instance.GetWinningPlayerNumber();
            PlayerWinsText.text = $"Player {winningPlayerNumber} Wins";
        }

        Debug.Log($"GameOverPanel Active: {isGameOver}");
        GameOverPanel.SetActive(isGameOver);
    }
}
