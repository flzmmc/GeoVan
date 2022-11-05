using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;

    [SerializeField] int maxNum;

    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;

    [SerializeField] float sizeMin, sizeMax;

    [SerializeField] bool randomColorCheck;

    [SerializeField] string type;

    [SerializeField] List<GameObject> spawnObjects;

    public static List<int> maxNumbers =new List<int> {0, 0, 0, 0};

    SpriteRenderer objectSR;

    Renderer _renderer;
    MaterialPropertyBlock objMPB;

    // Start is called before the first frame update
    void Start()
    {
        if(!randomColorCheck) ObjectDetected.maxNum = maxNum;
        ObjectDetected.randomColorCheck = randomColorCheck;
        //ObjectDetected.correctTag = "KDaire";
        objectSR = spawnObject.GetComponent<SpriteRenderer>();
        _renderer = spawnObject.GetComponent<Renderer>();
        objMPB = new MaterialPropertyBlock();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        for(int i=0; i<maxNumbers.Count; i++)
        {
            maxNumbers[i] = 0;
        }
        ObjectDetected.correctTag = null;
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
                if (randomColorCheck) ChangeColor();

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
            float size = Random.Range(sizeMin, sizeMax);

            radius = size;

            spawnObject.transform.localScale = new Vector3(size, size, 0f);
        }
        else if (type == "Irregular")
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


    void ChangeColor()
    {
        int random = Random.Range(0, 4);
        switch (random)
        {

            case 0:
                // spawnObject = spawnObjects[0];
                //objectSR.color = Color.blue;
                //spawnObject.tag = "MDaire";
                maxNumbers[0]++;
                //objectSR.color = Color.red;
                //    Texture2D tex = objectSR.sprite.texture;
                    objMPB.SetColor("_Color", new Color(1, 0, 0));
                //    objMPB.SetTexture("objMPB", tex);
                    objectSR.SetPropertyBlock(objMPB);
                //    Debug.Log(objMPB.GetColor("_Color"));
                //    //Debug.Log(_renderer.material.color);
                break;
            case 1:
                //spawnObject = spawnObjects[1];
                //objectSR.color = Color.green;
                //spawnObject.tag = "YDaire";
                maxNumbers[1]++;
                objectSR.color = Color.yellow;
                objMPB.SetColor("_Color", Color.yellow);
                //objectSR.SetPropertyBlock(objMPB);
                //    //Debug.Log("Yellow");
                break;
            case 2:
                //spawnObject = spawnObjects[2];
                //objectSR.color = Color.red;
                //spawnObject.tag = "KDaire";
                maxNumbers[2]++;
                objectSR.color = Color.blue;
                objMPB.SetColor("_Color", new Color(0, 0, 1));
                //objectSR.SetPropertyBlock(objMPB);
                //    //Debug.Log("Blue");
                break;
            case 3:
                //spawnObject = spawnObjects[3];
                //objectSR.color = Color.yellow;
                //spawnObject.tag = "SDaire";
                maxNumbers[3]++;
                objectSR.color = Color.green;
                objMPB.SetColor("_Color", new Color(0, 1, 0));
                //objectSR.SetPropertyBlock(objMPB);
                //    //Debug.Log("Green");
                break;
            default:
                break;
        }
        //objectSR.SetPropertyBlock(objMPB);
        //Debug.Log(objectSR.material.color);
    }

}
