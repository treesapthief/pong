using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float Speed = 30;
    public string Axis = "Vertical";

    private Rigidbody2D _rigidBody2D;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (DisallowMovement())
        {
            return;
        }

        var verticalAxis = Input.GetAxisRaw(Axis);
        _rigidBody2D.velocity = new Vector2(0, verticalAxis) * Speed;
    }

    private static bool DisallowMovement()
    {
        var gameState = GameManager.Instance.GameState;
        return gameState == GameState.GameOver || gameState == GameState.Paused;
    }
}
