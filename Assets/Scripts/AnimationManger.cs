using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManger : MonoBehaviour
{
    float count, timer;
    [SerializeField] GameObject spawner;

    [SerializeField] List<GameObject> shapes;

    bool isStart;
    [SerializeField] float speed;

    AudioManager audioManager;
    AudioList audioList;

    // Start is called before the first frame update
    void Start()
    {
        Catching();
        audioManager.PlayAudio(audioList.definitionOfShape[LevelManager.level - 1]);//�ekil tan�mlama klibini oynat
        timer = audioManager.SoundTime(audioList.definitionOfShape[LevelManager.level - 1]);//Klibin s�resini al

        StartCoroutine(AnimationTime());
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) AnimationObject();
        
    }
    //Liste i�erisindeki elemanlar�n boyutlar�na sin�s de�er aral���nda (-1, 1) de�er ekle
    void AnimationObject()
    {
        count += Time.deltaTime * speed;
        foreach(GameObject shape in shapes)
        {
            shape.transform.localScale = new Vector3(1f + Mathf.Abs(Mathf.Sin(count)), 
                1f + Mathf.Abs(Mathf.Sin(count)), 1f);
        }
        
    }
    //AudioManager objesini bul ve oradaki script'leri yakala
    void Catching()
    {
        GameObject audio = GameObject.FindWithTag("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
        audioList = audio.GetComponent<AudioList>();
    }

    //Timer kadar s�re sonras�nda �ekilleri kapat
    IEnumerator AnimationTime()
    {
        yield return new WaitForSeconds(timer);
        isStart = false;
        foreach (GameObject shape in shapes)
            shape.SetActive(false);
    }

}
