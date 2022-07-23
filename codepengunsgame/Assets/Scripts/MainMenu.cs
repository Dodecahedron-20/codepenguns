using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject mainMenuPage;
    private bool mainpage = true;

    [SerializeField]
    private GameObject quitPromptPage;


    // Start is called before the first frame update
    void Start()
    {
        mainMenuPage.SetActive(true);
        quitPromptPage.SetActive(false);
        //Time.timeScale = 1;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void QuitpromptON()
    {
        mainMenuPage.SetActive(false);
        quitPromptPage.SetActive(true);
    }


    public void QuitpromptOFF()
    {
        mainMenuPage.SetActive(true);
        quitPromptPage.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
