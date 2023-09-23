using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
    public DialogueLine[] dialogueLines;
    public string nameWhoTalking;
    public bool IsStarted;
    public bool IsFinished;
}
