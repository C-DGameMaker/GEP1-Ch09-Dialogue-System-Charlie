using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerMovementController player;
    [SerializeField] TextMeshProUGUI dialogueText;

    public bool inDialogue = false;

    private void Start()
    {
        sentences = new Queue<string>();
        uiManager = ServiceHub.Instance.UIManager;
        player = ServiceHub.Instance.Player.GetComponent<PlayerMovementController>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        inDialogue = true;
        player.moveEnabled = false;
        uiManager.ShowDialoguePanel();
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        inDialogue = true;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        inDialogue = false;
        player.moveEnabled = true;
        uiManager.HideDialoguePanel();
    }





}
