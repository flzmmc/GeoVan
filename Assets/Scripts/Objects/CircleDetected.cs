using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetected : ObjectDetected
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
        if(touch.phase == TouchPhase.Began)
        {
            if(hit.collider != null && hit.collider.gameObject.CompareTag("Daire"))
            {
                circleNum++;
                Debug.Log("Daire: " + circleNum);
                gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
