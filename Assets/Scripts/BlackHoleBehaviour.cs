using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBehaviour : MonoBehaviour
{
    PlayerBehaviour player;
    Rigidbody2D playerRb;
    [SerializeField] float radius;
    [Tooltip("The angle in degrees in which the object moves per frame")]
    [SerializeField] float rotAngleSpeed;
    [SerializeField] float pullForce;
    float angle = 0;
    [SerializeField] Transform center;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerBehaviour>();
        playerRb = player.GetComponent<Rigidbody2D>();
        //center = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = playerRb.transform.position - transform.position;
            playerRb.AddForce(direction * pullForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        CircularMotion();
    }

    void CircularMotion()
    {
        transform.position = center.position + new Vector3(x(angle, radius), y(angle, radius), 0);
        angle += rotAngleSpeed * Time.deltaTime;
    }

    float x(float angle, float radius)
    {
        return Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
    }

    float y(float angle, float radius)
    {
        return Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center.position, radius);
    }
}
