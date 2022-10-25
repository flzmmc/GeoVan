using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareDetected : ObjectDetected
{
    public static int squareNum;

    // Start is called before the first frame update
    void Start()
    {
        squareNum = 0;
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
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Kare"))
            {
                squareNum++;
                Debug.Log("Kare: " + squareNum);
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
