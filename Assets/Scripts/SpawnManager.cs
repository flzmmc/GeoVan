using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;

    [SerializeField] int maxNum;

    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;

    

    // Start is called before the first frame update
    void Start()
    {
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

            float size = Random.Range(1f, 2f);

            spawnObject.transform.localScale = new Vector3(size, size, 0f);

            Instantiate(spawnObject, spawnPos, Quaternion.identity);
        }
    }

}
