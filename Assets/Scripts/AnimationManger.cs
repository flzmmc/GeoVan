using System.Collections;
using UnityEngine;

public class AnimationManger : MonoBehaviour
{
    float count, timer;
    [SerializeField] GameObject spawner;

    [SerializeField] GameObject circle;

    bool isStart;
    [SerializeField] float speed;

    AudioManager audioManager;
    AudioList audioList;

    // Start is called before the first frame update
    void Start()
    {
        Catching();
        audioManager.PlayAudio(audioList.definitionOfShape[LevelManager.level - 1]);
        //Debug.Log(LevelManager.level);
        timer = audioManager.SoundTime(audioList.definitionOfShape[LevelManager.level - 1]);

        StartCoroutine(Animation());
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) AnimationObject();
        
    }

    void AnimationObject()
    {
        count += Time.deltaTime * speed;
        circle.transform.localScale = new Vector3(1f + Mathf.Abs(Mathf.Sin(count)), 1f + Mathf.Abs(Mathf.Sin(count)), 1f);
    }

    void Catching()
    {
        GameObject audio = GameObject.FindWithTag("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
        audioList = audio.GetComponent<AudioList>();
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(timer);
        isStart = false;
        circle.SetActive(false);
        //spawner.SetActive(true);
    }

}
