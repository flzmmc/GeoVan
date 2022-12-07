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

    int openLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        foreach(Button button in levelButtons)
        {
            Debug.Log(PlayerPrefs.GetInt("MaxLevel"));
            if (openLevel <= PlayerPrefs.GetInt("MaxLevel"))
                button.enabled = true;
            else 
            { 
                openLevel = 0; 
                break; 
            }
            openLevel++;
        }
        foreach(Image image in levelImages)
        {
            if (openLevel <= PlayerPrefs.GetInt("MaxLevel"))
                image.color = new Color(255, 255, 255, 255);
            else break;
            openLevel++;
            
        }
    }

    public void GetLevelName()
    {
        string levelName = EventSystem.current.currentSelectedGameObject.name;
        LoadScene(levelName);
    }

    void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
