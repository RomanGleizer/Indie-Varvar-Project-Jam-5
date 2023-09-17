using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BetweenRoomsMover : MonoBehaviour
{
    [SerializeField] private Transform _rooms;
    [SerializeField] private AllScripts allScripts;

    private const float DeltaY = 1.5f;
    private const float DeltaX = 5.7f;

    private bool isPlayerTouchedTrigger;
    private bool isPlayerWasInFirstRoom;
    private bool isPlayerWasInSecondRoom;
    private bool isPlayerWasInThirdRoom;
    private bool isPlayerWasInFourthRoom;
    private bool isPlayerWasInFifthRoom;
    private bool isFirstCycleWas;
    public bool IsPlayerTouchedTrigger => isPlayerTouchedTrigger;

    private void Start()
    {
        InvokeRepeating(nameof(Check), 1f, 1f);
    }

    private async void Check()
    {
        if (!isFirstCycleWas && isPlayerWasInFirstRoom && isPlayerWasInSecondRoom && isPlayerWasInThirdRoom && isPlayerWasInFourthRoom && isPlayerWasInFifthRoom)
        {
            await Task.Delay(1000);
            isFirstCycleWas = true;
            transform.position = Vector3.zero;
            _rooms.GetChild(0).gameObject.SetActive(true);
            _rooms.GetChild(1).gameObject.SetActive(false);
            _rooms.GetChild(2).gameObject.SetActive(false);
            _rooms.GetChild(3).gameObject.SetActive(false);
            _rooms.GetChild(4).gameObject.SetActive(false);
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
            _rooms.GetChild(int.Parse(moveFrom) - 1).gameObject.SetActive(false);
            _rooms.GetChild(int.Parse(moveTo) - 1).gameObject.SetActive(true);

            switch (int.Parse(moveTo))
            {
                case 1: 
                    isPlayerWasInFirstRoom = true;
                    break;
                case 2:
                    isPlayerWasInSecondRoom = true;
                    break;
                case 3:
                    isPlayerWasInThirdRoom = true;
                    break;
                case 4:
                    isPlayerWasInFourthRoom = true;
                    break;
                case 5:
                    isPlayerWasInFifthRoom = true;
                    break;
            }

            isPlayerTouchedTrigger = true;

            if (trigger.transform.position.y > 0)
                transform.position = new Vector3(0, -DeltaY, 0);
            else if (trigger.transform.position.y < 0)
                transform.position = new Vector3(0, DeltaY, 0);

            if (trigger.transform.position.x > 0)
                transform.position = new Vector3(-DeltaX, 0, 0);
            else if (trigger.transform.position.x < 0)
                transform.position = new Vector3(DeltaX, 0, 0);
        }
        else isPlayerTouchedTrigger = false;
    }
}
