using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] List<GameObject> spawnObjects;

    [SerializeField] int spawnNum;

    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;

    [SerializeField] float sizeMin, sizeMax;

    [SerializeField] float timer;

    [SerializeField] bool randomColorCheck, randomObjectCheck;

    public static int index;

    SpriteRenderer objectSR;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
        index = Random.Range(0, spawnObjects.Count);
        if (!randomObjectCheck) ObjectDetected.correctTag = spawnObject.tag;
        else ObjectDetected.correctTag = spawnObjects[index].tag;


        ObjectDetected.randomColorCheck = randomColorCheck;
        // Invoke fonksiyonu istedi�imiz olay� istedi�imiz s�re sonra �a��r�r
        // �lk timer de�i�keni oyun ba�lad�ktan ka� saniye sonra Spawn fonksiyonu �al��s�n onu s�yler
        // �kinci timer de�i�keni ise ka� saniyede bir bunun tekrar etmesi gerekti�ini belirtir
        InvokeRepeating("Spawn", timer, timer);
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        //for(int i = 0; i <spawnNum; i++)
        //{
            if (randomObjectCheck) spawnObject = RandomObstacle();
            float xPos = Random.Range(minX, maxX);
            float yPos = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(xPos, yPos, 0f);
            SetSize(spawnObject.tag);


            //Collider2D isCollide = Physics2D.OverlapCircle(spawnPos, radius);
            //if (!isCollide)
            //{
                objectSR = spawnObject.GetComponent<SpriteRenderer>();
                
                if (randomColorCheck) ChangeColor();
                else objectSR.color = Color.white;

                Instantiate(spawnObject, spawnPos, Quaternion.identity);
            //}
            //else
            //{
            //    i--;
            //}
            //if(i == maxNum - 1)
            //{

            //    ScoreManager.maxNum = SetMaxValue();
            //}
        //}
    }

    void SetSize(string type)
    {
        //float radius = 1f;
        if (type == "Daire" || type == "Kare")
        {
            float size = Random.Range(sizeMin, sizeMax);

            //radius = size;

            spawnObject.transform.localScale = new Vector3(size, size, 0f);
        }
        else if (type == "Dikd�rtgen" || type == "��gen")
        {
            bool check = true;

            float sizeX = Random.Range(sizeMin, sizeMax);
            float sizeY = Random.Range(sizeMin, sizeMax);



            while (check)
            {
                if (Mathf.Abs(sizeX - sizeY) <= 0.15f)
                {
                    sizeY = Random.Range(0.75f, 1.5f);
                }
                else
                {
                    //if (sizeX > sizeY)
                    //{
                    //    radius = sizeX;
                    //}
                    //else
                    //{
                    //    radius = sizeY;
                    //}
                    check = false;
                }
            }
            spawnObject.transform.localScale = new Vector3(sizeX, sizeY, 0f);
        }

       // return radius;
    }

    //int SetMaxValue()
    //{
    //    int num = 0;
    //    if (randomColorCheck)
    //    {
    //        index = Random.Range(0, maxNumbers.Count);
    //        num = SpawnManager.maxNumbers[index];
    //        Debug.Log(index);
    //    }
    //    if (randomObjectCheck)
    //    {
    //        index = Random.Range(0, spawnObjects.Count);
    //        ObjectDetected.correctTag = spawnObjects[index].tag;
    //        num = maxNumbers[index];
    //        Debug.Log(spawnObjects[index].tag);
    //    }
    //    //if(!randomObjectCheck && !randomColorCheck)
    //    //{
    //    //    num = maxNum;
    //    //}
    //    return num;
    //}

    void ChangeColor()
    {
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0:
                objectSR.color = Color.blue;
                break;
            case 1:
                objectSR.color = Color.green;
                break;
            case 2:
                objectSR.color = Color.red;
                break;
            case 3:
                objectSR.color = Color.yellow;
                break;
            default:
                break;
        }
    }

    GameObject RandomObstacle()
    {
        int random = Random.Range(0, 4);
        //switch (random)
        //{
        //    case 0:
        //        spawnObject = spawnObjects[0];
        //        break;
        //    case 1:
        //        spawnObject = spawnObjects[1];
        //        break;
        //    case 2:
        //        spawnObject = spawnObjects[2];
        //        break;
        //    case 3:
        //        spawnObject = spawnObjects[3];
        //        break;
        //    default:
        //        break;
        //}
        return spawnObjects[random];
    }

    //void ResetValues()
    //{
    //    for (int i = 0; i < maxNumbers.Count; i++)
    //    {
    //        maxNumbers[i] = 0;
    //    }
    //    //if (randomObjectCheck)
    //    //{
    //        for (int i = 0; i < spawnObjects.Count; i++)
    //        {
    //            spawnObjects[i].GetComponent<SpriteRenderer>().color = Color.white;
    //        }
    //    //}
    //}

}
