using UnityEngine;

public class npc : MonoBehaviour
{
    [SerializeField] private int numberOfDialog;
    [SerializeField] private bool talking;
    [SerializeField] private bool waitingItem;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;
    private void LetsTalk(int numberOfDialog)
    {
        dialogueDisplayer.DisplayDialogue(numberOfDialog);
        //Загрузить диалог под таким-то номером
    }

    private void GiveItem()
    {
        //Если дал предмет
        numberOfDialog++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Высветить знак для взаимодействия

        if (collision.TryGetComponent(out PlayerMover _))
        {
            print("Можно говорить");
            if (Input.GetKey(KeyCode.R) && talking)
            {
                LetsTalk(0);
            }
            else if (Input.GetKey(KeyCode.R) && waitingItem)
                GiveItem();
        }

    }
}
