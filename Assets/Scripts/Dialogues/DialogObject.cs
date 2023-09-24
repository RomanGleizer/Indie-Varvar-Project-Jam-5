using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
    public DialogueLine[] dialogueLines;
    public string Name;
    public bool IsEnded;
}
