using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private ItemTaker itemTaker;
    [SerializeField] private npc[] allNpc;
    private void SpawnItem(int numberOfTypeItem, Vector3 location, Transform room)
    {
        GameObject _item = Instantiate(
                itemTaker.allItems[numberOfTypeItem - 1].gameObject,
                location,
                gameObject.transform.rotation,
                room);
    }

    private void SpawnNpc(int numberOfTypeNpc, Vector3 location, Transform room, int neededItem, int havingItem)
    {
         npc thisNpc = Instantiate(
                allNpc[numberOfTypeNpc - 1].GetComponent<npc>(),
                location,
                gameObject.transform.rotation,
                room);
        thisNpc.numberWantedItem = neededItem;
        thisNpc.numberHaveItem = havingItem;
    }

}
