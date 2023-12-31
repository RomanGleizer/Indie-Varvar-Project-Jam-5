using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject creators;
    [SerializeField] private GameObject mistake;

    private bool inLoading = false;
    private bool inSettings = false;
    private bool inCreators = false;

    // Start is called before the first frame update
    void Start()
    {
        settings.SetActive(false);
        creators.SetActive(false);
        mistake.SetActive(false); //��������!!!!
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (inLoading && !inSettings)
            {
                mistake.SetActive(false); //��������!!!!
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
        mistake.SetActive(true); //��������!!!!
    }
    public void Creators()
    {
        inCreators = true;
        start.SetActive(false);
        creators.SetActive(true);
    }
    public void OnSettings()
    {
        inSettings = true;
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
