using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueName;
    [SerializeField] private TMP_Text dialogueText;
    // [SerializeField] private DialogueObject[] NpcDialogs;
    [SerializeField] private PlayerMover pm;
    [SerializeField] private DialogueObject dialogueObj;
    [SerializeField] private TextMeshProUGUI phrase;
    [SerializeField] private Transform rooms;
    [SerializeField] private Camera cam;
    [SerializeField] private AudioClip childBg;
    [SerializeField] private AudioClip defaultClip;
    [SerializeField] private AudioClip childClip;

    public int numberDialogue;

    //private void Start()
    //{
    //    InvokeRepeating(nameof(PlayAudio), 1f, 1f);
    //}

    //public void PlayAudio()
    //{
    //    if (phrase.text == NpcDialogs[0].dialogueLines[0].dialogue)
    //        if (pm.isCurrentNpcChild) rooms.GetChild(3).GetChild(1).GetComponent<AudioSource>().Play();

    //    if (phrase.text == NpcDialogs[0].dialogueLines[0].dialogue && pm.isCurrentNpcChild)
    //    {
    //        rooms.GetChild(3).GetChild(1).GetComponent<AudioSource>().Play();
    //        cam.GetComponent<AudioSource>().clip = null;
    //        cam.GetComponent<AudioSource>().PlayOneShot(childBg);
    //    }

    //    if (phrase.text == NpcDialogs[0].dialogueLines[NpcDialogs[0].dialogueLines.Length - 1].dialogue)
    //    {
    //        rooms.GetChild(3).GetChild(1).GetComponent<AudioSource>().enabled = false;
    //        cam.GetComponent<AudioSource>().Stop();
    //        cam.GetComponent<AudioSource>().PlayOneShot(defaultClip);
    //    }

    //    if (phrase.text == NpcDialogs[1].dialogueLines[0].dialogue)
    //        if (pm.isCurrentNpcChild)
    //        {
    //            rooms.GetChild(3).GetChild(2).GetComponent<AudioSource>().Play();
    //            pm.isCurrentNpcGirl = false;
    //        }
    //}

    //private void FixedUpdate()
    //    => dialogueObj = NpcDialogs[numberDialogue];

    public IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueObject.nameWhoTalking;

        for (int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
        }

        dialogueBox.SetActive(false);
    }

    public void DisplayDialogueVoice(DialogueObject dialogueObjVoice)
        => StartCoroutine(MoveThroughDialogue(dialogueObjVoice));
}