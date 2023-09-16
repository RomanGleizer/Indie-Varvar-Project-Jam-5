using UnityEngine;
using UnityEngine.UI;

public class ItemTaker : MonoBehaviour
{
    [SerializeField] private Image inventorySprite;
    [SerializeField] private Sprite[] allTypeOfItems;
    [SerializeField] private bool isArmBusy = false;
    [SerializeField] private int typeItemInArm = 0;
    [SerializeField] private Item[] allItems;

    public void TakeItem(Item item)
    {
        if (!isArmBusy)
        {
            ChangeInventory(item);
        }
        else
        {
            print("������ ����");
        }
    }

    public void DropItem()
    {
        if (isArmBusy)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                print("���");
                GameObject dropItem = Instantiate(allItems[typeItemInArm - 1].gameObject, gameObject.transform.position, gameObject.transform.rotation);
                inventorySprite.sprite = allTypeOfItems[0];
                typeItemInArm = 0;
                isArmBusy = false;
            }
        }
        //else print("������ ���");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            print("����� ���������");
            if (Input.GetKey(KeyCode.E))
            {
                print("������");
                TakeItem(item);
            }
        }
        if (collision.TryGetComponent(out Floor _))
        {
            DropItem();
        }
    }

    public void ChangeInventory(Item item)
    {
        inventorySprite.sprite = allTypeOfItems[item.NumberOfType];
        typeItemInArm = item.NumberOfType;
        Destroy(item.gameObject);
        isArmBusy = true;
    }
}