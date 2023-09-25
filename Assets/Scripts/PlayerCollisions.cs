using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case Tags.T_Win:
                Debug.Log("You won!!1");
                GameManager.Instance.Won();
                break;
            case Tags.T_Lose:
                Destroy(gameObject);
                Debug.Log("You lost");
                GameManager.Instance.Lost();
                break;
        }
    }

    /* private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == Tags.T_Bounce)
        {
            Debug.Log("Bounce");
            Vector2 direction = other.gameObject.transform.position - transform.position;
            rb.AddForce(direction * bounceForce, ForceMode2D.Impulse);
        }
    } */
}
