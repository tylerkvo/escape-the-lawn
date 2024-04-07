using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        // Toggle the pause screen when ESC is pressed
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (pauseMenuUI.activeSelf) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume normal time
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Freeze time
    }
}
