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
        if (DragObject.isPlacement)
        {
            PlaceObject();
        }
    }

    void PlaceObject()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (gameObject.CompareTag(objectTag) && placementObject != null && touch.phase == TouchPhase.Ended)
            {
                placementObject.position = transform.position;
                DragObject.isPlacement = false;
                Debug.Log("Place: " + DragObject.isPlacement);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectTag = collision.gameObject.tag;
        placementObject = collision.gameObject.transform;
        DragObject.isPlacement = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DragObject.isPlacement = false;
        objectTag = null;
        placementObject = null;
    }

}
