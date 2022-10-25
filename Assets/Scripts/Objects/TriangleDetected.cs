using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleDetected : ObjectDetected
{
    public static int triangleNum;

    // Start is called before the first frame update
    void Start()
    {
        triangleNum = 0;
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
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Üçgen"))
            {
                triangleNum++;

                Debug.Log("Üçgen: " + triangleNum);
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
