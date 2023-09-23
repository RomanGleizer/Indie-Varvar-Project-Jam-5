using UnityEngine;

public class PlayerSpeaker : MonoBehaviour
{
    [SerializeField] private NpcDialogs npcDialogues;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;

    private int dialogCounter;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Girl _))
            if (Input.GetKey(KeyCode.R))
            {
                StartCoroutine(dialogueDisplayer.MoveThroughDialogue(npcDialogues.GirlDialogs[dialogCounter++]));
                dialogueDisplayer.HideDialogField();
            }
    }
}
