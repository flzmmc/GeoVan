using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleDetected : ObjectDetected
{
    public static int rectangleNum;

    // Start is called before the first frame update
    void Start()
    {
        rectangleNum = 0;
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
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Dikdörtgen"))
            {
                rectangleNum++;

                Debug.Log("Dikdörtgen: " + rectangleNum);
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
