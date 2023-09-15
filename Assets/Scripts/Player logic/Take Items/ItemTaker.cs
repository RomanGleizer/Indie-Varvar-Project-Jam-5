using UnityEngine;
using UnityEngine.UI;

public class ItemTaker : MonoBehaviour
{
    [SerializeField] private Image inventorySprite;
    [SerializeField] private Sprite itemSq;
    [SerializeField] private bool isArmBusy = false;
    public void TakeItem(Item item)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Подбор");
            if (item.TryGetComponent(out ItemSq _))
                inventorySprite.sprite = itemSq;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            //TakeItem(item);
            print("Можно подобрать");
            if (Input.GetKey(KeyCode.E))
            {
                print("Подбор");
                if (collision.TryGetComponent(out ItemSq _))
                { 
                    inventorySprite.sprite = itemSq;
                    Destroy(collision.gameObject);
                    isArmBusy = true;
                }
            }

        }
    }
}