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
            inventorySprite.sprite = allTypeOfItems[item.NumberOfType];
            typeItemInArm = item.NumberOfType;
            Destroy(item.gameObject);
            isArmBusy = true;
        }
        else
        {
            //Instantiate(allItems[typeItemInArm], transform.position, transform.rotation);
            inventorySprite.sprite = allTypeOfItems[item.NumberOfType];
            typeItemInArm = item.NumberOfType;
            Destroy(item.gameObject);
            isArmBusy = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TakeItem(item);
                print("Можно подобрать");
            }
        }
    }
}