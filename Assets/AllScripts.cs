using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScripts : MonoBehaviour
{
    [SerializeField] public Transform roomOne;
    [SerializeField] public Transform roomTwo;
    [SerializeField] public Transform roomThree;
    [SerializeField] public Transform roomFour;
    [SerializeField] public Transform roomFive;
    [SerializeField] Spawn spawn;

    void Start()
    {
        FirstCycle();
    }

    void FirstCycle()
    {
        spawn.SpawnNpc(
            1, 
            new Vector3(5, 2, 0),
            roomOne,
            1,
            2,
            1);

        spawn.SpawnNpc(
            1,
            new Vector3(7, 2, 0),
            roomOne,
            1,
            2,
            1);

        spawn.SpawnNpc(
            1,
            new Vector3(9, 2, 0),
            roomOne,
            1,
            2,
            1);
    }
}
