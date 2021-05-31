using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collect : MonoBehaviour
{
    public int IncreaseScore;
    public static int score = GameManager.score;// Get score from GameManager
    public Text scoreText; //Text UI in canvas
    public Text lastScore;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            score += IncreaseScore;
            scoreText.text = score.ToString(); // at score value to scoreText (scoreText is text in canvas)
            Destroy(gameObject);
            //print(score);
        }
    }
    public void Update()
    {
        int lastscore = GameManager.score;
        lastScore.text = lastscore.ToString();
        //print("LastScore_" + score);  // recheck score
    }
}
