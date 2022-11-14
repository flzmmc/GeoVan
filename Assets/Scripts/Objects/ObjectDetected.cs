using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDetected : MonoBehaviour
{
    Touch touch;

    public static string correctTag;
    //List<string> allTags;

    public static bool randomColorCheck;

    List<Color> correctColor = new List<Color> { Color.blue, Color.green, Color.red, Color.yellow };


    int index;

    private void Start()
    {
        if(randomColorCheck) index = Random.Range(0, correctColor.Count);
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

            if (touch.phase == TouchPhase.Began && hit.collider != null && hit.collider.gameObject.CompareTag(correctTag))
            {
                if (!randomColorCheck)
                {
                    ScoreManager.currentNum++;
                    StartCoroutine(ObjectReset(hit));

                }
                else
                {
                    SpriteRenderer objectSR = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    if (objectSR.color == correctColor[index])
                    {
                        ScoreManager.currentNum++;
                        StartCoroutine(ObjectReset(hit));
                    }
                }
            }

        }
    }

    

    IEnumerator ObjectReset(RaycastHit2D hit)
    {
        hit.collider.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        hit.collider.gameObject.SetActive(true);
    }

}
