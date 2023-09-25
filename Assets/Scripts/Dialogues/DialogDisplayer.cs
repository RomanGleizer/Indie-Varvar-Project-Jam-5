using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private PlayerSpeaker speaker;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueName;
    [SerializeField] private TMP_Text dialogueText;

    private bool isReadyHideGirl;
    private bool isReadyHideChild;
    private bool isReadyHideOldMan;

    public bool IsReadyHideGirl => isReadyHideGirl;

    public bool IsReadyHideChild => isReadyHideChild;

    public bool IsReadyHideOldMan => isReadyHideOldMan;

    public IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueObject.Name;

        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }

        dialogueBox.SetActive(false);
    }

    public IEnumerator MoveThroughDialogueWithNpc(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueObject.Name;

        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            if (i == dialogueObject.dialogueLines.Length - 1)
                switch (speaker.CurrentNpc)
                {
                    case Girl: 
                        isReadyHideGirl = true;
                        break;
                    case Child:
                        isReadyHideChild = true;
                        break;
                    case OldMan:
                        isReadyHideOldMan = true;
                        break;
                }
        }

        dialogueBox.SetActive(false);
    }

    public void SwitchGirlHideStatus(bool status)
        => isReadyHideGirl = status;

    public void SwitchChildHideStatus(bool status)
        => isReadyHideChild = status;

    public void SwitchOldManHideStatus(bool status)
        => isReadyHideOldMan = status;
}