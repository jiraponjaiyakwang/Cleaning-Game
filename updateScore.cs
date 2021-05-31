using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour
{
    public static int score = GameManager.score;
    public Text lastScore;

    public void Update()
    {
        int lastscore = GameManager.score;
        lastScore.text = lastscore.ToString();
        print("LastScore_" + score);
    }
}
