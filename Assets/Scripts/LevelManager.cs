using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    int openLevel = 0;
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
        //MaxLevel say�s�na kadar olan butonlar� aktif eder
        foreach (Button button in levelButtons)
        {
            if (openLevel <= PlayerPrefs.GetInt("MaxLevel"))
                button.enabled = true;
            else break;

            openLevel++;
        }
        openLevel = 0;
        //MaxLevel say�s�na kadar olan butonlar�n renklerini de�i�tirir
        foreach (Image image in levelImages)
        {
            if (openLevel <= PlayerPrefs.GetInt("MaxLevel"))
                image.color = new Color(255, 255, 255, 255);
            else break;
            openLevel++;

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
            if (level + 1 > PlayerPrefs.GetInt("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", level + 1);
            if(level <= 10) spawner.SetActive(false);
            isLevelUp = true;

        }
    }

    void NextLevel()
    {
        isLevelUp = false;
        if (level <= 11) audioManager.PlayAudio(audioList.endOfLevel);
        else if (level == 12) audioManager.PlayAudio(audioList.endOfGame);
        leftConfetti.Play();
        rightConfetti.Play();
        StartCoroutine(WaitForNextLevel());
    }

    

    IEnumerator WaitForNextLevel()
    {
        if (level <= 11) timer = audioManager.SoundTime(audioList.endOfLevel);
        if (level == 11) timer = audioManager.SoundTime(audioList.endOfGame);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion

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

    void Catching()
    {
        GameObject audio = GameObject.FindWithTag("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
        audioList = audio.GetComponent<AudioList>();
    }
}
