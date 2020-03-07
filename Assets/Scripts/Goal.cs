using UnityEngine;

public class Goal : MonoBehaviour
{
    public int PlayerNumber = 1;
    public int PointsToGive = 1;

    private void OnCollisionEnter2D(Collision2D collision) {
        var gameManager = GameManager.Instance;
        if (gameManager.GameState != GameState.InGame)
        {
            return;
        }

        if (collision.collider.gameObject.name == "Ball") {
            Debug.Log("Point Scored");
            gameManager.SetGameState(GameState.WaitForStart);
            gameManager.ScoreManager.GivePointsToPlayer(PlayerNumber, PointsToGive);
        }
    }
}
