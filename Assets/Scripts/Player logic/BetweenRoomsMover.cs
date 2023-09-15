using System.Linq;
using UnityEngine;

public class BetweenRoomsMover : MonoBehaviour
{
    [SerializeField] private Transform _rooms;

    private const float DeltaY = 1.5f;
    private const float DeltaX = 5.7f;

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

            switch (trigger.transform.position.y > 0)
            {
                case true:
                    transform.position = new Vector3(0, -DeltaY, 0);
                    break;
                case false:
                    transform.position = new Vector3(0, DeltaY, 0);
                    break;
            }

            switch (trigger.transform.position.x > 0)
            {
                case true:
                    transform.position = new Vector3(DeltaX, 0, 0);
                    break;
                case false:
                    transform.position = new Vector3(-DeltaX, 0, 0);
                    break;
            }
        }
    }
}
