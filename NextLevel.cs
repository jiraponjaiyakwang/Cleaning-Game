using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject panalFinish;
    
    void Awake()
    {
        panalFinish.SetActive(false);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            Invoke("showDelay", 2.0f);
        }
    }

    void showDelay()
    {
        panalFinish.SetActive(true);
    }
}
