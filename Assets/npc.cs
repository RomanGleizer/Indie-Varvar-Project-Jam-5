using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    [SerializeField] private int numberOfDialog;
    private void LetsTalk(int numberOfDialog)
    {
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
        if (Input.GetKey(KeyCode.F))
        {
            LetsTalk(numberOfDialog);
        }
    }
}
