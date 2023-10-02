using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerBehaviour pb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pb = GetComponent<PlayerBehaviour>();

    }
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
                AudioManager.Instance.PlayEruptionSFX();
                Debug.Log("You lost");
                GameManager.Instance.Lost();
                break;
        }
    }
   /*  private void OnTriggerStay2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case Tags.T_BigHole:
                GoToOrbit(other.GetComponent<CircleCollider2D>().radius);
                break;
        }
    }


    void GoToOrbit(float radius)
    {
       
    } */
}

