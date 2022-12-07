using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Kal�nan en son seviyeyi a�
    public void PlayButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel") + 1);
    }

    //Oyundaki zaman ak���n� durdur
    public void PauseButton()
    {
        Time.timeScale = 0;
    }
    //Oyundaki zaman ak���n� normale d�nd�r
    public void ResumeButton()
    {
        Time.timeScale = 1;
    }
    //Seviyeyi tekrar y�kle
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Ana men�ye d�n
    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
    //Oyundan ��k
    public void ExitButton()
    {
        Application.Quit();
    }

}
