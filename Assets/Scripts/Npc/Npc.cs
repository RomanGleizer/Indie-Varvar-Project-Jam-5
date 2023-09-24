using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField] private int numberWantedItem;
    [SerializeField] private Sprite essentialItem;

    private Transform currentRoom;

    public bool isGetEssentialItem;

    public Transform CurrentRoom => currentRoom;

    private void Awake()
    {
        currentRoom = GetComponent<Transform>();
        transform.GetChild(0).GetComponent<Image>().sprite = essentialItem;
    }

    private void GiveItem()
    {
        //if (numberWantedItem != itemTaker.TypeInArm) return;

        //isWaitingItem = false;

        //Instantiate(
        //    itemTaker.AllTypeOfItems[numberHaveItem - 1].gameObject,
        //    new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y, gameObject.transform.position.z),
        //    gameObject.transform.rotation,
        //    currentRoom);

        //numberHaveItem = 0;
        
        // itemTaker.DestroyItemFromInventory();
    }
}
