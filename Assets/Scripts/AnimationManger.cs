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
        audioManager.PlayAudio(audioList.definitionOfShape[LevelManager.level - 1]);//Þekil tanýmlama klibini oynat
        timer = audioManager.SoundTime(audioList.definitionOfShape[LevelManager.level - 1]);//Klibin süresini al

        StartCoroutine(AnimationTime());
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) AnimationObject();
        
    }
    //Liste içerisindeki elemanlarýn boyutlarýna sinüs deðer aralýðýnda (-1, 1) deðer ekle
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

    //Timer kadar süre sonrasýnda þekilleri kapat
    IEnumerator AnimationTime()
    {
        yield return new WaitForSeconds(timer);
        isStart = false;
        foreach (GameObject shape in shapes)
            shape.SetActive(false);
    }

}
