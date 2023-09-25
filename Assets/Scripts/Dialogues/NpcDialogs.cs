using UnityEngine;

public class NpcDialogs : MonoBehaviour
{
    [SerializeField] private DialogueObject[] childDialogs;
    [SerializeField] private DialogueObject[] girlDialogs;
    [SerializeField] private DialogueObject[] oldManDialogs;

    public DialogueObject[] ChildDialogs => childDialogs;

    public DialogueObject[] GirlDialogs => girlDialogs;
    
    public DialogueObject[] OldManDialogs => oldManDialogs;

}