using UnityEngine;

public class AllScripts : MonoBehaviour
{
    [SerializeField] private PlayerMover mover;
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
    }

    void GarbageItem()
    {
        foreach (GameObject obj in FindObjectsOfType(typeof(Item))) Destroy(obj);
    }

    void ZeroCycle()
    {
        dialogueDisplayer.DisplayDialogueVoice(zeroSceneVoice);
        //как-то сделать проверку, то гг прошел все комнаты
    }

    public void FirstCycle()
    {
        // transform.position = Vector3.zero;
        _rooms.GetChild(0).gameObject.SetActive(true);
        _rooms.GetChild(1).gameObject.SetActive(false);
        _rooms.GetChild(2).gameObject.SetActive(false);
        _rooms.GetChild(3).gameObject.SetActive(false);
        _rooms.GetChild(4).gameObject.SetActive(false);
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
            2,
            new Vector3(-2, 1, 0),
            roomFour,
            2,
            2,
            1);
        spawn.SpawnItem(2, new Vector3(1, 1, 0), roomOne);

        spawn.SpawnNpc(
            1,
            new Vector3(3, 1, 0),
            roomFive,
            1,
            1,
            2);
        spawn.SpawnItem(1, new Vector3(2, 1, 0), roomOne);

        spawn.SpawnNpc(
            3,
            new Vector3(-2, 1, 0),
            roomThree,
            3,
            3,
            3);
        spawn.SpawnItem(3, new Vector3(1, 1, 0), roomOne);
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
        _rooms.GetChild(0).gameObject.SetActive(true);
        _rooms.GetChild(1).gameObject.SetActive(false);
        _rooms.GetChild(2).gameObject.SetActive(false);
        _rooms.GetChild(3).gameObject.SetActive(false);
        _rooms.GetChild(4).gameObject.SetActive(false);
        sprite.transform.position = Vector3.zero;
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
        _rooms.GetChild(0).gameObject.SetActive(true);
        _rooms.GetChild(1).gameObject.SetActive(false);
        _rooms.GetChild(2).gameObject.SetActive(false);
        _rooms.GetChild(3).gameObject.SetActive(false);
        _rooms.GetChild(4).gameObject.SetActive(false);
        sprite.transform.position = Vector3.zero;
        dialogueDisplayer.DisplayDialogueVoice(thirdSceneVoice);
    }
    void FourthCycle()
    {
        _rooms.GetChild(0).gameObject.SetActive(true);
        _rooms.GetChild(1).gameObject.SetActive(false);
        _rooms.GetChild(2).gameObject.SetActive(false);
        _rooms.GetChild(3).gameObject.SetActive(false);
        _rooms.GetChild(4).gameObject.SetActive(false);
        sprite.transform.position = Vector3.zero;
        dialogueDisplayer.DisplayDialogueVoice(fourSceneVoice);
    }
    void FifthCycle()
    {
        _rooms.GetChild(0).gameObject.SetActive(true);
        _rooms.GetChild(1).gameObject.SetActive(false);
        _rooms.GetChild(2).gameObject.SetActive(false);
        _rooms.GetChild(3).gameObject.SetActive(false);
        _rooms.GetChild(4).gameObject.SetActive(false);
        sprite.transform.position = Vector3.zero;
        dialogueDisplayer.DisplayDialogueVoice(fiveSceneVoice);
    }
    void EndCycle()
    {
        _rooms.GetChild(0).gameObject.SetActive(true);
        _rooms.GetChild(1).gameObject.SetActive(false);
        _rooms.GetChild(2).gameObject.SetActive(false);
        _rooms.GetChild(3).gameObject.SetActive(false);
        _rooms.GetChild(4).gameObject.SetActive(false);
        sprite.transform.position = Vector3.zero;
        dialogueDisplayer.DisplayDialogueVoice(endSceneVoice);
    }
}
