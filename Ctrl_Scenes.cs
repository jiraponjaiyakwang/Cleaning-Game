using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ctrl_Scenes : MonoBehaviour
{
    public static int sceneNum = GameManager.sceneCount;
    public static string thisScene;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {


        if(sceneNum == 0)
        {
            thisScene = "Main";
        }
        if(sceneNum == 1)
        {
            thisScene = "Level1";
        }
        if(sceneNum == 2)
        {
            thisScene = "Level2";
        }  
    }   
}
