using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    float speed;
    [SerializeField] float minSpeed, maxSpeed;

    private void OnEnable()
    {
        //Hýzý minumum ve maksimum deðerler arasýndan rastgele belirle
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
        //Eðer obje sahnenin altýndaki parçaya deðerse objeyi sil
        if (collision.gameObject.CompareTag("Bottom"))
        {
            Destroy(gameObject);
        }
    }

}