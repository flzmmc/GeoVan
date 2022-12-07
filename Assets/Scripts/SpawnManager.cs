using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] List<GameObject> spawnObjects;


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

        //Timer süresi aralýklarýyla Spawn adlý fonksiyonu çaðýr
        InvokeRepeating("Spawn", timer, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Rastgele belirlenen pozisyondan objeyi oluþtur
    void Spawn()
    {
            if (randomObjectCheck) spawnObject = RandomObstacle();
            float xPos = Random.Range(minX, maxX);
            float yPos = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(xPos, yPos, 0f);
            SetSize(spawnObject.tag);
            objectSR = spawnObject.GetComponent<SpriteRenderer>();
                
            if (randomColorCheck) ChangeColor();
            else objectSR.color = Color.white;

            Instantiate(spawnObject, spawnPos, Quaternion.identity);
    }

    //Objenin düzgün bir obje olup olmadýðýný kontrol eder ve ona göre büyüklüðünü belirler
    void SetSize(string type)
    {
        if (type == "Daire" || type == "Kare")
        {
            float size = Random.Range(sizeMin, sizeMax);

            spawnObject.transform.localScale = new Vector3(size, size, 0f);
        }
        else if (type == "Dikdörtgen" || type == "Üçgen")
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
                    check = false;
                }
            }
            spawnObject.transform.localScale = new Vector3(sizeX, sizeY, 0f);
        }
    }

    //Objenin rengini rastgele bir þekilde deðiþtirir
    void ChangeColor()
    {
        int random = Random.Range(0, 4);
        List<Color> objectColor = new List<Color> { Color.blue, Color.green, Color.red, Color.yellow };
        objectSR.color = objectColor[random];
    }

    //Listedeki objelerden birini rastgele bir þekilde döndürür
    GameObject RandomObstacle()
    {
        int random = Random.Range(0, 4);
        return spawnObjects[random];
    }

}
