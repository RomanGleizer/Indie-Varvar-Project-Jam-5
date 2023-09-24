using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BetweenRoomsMover : MonoBehaviour
{
    [SerializeField] private Transform rooms;
    [SerializeField] private AllScripts allScripts;

    private const float DeltaY = 1.5f;
    private const float DeltaX = 5.7f;

    private bool[] roomStates;
    private bool isFirstCycleStarted;

    private void Start()
    {
        roomStates = new bool[] { false, false, false, false, false };
        InvokeRepeating(nameof(IsFirstCycleCanStart), 2f, 2f);
    }

    private async void IsFirstCycleCanStart()
    {
        if (!isFirstCycleStarted && roomStates.All(x => x == true))
        {
            await Task.Delay(500);
            isFirstCycleStarted = true;
            allScripts.FirstCycle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out RoomTrigger trigger))
        {
            var triggerNumbers = trigger.name.SkipWhile(e => e != ' ').ToArray()[1..];
            var moveFrom = triggerNumbers.FirstOrDefault().ToString();
            var moveTo = triggerNumbers.LastOrDefault().ToString();

            if (!int.TryParse(moveFrom, out _) || !int.TryParse(moveTo, out _)) return;
            rooms.GetChild(int.Parse(moveFrom) - 1).gameObject.SetActive(false);
            rooms.GetChild(int.Parse(moveTo) - 1).gameObject.SetActive(true);

            if (!isFirstCycleStarted) roomStates[int.Parse(moveTo) - 1] = true;

            DoMove(trigger);
        }
    }

    private void DoMove(RoomTrigger trigger)
    {
        if (trigger.transform.position.y > 0)
            transform.position = new Vector3(0, -DeltaY, 0);
        else if (trigger.transform.position.y < 0)
            transform.position = new Vector3(0, DeltaY, 0);

        if (trigger.transform.position.x > 0)
            transform.position = new Vector3(-DeltaX, 0, 0);
        else if (trigger.transform.position.x < 0)
            transform.position = new Vector3(DeltaX, 0, 0);
    }
}
