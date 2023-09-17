using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject mistake;

    [SerializeField] private bool inSettings = false;
    [SerializeField] private bool inPause = false;
    [SerializeField] private bool inSaving = false;
    private bool inCreators = false;

    private void Start()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        settings.SetActive(false);
        mistake.SetActive(false); //Поменять!!!!
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inSettings && !inPause && !inSaving)
            {
                settings.SetActive(false);
                pause.SetActive(true);
                inSettings = false;
            }
            else if (!inSettings && !inPause && !inSaving)
            {
                pause.SetActive(true);
                inPause = true;
                Time.timeScale = 0;
            }
            else if (!inSettings && inPause && !inSaving)
            {
                PauseOff();
                inPause = false;
            }
            else if (!inSettings && !inPause && inSaving)
            {
                mistake.SetActive(false); //Поменять!!!!
                pause.SetActive(true);
                inSaving = false;
            }
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        inPause = false;
        Time.timeScale = 1;
    }
    public void OnSettings()
    {
        inSettings = true;
        pause.SetActive(false);
        settings.SetActive(true);
    }
    public void SavingGame()
    {
        inSaving = true;
        pause.SetActive(false);
        mistake.SetActive(true); //Поменять!!!!
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void Back(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
        pause.SetActive(true);
    }
}
