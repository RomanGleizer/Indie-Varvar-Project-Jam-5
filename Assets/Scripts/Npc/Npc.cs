using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField] private int numberOfDialog;
    [SerializeField] private int numberWantedItem;
    [SerializeField] private bool isWaitingItem;
    // [SerializeField] private int numberHaveItem;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;
    [SerializeField] private NpcDialogs npcDialogues;
    [SerializeField] private ItemTaker itemTaker;
    [SerializeField] private Transform rooms;
    [SerializeField] private Sprite essentialItem;


    private Transform currentRoom;
    private int dialogCounter;

    public Transform CurrentRoom => currentRoom;

    private void Awake()
    {
        isWaitingItem = true;
        currentRoom = GetComponent<Transform>();
        transform.GetChild(1).GetComponent<Image>().sprite = essentialItem;
    }

    private void GiveItem()
    {
        if (numberWantedItem != itemTaker.TypeInArm) return;

        isWaitingItem = false;

        //Instantiate(
        //    itemTaker.AllTypeOfItems[numberHaveItem - 1].gameObject,
        //    new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y, gameObject.transform.position.z),
        //    gameObject.transform.rotation,
        //    currentRoom);

        //numberHaveItem = 0;
        
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
        // itemTaker.DestroyItemFromInventory();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover _))
            if (Input.GetKey(KeyCode.R) && isWaitingItem)
                StartCoroutine(dialogueDisplayer.MoveThroughDialogue(npcDialogues.GirlDialogs[dialogCounter]));
        // GiveItem();
    }
}
