using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetected : ObjectDetected
{
    public static int circleNum;

    

    // Start is called before the first frame update
    void Start()
    {
        circleNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();

        NextLevel(circleNum);
    }

    public override void TouchDetect()
    {
        base.TouchDetect();
        if(touch.phase == TouchPhase.Began)
        {
            if(hit.collider != null && hit.collider.gameObject.CompareTag("Daire"))
            {
                circleNum++;
                Debug.Log("Daire: " + circleNum);
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
