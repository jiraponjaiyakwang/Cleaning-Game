using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class Ctrl_UI : MonoBehaviour
{
    private int pressRes = 1;
    public GameObject panalSetting;
    public GameObject panalFinish;
    public GameObject ctrlData;
    public Text ResText;
    string currentScene = Ctrl_Scenes.thisScene;
    
    // Start is called before the first frame update

    void Awake()
    {
        panalSetting.SetActive(false);
        panalFinish.SetActive(false);
        ctrlData.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSetting()
    {
        panalSetting.SetActive(true);
    }

    public void CloseSetting()
    {
        panalSetting.SetActive(false);
    }

    public void OpenFinshed()
    {
        panalFinish.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    /*public void Restart()
    {
        SceneManager.LoadScene(currentScene);
        print(currentScene);
        print(Ctrl_Scenes.thisScene);
    }*/

    public void openCrtlData()
    {
        ctrlData.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
            Application.Quit();
    }

    public void SaveData(string sceneName)
    {
        ctrlData.SetActive(true);
    }
    public void ChangeRes(Text ResText)
    {
        
        if (pressRes == 0)
        {
            Screen.SetResolution(1920, 1080, true);
            ResText.text = "1920x1080";
            pressRes++;
        }

        else if(pressRes == 1)
        {
            Screen.SetResolution(1240, 720, true);
            ResText.text = "1240x720";
            pressRes++;
        }

        else if (pressRes == 2)
        {
            Screen.SetResolution(800, 600, false);
            ResText.text = "800x600";
            pressRes = 0;
        }

        
    }
}
