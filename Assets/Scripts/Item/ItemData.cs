using UnityEngine;

public class ItemData
{
    public readonly int Number;
    public readonly Transform Room;
    public readonly Vector3 SpawnLocation;

    public ItemData(int number, Transform room, Vector3 spawnLocation)
    {
        Number = number;
        Room = room;
        SpawnLocation = spawnLocation;
    }
}
