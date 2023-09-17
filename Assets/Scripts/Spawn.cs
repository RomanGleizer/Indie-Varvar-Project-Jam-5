using TMPro;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private ItemTaker itemTaker;
    [SerializeField] private npc[] allNpc;
    [SerializeField] private Transform rooms;
    [SerializeField] private DialogueDisplayer dialogueDisplayer;
    [SerializeField] private Transform tasks;

    public void SpawnItem(int numberOfTypeItem, Vector3 location, Transform room)
    {
        Item thisItem = Instantiate(
                itemTaker.allItems[numberOfTypeItem - 1],
                location,
                gameObject.transform.rotation,
                room);
        thisItem.NumberOfType = numberOfTypeItem;
    }

    public void SpawnNpc(int numberOfTypeNpc, Vector3 location, Transform room, int neededItem, int havingItem, int numbDial, int index)
    {
         npc thisNpc = Instantiate(
                allNpc[numberOfTypeNpc - 1],
                location,
                gameObject.transform.rotation,
                room);

        tasks.GetChild(index).gameObject.SetActive(true);
        tasks.GetChild(index).GetComponent<TextMeshProUGUI>().text = thisNpc.GetComponent<TaskCreator>().taskDescription;

        thisNpc.numberWantedItem = neededItem;
        thisNpc.numberHaveItem = havingItem;
        thisNpc.rooms = rooms;
        thisNpc.itemTaker = itemTaker;
        thisNpc.dialogueDisplayer = dialogueDisplayer;
        thisNpc.numberOfDialog = numbDial;
    }

}
