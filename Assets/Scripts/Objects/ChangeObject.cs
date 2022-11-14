using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    SpriteRenderer objectSR;


    private void OnEnable()
    {
        if (ObjectDetected.randomColorCheck) ChangeColor();
        else objectSR.color = Color.white;
        transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(7f, 12f), 0f);
    }

    // Start is called before the first frame update
    void Awake()
    {
        objectSR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
        {
            StartCoroutine(ResetObject());
        }
    }

    IEnumerator ResetObject()
    {
        yield return new WaitForSeconds(3);
        if(ObjectDetected.randomColorCheck) ChangeColor();
        transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(7f, 12f), 0f);
    }

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

}
