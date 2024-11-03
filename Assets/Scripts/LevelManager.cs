using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static int level;

    [SerializeField] List<Button> levelButtons;
    [SerializeField] List<Image> levelImages;

    [SerializeField] ParticleSystem leftConfetti, rightConfetti;
    [SerializeField] GameObject spawner;
    [SerializeField] float timer;

    AudioManager audioManager;
    AudioList audioList;

    bool isLevelUp;
    bool isEnd;

    public static bool isStart, isPlayable;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        isPlayable = false;
        Catching();
        StartCoroutine(StartOfLevel());
        level = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioManager.StopAudio();
            SetUnlockedLevel();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0) EndLevel(ScoreManager.currentNum);
        if (isLevelUp) NextLevel();
    }

    #region LevelSystem
    void SetUnlockedLevel()
    {
        Debug.Log(PlayerPrefs.GetInt("MaxLevel"));
        if(!PlayerPrefs.HasKey("MaxLevel") || PlayerPrefs.GetInt("MaxLevel") < 1)
        {
            PlayerPrefs.SetInt("MaxLevel", 1);
        }

        for(int i = 0; i < PlayerPrefs.GetInt("MaxLevel"); i++)
        {
            levelButtons[i].enabled = true;
            levelImages[i].color = new Color(255, 255, 255, 255);
        }
    }

    //T�klanan butonun ismini al
    public void GetLevelName()
    {
        string levelName = EventSystem.current.currentSelectedGameObject.name;
        LoadScene(levelName);
    }

    //Gelen string de�erine sahip sahneyi y�kle
    void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    #endregion

    #region LevelEnding
    //Skor belirlenen maksimum skora e�itse bir sonraki level ge� ve MaxLevel say�s�n� artt�r
    void EndLevel(int num)
    {
        if (num == ScoreManager.maxNum && !isEnd)
        {
            isPlayable = false;
            isEnd = true;
            level = SceneManager.GetActiveScene().buildIndex;
            if (level + 1 > PlayerPrefs.GetInt("MaxLevel") && level + 1 <= 12) 
                PlayerPrefs.SetInt("MaxLevel", level + 1);
            if(level <= 10) spawner.SetActive(false);
            isLevelUp = true;

        }
    }
    //Bir sonraki levele ge�meden level sonu ses klibini oynat ve konfetileri �al��t�r
    void NextLevel()
    {
        isLevelUp = false;
        if (level <= 11) audioManager.PlayAudio(audioList.endOfLevel);
        else if (level == 12) audioManager.PlayAudio(audioList.endOfGame);
        leftConfetti.Play();
        rightConfetti.Play();
        StartCoroutine(WaitForNextLevel());
    }

    
    // Level sonu klibinin uzunlu�u kadar bekle
    IEnumerator WaitForNextLevel()
    {
        if (level <= 11) timer = audioManager.SoundTime(audioList.endOfLevel);
        if (level == 11) timer = audioManager.SoundTime(audioList.endOfGame);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion
    //Levele g�re ses klibini oynat ve klip s�resi kadar bekle ard�ndan oyunu oynanabilir yap
    IEnumerator StartOfLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        
        if (index > 0 && index <= 4)
        {
            timer = audioManager.SoundTime(audioList.definitionOfShape[index - 1]);
            yield return new WaitForSeconds(timer);
            audioManager.PlayAudio(audioList.startOfLevel[index - 1]);
            //isPlayable = true;
        }
        else if (index > 4)
        {
            
            audioManager.PlayAudio(audioList.startOfLevel[index - 1]);
            yield return null;
        }
        if(index > 0)
        {
            timer = audioManager.SoundTime(audioList.startOfLevel[index - 1]);
            yield return new WaitForSeconds(timer);
            isStart = true;
            if(index <= 10) spawner.SetActive(true);
            else isPlayable = true;
        }
    }
    //AudioManager objesini bul ve oradaki script'leri yakala
    void Catching()
    {
        GameObject audio = GameObject.FindWithTag("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
        audioList = audio.GetComponent<AudioList>();
    }
}
