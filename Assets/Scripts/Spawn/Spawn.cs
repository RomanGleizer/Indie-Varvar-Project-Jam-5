using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Npc[] npc;
    [SerializeField] private Item[] itemsForSpawn;

    public Item[] Items => itemsForSpawn;

    public Npc SpawnNpc(NpcData npcData)
        => Instantiate(npc[npcData.Number - 1], npcData.SpawnLocation, Quaternion.identity, npcData.Room);

    public Item SpawnItem(ItemData itemData)
        => Instantiate(itemsForSpawn[itemData.Number - 1], itemData.SpawnLocation, Quaternion.identity, itemData.Room);
}
