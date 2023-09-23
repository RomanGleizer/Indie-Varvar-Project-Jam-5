using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueName;
    [SerializeField] private TMP_Text dialogueText;

    public IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        dialogueName.text = dialogueObject.nameWhoTalking;
        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
    }
}