using TMPro;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskText;
    [SerializeField] private string taskDescription;

    private void Awake()
    {
        taskText.text = taskDescription;
    }
}
