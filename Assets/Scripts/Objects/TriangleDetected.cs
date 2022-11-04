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
        allTags = new List<string> { "M��gen", "Y��gen", "K��gen", "S��gen" };

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

        NextLevel(triangleNum);
    }

    public override void TouchDetect()
    {
        base.TouchDetect();
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("��gen"))
            {
                triangleNum++;

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
                triangleNum++;
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
