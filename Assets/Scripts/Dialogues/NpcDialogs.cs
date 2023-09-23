using UnityEngine;

public class NpcDialogs : MonoBehaviour
{
    [SerializeField] private DialogueObject[] boyDialogs;
    [SerializeField] private DialogueObject[] girlDialogs;
    [SerializeField] private DialogueObject[] oldManDialogs;

    public DialogueObject[] BoyDialogs => boyDialogs;

    public DialogueObject[] GirlDialogs => girlDialogs;
    
    public DialogueObject[] OldManDialogs => oldManDialogs;

}