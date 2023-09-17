using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueName;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private DialogueObject[] NpcDialogs;
    [SerializeField] private PlayerMover pm;
    [SerializeField] private DialogueObject dialogueObj;
    [SerializeField] protected TextMeshProUGUI phrase;
    [SerializeField] private Transform rooms;

    [SerializeField] public int numberDialogue;

    private void Start()
    {
        dialogueBox.SetActive(false);
        numberDialogue = 0;
        InvokeRepeating(nameof(PlayAudio), 1f, 1f);
    }

    public void PlayAudio()
    {
        if (phrase.text == NpcDialogs[0].dialogueLines[0].dialogue)
            if (pm.isCurrentNpcChild) rooms.GetChild(3).GetChild(1).GetComponent<AudioSource>().Play();
    }

    private void FixedUpdate()
    {
        dialogueObj = NpcDialogs[numberDialogue];
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        pm.speed = 0;
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueObject.nameWhoTalking;
        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }
        dialogueBox.SetActive(false);
        pm.speed = 2;
    }

    public void DisplayDialogue()
    {
        StartCoroutine(MoveThroughDialogue(dialogueObj));
    }

    public void DisplayDialogueVoice(DialogueObject dialogueObjVoice)
    {
        StartCoroutine(MoveThroughDialogue(dialogueObjVoice));
    }

}

