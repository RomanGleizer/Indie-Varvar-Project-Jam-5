using UnityEngine;

public class AllScripts : MonoBehaviour
{
    [SerializeField] private PlayerMover mover;
    [SerializeField] private DialogueObject[] voices;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;
    [SerializeField] private GameObject sprite;
    [SerializeField] private Transform rooms;

    private Transform roomOne;
    private Transform roomTwo;
    private Transform roomThree;
    private Transform roomFour;
    private Transform roomFive;

    private Spawn spawn;

    private void Awake()
    {
        spawn = GetComponent<Spawn>();
        InitializeRooms();
        ZeroCycle();
    }

    private void ZeroCycle()
    {
        StartCoroutine(dialogueDisplayer.MoveThroughDialogue(voices[0]));
    }

    public void FirstCycle()
    {
        DoCycle(voices[1]);
        ActivateFirstPart();
    }

    private void ActivateFirstPart()
    {
        spawn.SpawnNpc(new NpcData(1, 1, 1, 2, roomFive, new Vector3(3, 1, 0)));
        spawn.SpawnItem(new ItemData(1, roomOne, new Vector3(2, 1, 0)));

        // .SpawnNpc(new NpcData(2, 2, 2, 1, roomFour, new Vector3(-2, 1, 0)));
        // spawn.SpawnItem(new ItemData(2, roomOne, new Vector3(1, 1, 0)));

        // spawn.SpawnNpc(new NpcData(1, 1, 1, 2, roomFive, new Vector3(3, 1, 0)));
        // spawn.SpawnItem(new ItemData(1, roomOne, new Vector3(2, 1, 0)));

        // spawn.SpawnNpc(new NpcData(3, 3, 3, 3, roomThree, new Vector3(-2, 1, 0)));
        // spawn.SpawnItem(new ItemData(3, roomOne, new Vector3(1, 1, 0)));
    }

    //private void FirstTwo()
    //{
    //    spawn.SpawnNpc(
    //        1,
    //        new Vector3(3, 1, 0),
    //        roomFour,
    //        1,
    //        2,
    //        1);

    //    spawn.SpawnItem(2, new Vector3(1, 1, 0), roomThree);
    //}

    //private void SecondCycle()
    //{
    //    spawn.SpawnNpc(
    //        1,
    //        new Vector3(-3, -1, 0),
    //        roomTwo,
    //        2,
    //        3,
    //        1);

    //    spawn.SpawnNpc(
    //        3,
    //        new Vector3(-3, -1, 0),
    //        roomFour,
    //        3,
    //        2,
    //        1);
    //}

    public void DoCycle(DialogueObject dialogue)
    {
        SwitchRooms();
        sprite.transform.position = Vector3.zero;
        StartCoroutine(dialogueDisplayer.MoveThroughDialogue(dialogue));
    }

    private void SwitchRooms()
    {
        rooms.GetChild(0).gameObject.SetActive(true);
        for (int i = 1; i < rooms.childCount; i++)
            rooms.GetChild(i).gameObject.SetActive(false);
    }

    private void InitializeRooms()
    {
        roomOne = rooms.GetChild(0);
        roomTwo = rooms.GetChild(1);
        roomThree = rooms.GetChild(2);
        roomFour = rooms.GetChild(3);
        roomFive = rooms.GetChild(4);
    }
}
