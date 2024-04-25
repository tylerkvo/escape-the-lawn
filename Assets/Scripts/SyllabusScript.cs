using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyllabusScript : MonoBehaviour
{
    public GameObject SyllabusPanel; 

    void Start()
    {
        SyllabusPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game time
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SyllabusPanel.SetActive(false); // Hide the instructions panel
            Time.timeScale = 1f; // Resume the game time
        }
    }
}
