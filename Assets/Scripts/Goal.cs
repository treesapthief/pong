using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.name == "Ball") {
            Debug.Log("Point Scored");
            Destroy(collision.collider.gameObject);
        }
    }
}
