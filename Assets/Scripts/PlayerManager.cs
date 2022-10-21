using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Touch touch;

    Vector3 newPos;


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                newPos = Camera.main.ScreenToWorldPoint(touch.position);
                newPos.z = 0f;
                transform.position = newPos;
            }
            
        }
    }
}
