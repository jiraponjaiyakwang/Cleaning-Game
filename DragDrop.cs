using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static DragDrop instance;
    [SerializeField] private Canvas canvas; //drag limit is canvas scale
    private RectTransform rectTransform;
    public static string junkTag;
    public static bool canDestroy;
    public static bool increaseScore;
    public static bool decreaseScore;
    private CanvasGroup canvasGroup;
    public static int score = GameManager.score;
    public Text scoreText;
    public Text lastScore;
    private void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canDestroy = false;
        increaseScore = false;
        decreaseScore = false;
    }
    void start()
    {
        junkTag = gameObject.tag;
        //Debug.Log("start " + junkTag);
    }
    public void Update()
    {   
        if(canDestroy == true)
        {
            
            if(increaseScore == true)
            {
                score += 20;
                //print("right"); //Check player true or false
            }
            else if(decreaseScore == true)
            {
                score -= 20;
                //print("wrong"); //Check player true or false
            }
            scoreText.text = score.ToString();
            increaseScore = false;
            decreaseScore = false;
            canDestroy = false;
            //Destroy(this);
            gameObject.SetActive(false);
            
        }

        int lastscore = GameManager.score;
        lastScore.text = lastscore.ToString();
        //print("LastScore_" + score); //Check update score
    }
    public void OnPointerDown(PointerEventData eventData )
    {
        junkTag = gameObject.tag;
        //Debug.Log("OnPoitnerDown "+ junkTag);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag " + junkTag);
        canvasGroup.alpha =.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag " + junkTag);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag "+ junkTag);
        canvasGroup.alpha =1f;
        canvasGroup.blocksRaycasts = true;
    }
}
