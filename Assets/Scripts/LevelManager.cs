using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    static int level;

    [SerializeField] List<Button> levelButtons;
    [SerializeField] List<Image> levelImages;

    [SerializeField] ParticleSystem leftConfetti, rightConfetti;
    [SerializeField] GameObject spawner;
    [SerializeField] float timer;

    bool isLevelUp;

    int openLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SetUnlockedLevel();
        }
    }

    private void Update()
    {
        EndLevel(ScoreManager.currentNum);
        if (isLevelUp) NextLevel();
    }

    #region LevelSystem
    void SetUnlockedLevel()
    {
        //MaxLevel sayýsýna kadar olan butonlarý aktif eder
        foreach (Button button in levelButtons)
        {
            if (openLevel <= PlayerPrefs.GetInt("MaxLevel"))
                button.enabled = true;
            else break;

            openLevel++;
        }
        openLevel = 0;
        //MaxLevel sayýsýna kadar olan butonlarýn renklerini deðiþtirir
        foreach (Image image in levelImages)
        {
            if (openLevel <= PlayerPrefs.GetInt("MaxLevel"))
                image.color = new Color(255, 255, 255, 255);
            else break;
            openLevel++;

        }
    }

    //Týklanan butonun ismini al
    public void GetLevelName()
    {
        string levelName = EventSystem.current.currentSelectedGameObject.name;
        LoadScene(levelName);
    }

    //Gelen string deðerine sahip sahneyi yükle
    void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    #endregion

    #region LevelEnding
    //Skor belirlenen maksimum skora eþitse bir sonraki level geç ve MaxLevel sayýsýný arttýr
    void EndLevel(int num)
    {
        if (num == ScoreManager.maxNum)
        {
            level = SceneManager.GetActiveScene().buildIndex;
            if (level > PlayerPrefs.GetInt("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", LevelManager.level);
            spawner.SetActive(false);
            leftConfetti.Play();
            rightConfetti.Play();
            isLevelUp = true;

        }
    }

    void NextLevel()
    {
        isLevelUp = false;
        StartCoroutine(WaitForNextLevel());
    }

    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion


}
