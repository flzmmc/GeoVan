using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public static bool isPlacement = false;

    Touch touch;

    Transform dragObject;

    Vector3 firstPos;

    PlacementManager placementManager = null;
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
    }
    void TouchDetect()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if(touch.phase == TouchPhase.Began && hit.collider != null && hit.collider.gameObject.GetComponent<PlacementManager>() != null)
            {
                return;
            }

            if (touch.phase == TouchPhase.Began && hit.collider != null)
            {

                dragObject = hit.collider.gameObject.transform;
                firstPos = dragObject.position;
                
            }
            else if (touch.phase == TouchPhase.Moved && dragObject != null)
            {
                Vector3 objectPos = Camera.main.ScreenToWorldPoint(touch.position);
                objectPos.z = 0f;
                dragObject.position = objectPos;
            }
            else if (touch.phase == TouchPhase.Ended && hit.collider != null && !isPlacement)
            {
                dragObject.position = firstPos;
                dragObject = null;
            }
            else if (touch.phase == TouchPhase.Ended && hit.collider != null && isPlacement)
            {
                if(hit.collider.transform.parent.gameObject != null)
                {
                    hit.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                    hit.collider.transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;
                }
                else
                {
                    hit.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                    hit.collider.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
                }

                DragObject.isPlacement = false;
                dragObject = null;
            }

        }
    }
}
