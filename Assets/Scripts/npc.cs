using UnityEditor;
using UnityEngine;

public class npc : MonoBehaviour
{
    [SerializeField] private int numberOfDialog;
    [SerializeField] private bool isWantTalking = false;
    [SerializeField] private bool isWaitingItem = true;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;
    [SerializeField] public int numberWantedItem;
    [SerializeField] public int numberHaveItem;
    [SerializeField] private ItemTaker itemTaker;
    [SerializeField] private Transform rooms;

    private Transform currentRoom;

    public Transform CurrentRoom => currentRoom;

    private void Awake()
    {
        currentRoom = GetComponent<Transform>();
    }

    private void LetsTalk(int numberOfDialog)
    {
        dialogueDisplayer.DisplayDialogue(numberOfDialog);
    }

    private void GiveItem()
    {
        if (numberWantedItem == itemTaker.typeItemInArm)
        {
            isWaitingItem = false;
            LetsTalk(0);

            GameObject go = Instantiate(
                itemTaker.allItems[numberHaveItem - 1].gameObject, 
                new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y, gameObject.transform.position.z), 
                gameObject.transform.rotation, 
                currentRoom);

            numberHaveItem = 0;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            itemTaker.DestroyItemFromInventory();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Высветить знак для взаимодействия

        if (collision.TryGetComponent(out PlayerMover _))      
            if (Input.GetKey(KeyCode.R) && isWaitingItem)
            {
                foreach (Transform room in rooms)
                    if (room.gameObject.activeSelf) currentRoom = room;

                GiveItem();
            }
    }
}
