using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Touch touch;


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            
            if(touch.phase == TouchPhase.Began)
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<Transform>().localScale = new Vector3(2, 2, 0);
                    Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
                    hit.collider.GetComponent<SpriteRenderer>().color = newColor;
                }

            }
            
        }
    }
}
