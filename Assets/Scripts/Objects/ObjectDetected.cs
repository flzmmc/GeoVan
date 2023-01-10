using System.Collections.Generic;
using UnityEngine;

public class ObjectDetected : MonoBehaviour
{
    Touch touch;

    public static string correctTag;

    public static bool randomColorCheck;

    List<Color> correctColor = new List<Color> { Color.blue, Color.green, Color.red, Color.yellow };


    public static int index;

    private void Start()
    {
        if(randomColorCheck) index = Random.Range(0, correctColor.Count);
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
    }

    //Parmaðýn dokunuþunu algýlar ve dokunduðu yerde bir obje olup olmadýðýný kontrol eder
    //Dokunduðu yerde obje varsa tag'ýný ve koþuluna göre rengini kontrol eder
    //Doðru þekle dokunulduysa þekli siler
    void TouchDetect()
    {
        if (Input.touchCount > 0 && LevelManager.isPlayable)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (touch.phase == TouchPhase.Began && hit.collider != null && hit.collider.gameObject.CompareTag(correctTag))
            {
                if (!randomColorCheck)
                {
                    ScoreManager.currentNum++;
                    Destroy(hit.collider.gameObject);

                }
                else
                {
                    SpriteRenderer objectSR = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    if (objectSR.color == correctColor[index])
                    {
                        ScoreManager.currentNum++;
                        Destroy(hit.collider.gameObject);
                    }
                    else ScoreManager.isWrong = true;
                }
            }
            else if (touch.phase == TouchPhase.Began && hit.collider != null && !hit.collider.gameObject.CompareTag(correctTag))
                ScoreManager.isWrong = true;
            else if (touch.phase == TouchPhase.Began && hit.collider == null) ScoreManager.isWrong = true;
            Debug.Log(LevelManager.isPlayable);

        }
    }

}
