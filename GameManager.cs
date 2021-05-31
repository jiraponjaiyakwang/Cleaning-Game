using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int p2score;
    public static int sceneNum;
    public static int sceneCount;
    // Start is called before the first frame update
    void Start()
    {
        //print(playData.score + "_form_PlayData");
        //print(score + "_form_GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        score = Collect.score + DragDrop.score;
        sceneNum = Ctrl_Scenes.sceneNum;
    }
}
