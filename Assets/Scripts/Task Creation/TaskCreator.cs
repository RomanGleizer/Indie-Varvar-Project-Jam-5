using TMPro;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI taskText;
    [SerializeField] private string taskDescription;

    private void Awake()
    {
        taskText.text = taskDescription;
    }
}
