using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleDetected : ObjectDetected
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
    }

    public override void TouchDetect()
    {
        base.TouchDetect();
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Dikd�rtgen"))
            {
                rectangleNum++;

                Debug.Log("Dikd�rtgen: " + rectangleNum);
                gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
