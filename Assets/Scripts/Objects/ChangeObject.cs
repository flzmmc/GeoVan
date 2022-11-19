using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    SpriteRenderer objectSR;

    void Awake()
    {
        objectSR = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (ObjectDetected.randomColorCheck) ChangeColor();
        else objectSR.color = Color.white;
        transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(7f, 12f), 0f);
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
