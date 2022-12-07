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

    [SerializeField] bool isStart;

    int openLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        if (isStart)
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
    }

    private void Update()
    {
        NextLevel(ScoreManager.currentNum);
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

    //Skor belirlenen maksimum skora eþitse bir sonraki level geç ve MaxLevel sayýsýný arttýr
    void NextLevel(int num)
    {
        if (num == ScoreManager.maxNum)
        {
            level = SceneManager.GetActiveScene().buildIndex;
            if (level > PlayerPrefs.GetInt("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", LevelManager.level);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
