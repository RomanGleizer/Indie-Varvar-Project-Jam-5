using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public void TakeItem()
    {
        //if (Input.GetKeyDown("E"))

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item _))
        {
            TakeItem();
            print("Можно подобрать");
        }
    }
}