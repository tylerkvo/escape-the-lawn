using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 5f;
    private int waypointIndex = 0;
    private bool movingForward = true;
    public Transform ProfSpawn;
    public Transform PlayerSpawn;
    public float speedIncrease = 0.1f;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (waypoints.Count > 1)
        {
            Move();
            IncreaseSpeedOverTime();
        }
    }

    private void Move()
    {
        Transform targetWaypoint = waypoints[waypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
        Vector2 directionToTarget = targetWaypoint.position - transform.position;

        if (directionToTarget != Vector2.zero)
        {
            directionToTarget.Normalize();

            if (Mathf.Abs(directionToTarget.x) > Mathf.Abs(directionToTarget.y))
            {
        
                if (directionToTarget.x > 0)
                    animator.SetTrigger("WalkRight");
                else
                    animator.SetTrigger("WalkLeft");
            }
            else
            {
            
                if (directionToTarget.y > 0)
                    animator.SetTrigger("WalkUp");
                else
                    animator.SetTrigger("WalkDown");
            }
        }

        if (transform.position == targetWaypoint.position)
        {
            if (movingForward)
            {
                if (waypointIndex < waypoints.Count - 1)
                    waypointIndex++;
                else
                    movingForward = false;
            }
            else
            {
                if (waypointIndex > 0)
                    waypointIndex--;
                else
                    movingForward = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = PlayerSpawn.position;
            transform.position = ProfSpawn.position;
            waypointIndex = 0;
            movingForward = true;
            speed = 5f;
        }
    }
    void IncreaseSpeedOverTime()
    {
        speed += Time.deltaTime * speedIncrease;
    }
}
