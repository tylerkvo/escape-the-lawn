using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public SceneController controller;
    // This method will be called when the "Start Game" button is pressed
    public void StartGame()
    {
        controller.switchScene("Lawn Year 1");
    }
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        
        // If we're running in the editor, stop playing the scene
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
