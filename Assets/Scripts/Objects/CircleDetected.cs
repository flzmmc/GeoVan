using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetected : ObjectDetected
{
    public static int circleNum;

    SpriteRenderer circleSR;

    // Start is called before the first frame update
    void Start()
    {
        circleNum = 0;
        allTags = new List<string>{ "MDaire", "YDaire", "KDaire", "SDaire"};

        if (correctTag == null) ChooseTag(allTags);
        else return;
        Debug.Log(correctTag);
        Debug.Log("Maximum number: " + maxNum);
        //circleSR = GetComponent<SpriteRenderer>();
        //if(GetComponent<Renderer>().material.color == Color.red)
        //{
        //    Debug.Log("Renderer");
        //}
        //Debug.Log(GetComponent<Renderer>().material.color);
    }

    // Update is called once per frame
    void Update()
    {
        if (!randomColorCheck) TouchDetect();
        else TouchColorDetect();

        NextLevel(circleNum);

        //if (Input.touchCount > 0)
        //{
        //    touch = Input.GetTouch(0);
        //    ray = Camera.main.ScreenPointToRay(touch.position);
        //    hit = Physics2D.GetRayIntersection(ray);
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        if (hit.collider != null)
        //        {
        //            Debug.Log(circleSR.color);
        //            //Destroy(this);
        //        }
        //    }
        //}

    }

    public override void TouchDetect()
    {
        base.TouchDetect();
        if(touch.phase == TouchPhase.Began)
        {
            if(hit.collider != null && hit.collider.gameObject.CompareTag("Daire"))
            {
                circleNum++;
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
                circleNum++;
                hit.collider.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
