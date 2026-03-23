using UnityEngine;

public class Interactable_Dialogue : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = ServiceHub.Instance.DialogueManager;
    }

    public void Interact()
    {
        dialogueManager.StartDialogue(dialogue: dialogue);
    }
}
