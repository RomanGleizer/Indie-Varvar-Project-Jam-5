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
    
    private Spawn spawn;

    void Start()
    {
        spawn = GetComponent<Spawn>();
        FirstCycle();
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
            new Vector3(3, 1, 0),
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
}
