using UnityEngine;
using UnityEngine.UI;

public class ItemTaker : MonoBehaviour
{
    [SerializeField] private Image inventorySprite;
    [SerializeField] private Sprite[] allTypeOfItems;
    [SerializeField] private bool isArmBusy = false;
    [SerializeField] private Transform rooms;
    
    public int typeItemInArm = 0;
    public Item[] allItems;

    private Transform currentRoom;

    public Transform CurrentRoom => currentRoom;

    private void Awake()
    {
        currentRoom = GetComponent<Transform>();
    }

    public void TakeItem(Item item)
    {
        if (!isArmBusy) ChangeInventory(item);
    }

    public void DropItem()
    {
        if (!isArmBusy) return;
        
        if (Input.GetKey(KeyCode.Q))
        {
            foreach (Transform room in rooms)
                if (room.gameObject.activeSelf) currentRoom = room;

            Instantiate(allItems[typeItemInArm - 1].GetComponent<Image>(),
                    gameObject.transform.position, 
                    gameObject.transform.rotation,
                    currentRoom);

            DestroyItemFromInventory();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
            if (Input.GetKey(KeyCode.E)) TakeItem(item);

        if (collision.TryGetComponent(out Floor _)) DropItem();
    }

    public void ChangeInventory(Item item)
    {
        inventorySprite.sprite = allTypeOfItems[item.NumberOfType];
        typeItemInArm = item.NumberOfType;
        Destroy(item.gameObject);
        isArmBusy = true;
    }

    public void DestroyItemFromInventory()
    {
        inventorySprite.sprite = allTypeOfItems[0];
        typeItemInArm = 0;
        isArmBusy = false;
    }
}