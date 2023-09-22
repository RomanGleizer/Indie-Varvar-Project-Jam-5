using UnityEngine;

public class NpcData
{
    public readonly int Number;
    public readonly int WantedItem;
    public readonly int HavingItem;
    public readonly int NextDialogueNumber;
    public readonly Transform Room;
    public readonly Vector3 SpawnLocation;

    public NpcData(int number, int wantedItem, int havingItem, int nextDialogueNumber, Transform room, Vector3 spawnLocation)
    {
        Number = number;
        WantedItem = wantedItem;
        HavingItem = havingItem;
        NextDialogueNumber = nextDialogueNumber;
        Room = room;
        SpawnLocation = spawnLocation;
    }
}
