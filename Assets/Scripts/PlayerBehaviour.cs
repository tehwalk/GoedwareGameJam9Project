using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(speed * Vector2.right * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    public void SetGravity(float gravity)
    {
        rb.gravityScale = gravity;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Win"))
        {
            Debug.Log("Yeeeeeeeeeeeeeeeeeeeeeeeeee");
        }
    }
}