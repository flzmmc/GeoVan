using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveManager : MonoBehaviour
{
    Touch touch;

    MaterialPropertyBlock objectMPB;
    SpriteRenderer objectSR;

    GameObject _object;

    float scale, edgeWidth, threshold, dissolveSpeed, twirlStrength;

    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(10f, 20f);
        edgeWidth = Random.Range(0.1f, 0.15f);
        dissolveSpeed = Random.Range(1f, 1.5f);
        twirlStrength = Random.Range(5f, 15f);
        threshold = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetect();
    }

    public virtual void TouchDetect()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (touch.phase == TouchPhase.Began && hit.collider != null && hit.collider.gameObject.CompareTag(ObjectDetected.correctTag))
            {
                _object = hit.collider.gameObject;
                objectSR = _object.GetComponent<SpriteRenderer>();
                objectMPB.SetFloat("_Scale", scale);
                objectMPB.SetFloat("_EdgeWidth", edgeWidth);
                objectMPB.SetFloat("_DissolveSpeed", dissolveSpeed);
                objectMPB.SetFloat("_TwirlStrength", twirlStrength);
                threshold += Time.deltaTime;
                objectMPB.SetFloat("_Threshold", threshold);
            }

        }
    }

}
