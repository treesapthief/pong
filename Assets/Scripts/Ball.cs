using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed = 30;
    public Vector2 StartingPosition;

    private Rigidbody2D _rigidbody2D;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        GameManager.Instance.OnStateChange += UpdateBallMovement;
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.WaitForStart)
        {
            ResetPosition();
        }
    }

    private void Move(GameState state)
    {
        if (DisallowMovement(state))
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.right * Speed;
        }
    }

    private void ResetPosition()
    {
        _rigidbody2D.position = StartingPosition;
    }

    private void UpdateBallMovement(GameState newState)
    {
        Move(newState);
    }

    private static bool DisallowMovement(GameState gameState)
    {
        return gameState == GameState.GameOver || gameState == GameState.Paused || gameState == GameState.WaitForStart;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketLeft")
        {
            var y = HitFactor(transform.position, collision.transform.position,
            collision.collider.bounds.size.y);
            var dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * Speed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            var y = HitFactor(transform.position,
            collision.transform.position,
            collision.collider.bounds.size.y);
            var dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * Speed;
        }
    }

    private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
