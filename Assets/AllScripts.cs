using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class AllScripts : MonoBehaviour
{
    [SerializeField] public Transform roomOne;
    [SerializeField] public Transform roomTwo;
    [SerializeField] public Transform roomThree;
    [SerializeField] public Transform roomFour;
    [SerializeField] public Transform roomFive;
    [SerializeField] public DialogueDisplayer dialogueDisplayer;
    [SerializeField] private DialogueObject zeroSceneVoice;
    [SerializeField] private DialogueObject firstSceneVoice;
    [SerializeField] private DialogueObject secondSceneVoice;
    [SerializeField] private DialogueObject thirdSceneVoice;
    [SerializeField] private DialogueObject fourSceneVoice;
    [SerializeField] private DialogueObject fiveSceneVoice;
    [SerializeField] private DialogueObject endSceneVoice;
    [SerializeField] private GameObject sprite;
    [SerializeField] private Transform _rooms;

    private Spawn spawn;

    void Start()
    {
        spawn = GetComponent<Spawn>();
        ZeroCycle();
        FirstCycle();
    }

    void ZeroCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(zeroSceneVoice);
        //как-то сделать проверку, то гг прошел все комнаты
    }

    void FirstCycle()
    {        
        // Ориентир на спрайта
        sprite.transform.position = Vector3.zero;
        //_rooms.GetChild(int.Parse(moveFrom) - 1).gameObject.SetActive(false);
        //_rooms.GetChild(int.Parse(moveTo) - 1).gameObject.SetActive(true);
        dialogueDisplayer.DisplayDialogueVoice(firstSceneVoice);
        //активировать таски

        FirstOne();
        //if done FirstTwo();
    }

    void FirstOne()
    {
        spawn.SpawnNpc(
            1,
            new Vector3(-2, 1, 0),
            roomFour,
            2,
            1,
            1);

        spawn.SpawnItem(3, new Vector3(1, 1, 0), roomThree);
    }
    void FirstTwo()
    {
        spawn.SpawnNpc(
            1,
            new Vector3(3, 1, 0),
            roomFour,
            1,
            2,
            1);

        spawn.SpawnItem(2, new Vector3(1, 1, 0), roomThree);
    }

    void SecondCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(secondSceneVoice);
        
        spawn.SpawnNpc(
            1,
            new Vector3(-3, -1, 0),
            roomTwo,
            2,
            3,
            1);

        spawn.SpawnNpc(
            3,
            new Vector3(-3, -1, 0),
            roomFour,
            3,
            2,
            1);
    }
    void ThirdCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(thirdSceneVoice);
    }
    void FourthCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(fourSceneVoice);
    }
    void FifthCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(fiveSceneVoice);
    }
    void EndCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(endSceneVoice);
    }
}
