using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public static bool isPlacement = false;

    Touch touch;

    Transform dragObject;

    Vector3 firstPos;
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
                Debug.Log(isPlacement);
                dragObject.position = firstPos;
                dragObject = null;
            }

        }
    }
}
