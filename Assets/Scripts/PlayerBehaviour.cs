using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    float speed; //0.3
    public float Speed { get { return speed; } }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetSpeed(0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rb.AddForce(speed * Vector2.right * Time.fixedDeltaTime, ForceMode2D.Impulse);
        rb.position += Vector2.right * speed * Time.fixedDeltaTime;
    }

    public void SetGravity(float gravity)
    {
        rb.gravityScale = gravity;
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }

}
