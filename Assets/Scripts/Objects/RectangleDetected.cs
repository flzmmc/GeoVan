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
        allTags = new List<string> { "MDikdörtgen", "YDikdörtgen", "KDikdörtgen", "SDikdörtgen" };

        if (correctTag == null) ChooseTag(allTags);
        else return;
        Debug.Log(correctTag);
        Debug.Log("Maximum number: " + maxNum);
    }

    // Update is called once per frame
    void Update()
    {
        if (!randomColorCheck) TouchDetect();
        else TouchColorDetect();

        NextLevel(rectangleNum);
    }

    public override void TouchDetect()
    {
        base.TouchDetect();
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Dikdörtgen"))
            {
                rectangleNum++;

                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }

    public override void TouchColorDetect()
    {
        base.TouchColorDetect();
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag(correctTag))
            {
                rectangleNum++;
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
