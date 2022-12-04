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
        if (DragObject.isPlacement && objectTag != null)
        {
            PlaceObject();
        }
    }

    void PlaceObject()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (this.gameObject.CompareTag(objectTag) && placementObject != null && touch.phase == TouchPhase.Ended)
            {
                Debug.Log(this.gameObject.tag);
                Debug.Log("Giri�");
                placementObject.position = transform.position;
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Untagged"))
        {
            objectTag = collision.gameObject.tag;
            placementObject = collision.transform.parent;
            DragObject.isPlacement = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(objectTag != null)
        {
            DragObject.isPlacement = false;
            objectTag = null;
            placementObject = null;
        }
        
    }

}
