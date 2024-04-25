using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow3 : MonoBehaviour
{
    public Transform player;
    
    

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x;
        newPosition.y = player.transform.position.y;
        transform.position = newPosition;
    }
}
