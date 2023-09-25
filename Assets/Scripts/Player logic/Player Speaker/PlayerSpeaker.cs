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
    private int childDialogCounter;
    private int oldManDialogCounter;

    private DialogueObject currentDialog;
    private Component currentNpc;

    public Component CurrentNpc => currentNpc;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Girl girl))
            if (Input.GetKey(KeyCode.R))
            {
                if (collision.GetComponent<Npc>().NumberWantedItem != gameObject.GetComponent<ItemTaker>().TypeInArm) return;

                currentNpc = girl;
                currentDialog = npcDialogues.GirlDialogs[girlDialogCounter];
                girl.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(dialogueDisplayer.MoveThroughDialogueWithNpc(currentDialog));

                gameObject.GetComponent<ItemTaker>().DestroyItemFromInventory();
                girlDialogCounter++;
            }

        if (collision.TryGetComponent(out Child child))
            if (Input.GetKey(KeyCode.R))
            {
                if (collision.GetComponent<Npc>().NumberWantedItem != gameObject.GetComponent<ItemTaker>().TypeInArm) return;

                currentNpc = child;
                currentDialog = npcDialogues.ChildDialogs[childDialogCounter];
                child.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(dialogueDisplayer.MoveThroughDialogueWithNpc(currentDialog));

                gameObject.GetComponent<ItemTaker>().DestroyItemFromInventory();
                childDialogCounter++;
            }

        if (collision.TryGetComponent(out OldMan oldMan))
            if (Input.GetKey(KeyCode.R))
            {
                if (collision.GetComponent<Npc>().NumberWantedItem != gameObject.GetComponent<ItemTaker>().TypeInArm) return;

                currentNpc = oldMan;
                currentDialog = npcDialogues.OldManDialogs[oldManDialogCounter];
                oldMan.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(dialogueDisplayer.MoveThroughDialogueWithNpc(currentDialog));

                gameObject.GetComponent<ItemTaker>().DestroyItemFromInventory();
                oldManDialogCounter++;
            }
    }
}
