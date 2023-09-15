using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject loading;
    [SerializeField] GameObject saving;
    private bool inLoading = false;
    private bool inSaving = false;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        loading.SetActive(false);
        saving.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!inLoading && !inSaving)
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }

            if (inLoading && !inSaving)
            {
                loading.SetActive(false);
                pause.SetActive(true);
            }

            if (!inLoading && inSaving)
            {
                saving.SetActive(false);
                pause.SetActive(true);
            }
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        inLoading = true;
        pause.SetActive(false);
        loading.SetActive(true);
    }
    public void SaveGame()
    {
        inSaving = true;
        pause.SetActive(false);
        saving.SetActive(true);
    }   

    public void Back(GameObject canvas)
    {
        canvas.SetActive(false);
        pause.SetActive(true);
    }



}
