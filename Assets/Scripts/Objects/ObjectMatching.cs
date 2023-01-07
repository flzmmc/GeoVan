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

    //Ekrana dokunuþu algýla ve eðer objeye dokunduysan matchObject listesine ekle
    //Eðer baþka bir objeye deðmezse çizgiyi sil
    //Eðer baþka bir objeye deðerse matchObject listesine ekle
    //Eðer yanlýþ bir objeye deðerse çizgiyi sil
    //Doðru objeye deðerse iki obje arasýndaki çizgiyi sildirme
    void TouchDetect()
    {
        if (Input.touchCount > 0 && LevelManager.isPlayable)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (touch.phase == TouchPhase.Began && hit.collider != null)
            {
                if (matchObjects.Count > 0) matchObjects.Clear();
                
                correctAnswer = false;
                firstTouch = true;
                matchObjects.Add(hit.collider.gameObject);
                
            }
            else if (touch.phase == TouchPhase.Began && hit.collider == null) ScoreManager.isWrong = true;

            else if(touch.phase == TouchPhase.Ended && hit.collider == null)
            {
                ScoreManager.isWrong = true;
                firstTouch = false;
            }
            else if(touch.phase == TouchPhase.Ended && hit.collider != null)
            {
                matchObjects.Add(hit.collider.gameObject);
                correctAnswer = Matching();
                if (!correctAnswer) ScoreManager.isWrong = true;
                firstTouch = false;
            }
            

        }
    }
    //matchObject listesinde iki obje varsa iki objeyi karþýlaþtýr
    //Obje kendisi deðilse ve eþleþen objelerin tag'ý aynýysa
    //Objelerin Collider2D özelliklerini kapat
    //Skoru bir kez arttýr
    //Eþleþmiyorlarsa false döndür
    bool Matching()
    {
        if (matchObjects[0] != matchObjects[1] && matchObjects[1].CompareTag(matchObjects[0].tag))
        {
            matchObjects[0].GetComponent<Collider2D>().enabled = false;
            matchObjects[1].GetComponent<Collider2D>().enabled = false;
            ScoreManager.currentNum++;
            return true;
        }
        else
        {
            return false;
        }
    }
}
