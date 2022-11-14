using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    float speed;
    [SerializeField] float minSpeed, maxSpeed;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        startPos = transform.position;
    }

    private void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed);
    }

    private void Update()
    {

    }

    private void OnDisable()
    {
        //transform.position = startPos;
    }

    

}
