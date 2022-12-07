using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    float speed;
    [SerializeField] float minSpeed, maxSpeed;

    private void OnEnable()
    {
        //H�z� minumum ve maksimum de�erler aras�ndan rastgele belirle
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Objenin hareketi
        transform.Translate(Vector3.down * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //E�er obje sahnenin alt�ndaki par�aya de�erse objeyi sil
        if (collision.gameObject.CompareTag("Bottom"))
        {
            Destroy(gameObject);
        }
    }

}