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
        //��������� ������ ��� �����-�� �������
    }

    private void GiveItem()
    {
        //���� ��� �������
        numberOfDialog++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //��������� ���� ��� ��������������

        if (collision.TryGetComponent(out PlayerMover _))
        {
            print("����� ��������");
            if (Input.GetKey(KeyCode.R) && talking)
            {
                LetsTalk(0);
            }
            else if (Input.GetKey(KeyCode.R) && waitingItem)
                GiveItem();
        }

    }
}
