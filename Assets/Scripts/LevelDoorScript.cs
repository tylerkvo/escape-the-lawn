using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoorScript : MonoBehaviour
{
    public string levelName;
    public SceneController controller;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            controller.switchScene(levelName);
        }
    }
}
