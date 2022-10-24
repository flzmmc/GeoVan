using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetected : MonoBehaviour
{
    protected Touch touch;

    protected Ray ray;
    protected RaycastHit2D hit;

    public static int circleNum, rectangleNum, squareNum, triangleNum;

    private void Start()
    {
        Debug.Log("Script çalýþtý");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void TouchDetect()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
            hit = Physics2D.GetRayIntersection(ray);

        }
    }
}
