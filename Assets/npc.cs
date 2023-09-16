using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    [SerializeField] private int numberOfDialog;
    private void LetsTalk(int numberOfDialog)
    {
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
        if (Input.GetKey(KeyCode.F))
        {
            LetsTalk(numberOfDialog);
        }
    }
}
