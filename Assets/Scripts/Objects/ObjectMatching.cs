using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMatching : MonoBehaviour
{
    public static bool firstTouch, correctAnswer;

    Touch touch;

    List<GameObject> matchObjects = new List<GameObject>();

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
    }
    void TouchDetect()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (touch.phase == TouchPhase.Began && hit.collider != null && Camera.main.ScreenToWorldPoint(touch.position).x < 0f)
            {
                correctAnswer = false;
                firstTouch = true;
                matchObjects.Add(hit.collider.gameObject);
            }
            else if(touch.phase == TouchPhase.Ended && hit.collider == null)
            {
                firstTouch = false;
                if(matchObjects.Count > 0) matchObjects.Clear();

            }
            else if(touch.phase == TouchPhase.Ended && hit.collider != null && Camera.main.ScreenToWorldPoint(touch.position).x > 0f)
            {
                matchObjects.Add(hit.collider.gameObject);
                correctAnswer = Matching();
                firstTouch = false;
            }

        }
    }

    bool Matching()
    {
        if (matchObjects[1].CompareTag(matchObjects[0].tag)) {
            matchObjects.Clear();
            return true; 
        }
        else return false;
    }
}
