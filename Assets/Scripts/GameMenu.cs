using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {
    public GameObject settingCanvas;
    public GameObject playerCanvas;

    void Update() {
        // Toggle the pause screen when ESC is pressed and no dialogue is active
        if (Input.GetKeyDown(KeyCode.Escape) && !NPCInteraction.isDialogueActive) {
            if (settingCanvas.activeSelf || playerCanvas.activeSelf) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        settingCanvas.SetActive(false);
        playerCanvas.SetActive(false);
        Time.timeScale = 1f;  // Resume normal time
    }

    public void Pause() {
        playerCanvas.SetActive(true);
        Time.timeScale = 0f;  // Freeze time
    }

    public void ShowPlayer() {
        playerCanvas.SetActive(true);
        settingCanvas.SetActive(false);
    }

    public void ShowSettings() {
        playerCanvas.SetActive(false);
        settingCanvas.SetActive(true);
    }
}
