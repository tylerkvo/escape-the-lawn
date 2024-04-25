using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool canMove = true;  // Control flag for player movement
    public float speed = 6.0f;
    private Animator animator;
    private Rigidbody2D player;
    private Vector2 movement;
    public Transform respawnPoint;

    void Start() {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (canMove) {  // Check if movement is allowed
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
        } else {
            // Stop movement and animations when canMove is false
            movement = Vector2.zero;
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate() {
        // Apply movement
        player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("book")) {
            transform.position = respawnPoint.position;
        }
    }
}
