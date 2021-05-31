using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot : MonoBehaviour, IDropHandler
{
    private static string junktag;
    public static string trashTag;
    //public GameObject Trash; 
    
    public void Awake()
    {
        
    }
    public void start()
    {
    }
    public void OnDrop(PointerEventData eventData)
    {
        trashTag = gameObject.tag;

        Debug.Log("onDrop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
            junktag = DragDrop.junkTag;
            //print("Itemslot junktag = " +junktag); //Print Check true or false
            //print("Itemslot trashtag = " +trashTag); //Print Check true or false

            if(trashTag == junktag)
            {
                DragDrop.increaseScore = true;
                //Debug.Log("Trash_is_" + trashTag + "_And_" + "Junk_Is_" + junktag);
            }

            if(trashTag != junktag)
            {
                DragDrop.decreaseScore = true;
                //Debug.Log("Trash_is_" + trashTag + "_But_" + "Junk_Is_" + junktag);
            }
            DragDrop.canDestroy = true;
            //print("canDestroy"); Check Obj canDestroy
        }

    }

}
