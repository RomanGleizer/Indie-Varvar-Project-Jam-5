using UnityEngine;
using UnityEngine.UI;

public class ItemTaker : MonoBehaviour
{
    [SerializeField] private Sprite emptyInventorySprite;
    [SerializeField] private Image inventorySprite;
    [SerializeField] private Sprite[] allTypeOfItems;
    [SerializeField] private bool isArmBusy = false;
    [SerializeField] private Transform rooms;
    [SerializeField] private Spawn spawn;
    
    private int typeItemInArm;
    private Transform currentRoom;

    public Transform CurrentRoom => currentRoom;

    public int TypeInArm => typeItemInArm;

    public Sprite[] AllTypeOfItems => allTypeOfItems;

    private void Awake()
    {
        currentRoom = GetComponent<Transform>();
    }

    private void Update()
    {
        DropItem();
    }

    public void TakeItem(Item item)
    {
        if (!isArmBusy) ChangeInventory(item);
        typeItemInArm = item.TypeNumber;
        isArmBusy = true;
    }

    public void DropItem()
    {
        if (!isArmBusy) return;
        
        if (Input.GetKey(KeyCode.Q))
        {
            foreach (Transform room in rooms)
                if (room.gameObject.activeSelf)
                {
                    currentRoom = room;
                    break;
                }

            var droppedItem = spawn.Items[typeItemInArm].GetComponent<Image>();
            Instantiate(droppedItem, gameObject.transform.position, Quaternion.identity, currentRoom);
            DestroyItemFromInventory();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
            if (Input.GetKey(KeyCode.E)) TakeItem(item);

        // if (collision.TryGetComponent(out Floor _)) DropItem();
    }

    public void ChangeInventory(Item item)
    {
        inventorySprite.sprite = allTypeOfItems[item.TypeNumber];
        typeItemInArm = item.TypeNumber;
        Destroy(item.gameObject);
    }

    public void DestroyItemFromInventory()
    {
        inventorySprite.sprite = emptyInventorySprite;
        typeItemInArm = 0;
        isArmBusy = false;
    }
}