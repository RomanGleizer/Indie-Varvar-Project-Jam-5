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
    private (Npc Npc, Item Item) currentObjects;

    private Spawn spawn;

    private void Awake()
    {
        spawn = GetComponent<Spawn>();
        InitializeRooms();
        ZeroCycle();
        InvokeRepeating(nameof(FirstCycleSecondHalf), 0.5f, 0.5f);
        InvokeRepeating(nameof(FirstCycleThirdHalf), 0.5f, 0.5f);
        InvokeRepeating(nameof(FirstCycleFinalHalf), 0.5f, 0.5f);
    }

    private void ZeroCycle()
        => StartCoroutine(dialogueDisplayer.MoveThroughDialogue(voices[0]));

    public void FirstCycleFirstHalf()
    {
        DoCycle(voices[1]);

        currentObjects = GenerateObjects(
            new NpcData(1, 1, 1, 2, roomFive, new Vector3(3, 1, 0)), 
            new ItemData(1, roomOne, new Vector3(2, 1, 0)));
    }

    public void FirstCycleSecondHalf()
    {
        if (!dialogueDisplayer.IsReadyHideGirl) return;

        dialogueDisplayer.SwitchGirlHideStatus(false);
        currentObjects.Npc.gameObject.SetActive(false);

        currentObjects = GenerateObjects(
            new NpcData(2, 2, 2, 1, roomFour, new Vector3(-2, 1, 0)),
            new ItemData(2, roomOne, new Vector3(1, 1, 0)));
    }

    public void FirstCycleThirdHalf()
    {
        if (!dialogueDisplayer.IsReadyHideChild) return;

        dialogueDisplayer.SwitchChildHideStatus(false);
        currentObjects.Npc.gameObject.SetActive(false);

        currentObjects = GenerateObjects(
            new NpcData(3, 3, 3, 3, roomThree, new Vector3(-2, 1, 0)),
            new ItemData(3, roomOne, new Vector3(1, 1, 0)));
    }

    public void FirstCycleFinalHalf()
    {
        if (!dialogueDisplayer.IsReadyHideOldMan) return;
        dialogueDisplayer.SwitchOldManHideStatus(false);
        currentObjects.Npc.gameObject.SetActive(false);
    }

    private (Npc Npc, Item Item) GenerateObjects(NpcData npcData, ItemData itemData)
        => new (spawn.SpawnNpc(npcData), spawn.SpawnItem(itemData));

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
