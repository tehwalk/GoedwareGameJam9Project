using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    Animator animator;
    PlayerBehaviour playerBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerBehaviour = GameObject.FindObjectOfType<PlayerBehaviour>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == playerBehaviour.gameObject)
        {
            animator.SetTrigger("Bounce");
        }
    }
}
