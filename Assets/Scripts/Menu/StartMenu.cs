using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject creators;
    private bool inLoading = false;
    private bool inSettings = false;
    private bool inCreators = false;

    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(false);
        settings.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (inLoading && !inSettings)
            {
                loading.SetActive(false);
                start.SetActive(true);
            }

            if (!inLoading && inSettings)
            {
                settings.SetActive(false);
                start.SetActive(true);
            }
        }
    }
    public void LoadGame()
    {
        inLoading = true;
        start.SetActive(false);
        loading.SetActive(true);
    }
    public void Creators()
    {
        inCreators = true;
        start.SetActive(false);
        creators.SetActive(true);
    }
    public void OnSettings()
    {
        inLoading = true;
        start.SetActive(false);
        settings.SetActive(true);
    }

    public void Back(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
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
