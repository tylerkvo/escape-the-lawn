using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public static bool isDialogueActive = false;  // Track if dialogue is active
    public GameObject interactionPrompt;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueTextDisplay;
    public string[] dialogueLines;
    private int currentLineIndex = 0;
    private bool isPlayerInRange = false;

    private void Start()
    {
        interactionPrompt.SetActive(false);
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogueBox.activeInHierarchy)
            {
                ShowDialogue();
            }
            else
            {
                NextDialogueLine();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionPrompt.SetActive(false);
            dialogueBox.SetActive(false);
            PlayerController.canMove = true;
            currentLineIndex = 0;
            isDialogueActive = false;  // Dialogue ends
        }
    }

    private void ShowDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueTextDisplay.text = dialogueLines[currentLineIndex];
        PlayerController.canMove = false;
        isDialogueActive = true;  // Dialogue starts
    }

    private void NextDialogueLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueTextDisplay.text = dialogueLines[currentLineIndex];
        }
        else
        {
            dialogueBox.SetActive(false);
            PlayerController.canMove = true;
            currentLineIndex = 0;
            isDialogueActive = false;  // Dialogue ends
        }
    }
}
