using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    [SerializeField] List<Transform> objects;

    [SerializeField] float upNum = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Listeden rastgele bir eleman� se� ve yukar�dan a�a��ya do�ru s�rala
        while(objects.Count > 0)
        {
            int index = Random.Range(0, objects.Count);
            objects[index].position = new Vector3(objects[index].position.x, upNum, objects[index].position.z);
            objects.RemoveAt(index);
            upNum -= 2f;
        }
    }
}
