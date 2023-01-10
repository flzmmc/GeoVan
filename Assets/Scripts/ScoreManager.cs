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
        ScoreAudio();
        scoreText.text = currentNum.ToString() + " / " + maxNum.ToString();
    }
    //Oyuncu do�ru yaparsa ba�ar� ses klibini oynat
    //Oyuncu yanl�� yaparsa veya timer s�resi kadar bir �ey yapmazsa yanl�� cevap ses klibini oynat
    void ScoreAudio()
    {
        if (LevelManager.isPlayable) timer -= Time.deltaTime;
        if (checkNum < currentNum && currentNum < maxNum && LevelManager.isPlayable)
        {
            checkNum++;
            timer = time;
            PlayAudio(audioList.correctAnswer);
        }
        if (isWrong || timer <= 0f && LevelManager.isPlayable)
        {
            isWrong = false;
            timer = time;
            PlayAudio(audioList.wrongAnswer);
        }
    }
    //AudioManager objesini bul ve oradaki script'leri yakala
    void Catching()
    {
        GameObject audio = GameObject.FindWithTag("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
        audioList = audio.GetComponent<AudioList>();
    }
    //��ine giren klip listesinden rastgele bir klip d�nd�r
    void PlayAudio(List<AudioClip> clips)
    {
        int index = Random.Range(0, clips.Count);
        audioManager.PlayAudio(clips[index]);
    }

}
