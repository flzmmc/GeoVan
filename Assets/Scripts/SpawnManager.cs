using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;

    [SerializeField] int maxNum;

    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;


    [SerializeField] string type;
    

    // Start is called before the first frame update
    void Start()
    {
        ObjectDetected.maxNum = maxNum;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for(int i = 0; i <maxNum; i++)
        {
            float xPos = Random.Range(minX, maxX);
            float yPos = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(xPos, yPos, 0f);

            float radius = SetSize(type);

            
            

            Collider2D isCollide = Physics2D.OverlapCircle(spawnPos, radius);
            if (!isCollide)
            {
                Instantiate(spawnObject, spawnPos, Quaternion.identity);
            }
            else
            {
                i--;
                Debug.Log("Collide var");
            }
        }
    }

    float SetSize(string type)
    {
        float radius = 1f;
        if (type == "Regular")
        {
            float size = Random.Range(1f, 1.5f);

            radius = size;

            spawnObject.transform.localScale = new Vector3(size, size, 0f);
        }
        else if (type == "Irregular")
        {
            bool check = true;

            float sizeX = Random.Range(0.75f, 1.5f);
            float sizeY = Random.Range(0.75f, 1.5f);



            while (check)
            {
                if (Mathf.Abs(sizeX - sizeY) <= 0.15f)
                {
                    sizeY = Random.Range(0.75f, 1.5f);
                }
                else
                {
                    if (sizeX > sizeY)
                    {
                        radius = sizeX;
                    }
                    else
                    {
                        radius = sizeY;
                    }
                    check = false;
                }
            }
            spawnObject.transform.localScale = new Vector3(sizeX, sizeY, 0f);
        }

        return radius;
    }

}
