using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] GameObject player;
    float posY;
    void Start()
    {
       posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos =  Vector2.MoveTowards(transform.position, player.transform.position, cameraSpeed * Time.deltaTime);
        pos.y = posY;
        transform.position = pos;
        
    }
}
