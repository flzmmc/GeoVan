using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public static int currentNum, maxNum;
    int checkNum;

    [SerializeField] int minScore, maxScore;
    [SerializeField] int fixedScore;

    [SerializeField] bool fixedScoreCheck;

    [SerializeField] float time;
    float timer;

    public static bool isWrong;

    AudioManager audioManager;
    AudioList audioList;

    // Start is called before the first frame update
    void Start()
    {
        Catching();

        currentNum = 0;
        checkNum = currentNum;
        isWrong = false;
        timer = time;
        //E�er sabit skor ko�ulu yanl��sa rastgele skor belirler, do�ruysa sabit skoru al
        if (!fixedScoreCheck) maxNum = Random.Range(minScore, maxScore);
        else maxNum = fixedScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.isPlayable) timer -= Time.deltaTime;
        if(checkNum < currentNum && currentNum < maxNum && LevelManager.isPlayable)
        {
            checkNum++;
            timer = time;
            PlayAudio(audioList.correctAnswer);
        }
        if(isWrong || timer <= 0f && LevelManager.isPlayable)
        {
            isWrong = false;
            timer = time;
            PlayAudio(audioList.wrongAnswer);
        }
        scoreText.text = currentNum.ToString() + " / " + maxNum.ToString();
    }

    void Catching()
    {
        GameObject audio = GameObject.FindWithTag("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
        audioList = audio.GetComponent<AudioList>();
    }

    void PlayAudio(List<AudioClip> clips)
    {
        int index = Random.Range(0, clips.Count);
        audioManager.PlayAudio(clips[index]);
    }

}
