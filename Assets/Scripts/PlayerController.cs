using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;
    private Rigidbody2D player;
    private Vector2 movement; // Use this instance variable for movement

    void Start() {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical); // Update the instance variable directly

        // Check if the player is moving
        if (movement != Vector2.zero) {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("MoveX", moveHorizontal);
            animator.SetFloat("MoveY", moveVertical);
        } else {
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate() {
        player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
    }
}