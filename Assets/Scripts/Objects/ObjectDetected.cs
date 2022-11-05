using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDetected : MonoBehaviour
{
    protected Touch touch;

    protected Ray ray;
    protected RaycastHit2D hit;

    public static string correctTag;
    protected List<string> allTags;

    public static int maxNum, currentNum;
    public static bool randomColorCheck;

    protected SpriteRenderer objectSR;

    private void Start()
    {

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

    public virtual void TouchColorDetect()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
            hit = Physics2D.GetRayIntersection(ray);

        }
    }

    public void NextLevel(int num)
    {
        Debug.Log("Current: " + currentNum + "Number: " + num);
        if(num == maxNum)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    protected void ChooseTag(List<string> allTags)
    {
        int random = Random.Range(0, 4);
        switch (random)
        {

            case 0:
                correctTag = allTags[0];
                maxNum = SpawnManager.maxNumbers[0];
                break;
            case 1:
                correctTag = allTags[1];
                maxNum = SpawnManager.maxNumbers[1];
                break;
            case 2:
                correctTag = allTags[2];
                maxNum = SpawnManager.maxNumbers[2];
                break;
            case 3:
                correctTag = allTags[3];
                maxNum = SpawnManager.maxNumbers[3];
                break;
            default:
                break;
        }
    }
}
