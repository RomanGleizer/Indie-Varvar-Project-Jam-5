using UnityEngine;

public class npc : MonoBehaviour
{
    [SerializeField] private int numberOfDialog;
    [SerializeField] private bool isWantTalking = false;
    [SerializeField] private bool isWaitingItem = true;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;
    [SerializeField] private int numberWantedItem;
    [SerializeField] private int numberHaveItem;
    [SerializeField] private ItemTaker itemTaker;

    
    private void LetsTalk(int numberOfDialog)
    {
        dialogueDisplayer.DisplayDialogue(numberOfDialog);
    }

    private async void GiveItem()
    {
        if (numberWantedItem == itemTaker.typeItemInArm)
        {
            //LetsTalk(numberOfDialog);
            //isWantTalking = true;
            isWaitingItem = false;
            LetsTalk(0);            
            GameObject givenObj = Instantiate(itemTaker.allItems[numberHaveItem - 1].gameObject, gameObject.transform.position, gameObject.transform.rotation);
            numberHaveItem = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Высветить знак для взаимодействия

        if (collision.TryGetComponent(out PlayerMover _))
        {
            print("Можно говорить");            
            if (Input.GetKey(KeyCode.R) && isWaitingItem)
            {
                GiveItem();
                itemTaker.DestroyItemFromInventory();
            }
        }

    }
}
