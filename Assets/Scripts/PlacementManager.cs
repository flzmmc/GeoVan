using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    Transform placementObject;

    string objectTag;

    Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (placementObject != null && objectTag != null)
        {
            PlaceObject();
        }
    }
    //Ekrandan temas kesildiði an eþleþen objelerin taglarý aynýysa parçayý objenin pozisyonuna eþitle
    void PlaceObject()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (placementObject != null && touch.phase == TouchPhase.Ended && this.gameObject.CompareTag(objectTag))
            {
                placementObject.position = transform.position;
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                ScoreManager.currentNum++;
                DragObject.isPlacement = true;
            }
            else ScoreManager.isWrong = true;
        }
    }
    //Deðen objenin tag'ý "Untagged" deðilse objenin tag'ýný string olarak al
    //Transformunu da objenin parent'ý olarak ayarla
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Untagged"))
        {
            objectTag = collision.gameObject.tag;
            placementObject = collision.transform.parent;
        }
        
    }
    //Deðen obje ayrýlýrsa deðerleri sýfýrla
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(objectTag != null)
        {
            objectTag = null;
            placementObject = null;
        }
        
    }

}
