using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelindicator : MonoBehaviour
{
    public Transform target;
    public Transform player;
    public Transform arrowImage;
    public float distanceFromPlayer = 1.0f;
    public float hideDist = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - player.position;
        if (direction.magnitude < hideDist) {
            SetChildrenActive(false);
        }
        else {
            SetChildrenActive(true);
            // Normalize the direction vector to have a magnitude of 1
            direction.Normalize();

            // Position the arrow at a specific distance from the player in the direction of the target
            arrowImage.position = player.position + direction * distanceFromPlayer;

            // Calculate the angle from the direction vector
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Adjust the arrow's rotation to point towards the target
            arrowImage.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    void SetChildrenActive(bool value) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(value);
        }
    }
}
