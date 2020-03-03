using UnityEngine;

public class Goal : MonoBehaviour
{
    public int PlayerNumber = 1;
    public int PointsToGive = 1;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.name == "Ball") {
            Debug.Log("Point Scored");
            var gameManager = GameManager.Instance;
            gameManager.SetGameState(GameState.WaitForStart);
            gameManager.ScoreManager.GivePointsToPlayer(PlayerNumber, PointsToGive);
        }
    }
}
