using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueName;
    [SerializeField] private TMP_Text dialogueText;
    public int numberDialogue;
    [SerializeField] DialogueObject[] NatashaDialogs;

    private void Start()
    {
        dialogueBox.SetActive(false);
        DisplayDialogue(NatashaDialogs[numberDialogue]);   
        if (Input.GetKeyDown(KeyCode.P)) NextDialogue();        
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueObject.nameWhoTalking;
        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;            

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }
        dialogueBox.SetActive(false);        
    }

    public void DisplayDialogue(DialogueObject dialogueObject)
    {
        StartCoroutine(MoveThroughDialogue(dialogueObject));
    }

    public void NextDialogue()
    {
        numberDialogue++;
        DisplayDialogue(NatashaDialogs[numberDialogue]);
    }
}

