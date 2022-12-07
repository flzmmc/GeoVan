using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Kalýnan en son seviyeyi aç
    public void PlayButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel") + 1);
    }

    //Oyundaki zaman akýþýný durdur
    public void PauseButton()
    {
        Time.timeScale = 0;
    }
    //Oyundaki zaman akýþýný normale döndür
    public void ResumeButton()
    {
        Time.timeScale = 1;
    }
    //Seviyeyi tekrar yükle
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Ana menüye dön
    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
    //Oyundan çýk
    public void ExitButton()
    {
        Application.Quit();
    }

}
