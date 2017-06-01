using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {


    GameObject startButton, CreditsButton, exitButton;

    public Button back;
    public Text creditsText;

    void Start()
    {
        startButton = GameObject.Find("StartButton");
        CreditsButton = GameObject.Find("CreditsButton");
        exitButton = GameObject.Find("ExitButton");
        exitButton.GetComponent<Button>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void Credits()
    {
        startButton.SetActive(false);
        CreditsButton.SetActive(false);
        exitButton.SetActive(false);

        Button backButton = Instantiate(back);
        backButton.transform.SetParent(this.transform, false);
        //backButton.gameObject.SetActive(true);
        backButton.onClick.AddListener(BackToMenu);

        Text credits = Instantiate(creditsText);
        credits.transform.SetParent(this.transform, false);
    }

    public void BackToMenu()
    {        
        startButton.SetActive(true);
        CreditsButton.SetActive(true);
        exitButton.SetActive(true);
        Destroy( GameObject.FindGameObjectWithTag("BackButton"));
        Destroy(GameObject.FindGameObjectWithTag("CreditsText"));

    }

    public void Exit()
    {
        if (exitButton)
        {
            Application.Quit();
        }
    }
}
