using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] float pushOverForce = 10;
    [SerializeField] float timerMax = 1f;
    Rigidbody2D rb;
    Vector2 startPos;

    float timer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
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
                Debug.Log("You lost");
                GameManager.Instance.Lost();
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.T_Borders)) timer = timerMax;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.T_Borders))
        {
           // 
            //CountDownReset();
           // PushAway(other);
        }
    }

    void CountDownReset()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            transform.position = startPos;
    }

    void PushAway(Collision2D other)
    {
        Debug.Log("PUSH");
        Vector2 move = rb.position - other.GetContact(0).point;
        rb.AddForce(move * pushOverForce, ForceMode2D.Impulse);
    }

}
