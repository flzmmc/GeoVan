using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMatching : MonoBehaviour
{
    public static bool firstTouch, correctAnswer;

    bool done = false;

    Touch touch;

    List<GameObject> matchObjects = new List<GameObject>();

    List<GameObject> doneObjects = new List<GameObject>();

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

            if (touch.phase == TouchPhase.Began && hit.collider != null)
            {
                if (matchObjects.Count > 0) matchObjects.Clear();
                if (doneObjects.Count > 0) done = CheckObject(hit.collider.gameObject);
                
                if (!done)
                {
                    correctAnswer = false;
                    firstTouch = true;
                    matchObjects.Add(hit.collider.gameObject);
                }
            }
            else if(touch.phase == TouchPhase.Ended && hit.collider == null)
            {
                firstTouch = false;
            }
            else if(touch.phase == TouchPhase.Ended && hit.collider != null)
            {
                matchObjects.Add(hit.collider.gameObject);
                correctAnswer = Matching();
                firstTouch = false;
            }

        }
    }

    bool CheckObject(GameObject hitObject)
    {
        foreach (GameObject obj in doneObjects)
        {
            if (hitObject == obj)
            {
                return true;
            }
        }
        return false;
    }

    bool Matching()
    {
        if (matchObjects[0] != matchObjects[1] && matchObjects[1].CompareTag(matchObjects[0].tag))
        {
            doneObjects.Add(matchObjects[0]);
            doneObjects.Add(matchObjects[1]);
            ScoreManager.currentNum++;
            return true;
        }
        else
        {
            return false;
        }
    }
}
