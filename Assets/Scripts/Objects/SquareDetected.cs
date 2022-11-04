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
        allTags = new List<string> { "MKare", "YKare", "KKare", "SKare" };

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

        NextLevel(squareNum);
    }

    public override void TouchDetect()
    {
        base.TouchDetect();
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Kare"))
            {
                squareNum++;
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
                squareNum++;
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
