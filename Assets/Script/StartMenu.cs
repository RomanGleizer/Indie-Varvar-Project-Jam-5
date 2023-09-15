using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] GameObject start;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject loading;
    [SerializeField] GameObject saving;
    private bool Loading = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        loading.SetActive(false);
        saving.SetActive(false);
        settings.SetActive(false);
    }

    public void LoadGame()
    {
        Loading = true;
        start.SetActive(false);
        loading.SetActive(true);
    }

    public void Back(GameObject canvas)
    {
        canvas.SetActive(false);
        start.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
