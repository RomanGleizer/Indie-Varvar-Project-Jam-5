using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueName;
    [SerializeField] private TMP_Text dialogueText;
    public int numberDialogue;
    [SerializeField] DialogueObject[] NatashaDialogs;
    [SerializeField] private PlayerMover pm;

    private void Start()
    {
        dialogueBox.SetActive(false);
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        pm._speed = 0;
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueObject.nameWhoTalking;
        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }
        dialogueBox.SetActive(false);
        pm._speed = 2;
    }

    public void DisplayDialogue(int numberDialogue)
    {
        StartCoroutine(MoveThroughDialogue(NatashaDialogs[numberDialogue]));
    }

    public void NextDialogue()
    {
        numberDialogue++;
        DisplayDialogue(numberDialogue);
    }
}

