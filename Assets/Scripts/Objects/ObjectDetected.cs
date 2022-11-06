using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDetected : MonoBehaviour
{
    Touch touch;

    public static string correctTag;
    List<string> allTags;

    public static bool randomColorCheck;

    List<Color> correctColor = new List<Color> { Color.blue, Color.green, Color.red, Color.yellow };

    int index;

    private void Start()
    {
        if (randomColorCheck)
        {
            index = Random.Range(0, correctColor.Count);
            ScoreManager.maxNum = SpawnManager.maxNumbers[index];
            Debug.Log(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
        NextLevel(ScoreManager.currentNum);
    }
    public virtual void TouchDetect()
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
                    hit.collider.gameObject.SetActive(false);

                }
                else
                {
                    SpriteRenderer objectSR = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    if (objectSR.color == correctColor[index])
                    {
                        ScoreManager.currentNum++;
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }

        }
    }

    //public virtual void TouchColorDetect()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        touch = Input.GetTouch(0);
    //        ray = Camera.main.ScreenPointToRay(touch.position);
    //        hit = Physics2D.GetRayIntersection(ray);

    //    }
    //}

    public void NextLevel(int num)
    {
        //Debug.Log("Current: " + currentNum + "Number: " + num);
        if(num == ScoreManager.maxNum)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //protected void ChooseTag(List<string> allTags)
    //{
    //    int random = Random.Range(0, 4);
    //    switch (random)
    //    {

    //        case 0:
    //            correctTag = allTags[0];
    //            ScoreManager.maxNum = SpawnManager.maxNumbers[0];
    //            break;
    //        case 1:
    //            correctTag = allTags[1];
    //            ScoreManager.maxNum = SpawnManager.maxNumbers[1];
    //            break;
    //        case 2:
    //            correctTag = allTags[2];
    //            ScoreManager.maxNum = SpawnManager.maxNumbers[2];
    //            break;
    //        case 3:
    //            correctTag = allTags[3];
    //            ScoreManager.maxNum = SpawnManager.maxNumbers[3];
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
