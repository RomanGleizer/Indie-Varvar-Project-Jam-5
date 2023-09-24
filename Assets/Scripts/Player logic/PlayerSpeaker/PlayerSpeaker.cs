using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeaker : MonoBehaviour
{
    [SerializeField] private NpcDialogs npcDialogues;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;
    [SerializeField] private Image inventory;
    [SerializeField] private Sprite emptyInventorySprite;
    [SerializeField] private Image speachBox;

    private int girlDialogCounter;
    private DialogueObject currentDialog;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Girl girl))
        {
            if (Input.GetKey(KeyCode.R))
            {
                currentDialog = npcDialogues.GirlDialogs[girlDialogCounter];
                girl.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(dialogueDisplayer.MoveThroughDialogue(currentDialog));

                inventory.sprite = emptyInventorySprite;
                girlDialogCounter++;
            }
        }
    }
}
