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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Untagged"))
        {
            objectTag = collision.gameObject.tag;
            placementObject = collision.transform.parent;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(objectTag != null)
        {
            objectTag = null;
            placementObject = null;
        }
        
    }

}
