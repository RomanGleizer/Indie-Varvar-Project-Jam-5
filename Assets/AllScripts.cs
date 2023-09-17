using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    void FirstCycle()
    {
        // Ориентир на спрайта

        //spawn.SpawnNpc(
        //    1, 
        //    new Vector3(5, 2, 0),
        //    roomOne,
        //    1,
        //    2,
        //    1,
        //    0);

        spawn.SpawnNpc(
            1,
            new Vector3(3, 2, 0),
            roomOne,
            1,
            2,
            1,
            1);

        //spawn.SpawnNpc(
        //    1,
        //    new Vector3(9, 2, 0),
        //    roomOne,
        //    1,
        //    2,
        //    1,
        //    2);
    }
    void SecondCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(secondSceneVoice);
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
