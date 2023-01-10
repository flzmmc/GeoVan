using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //MaxLevel anahtar sözcüðü varsa ve son level 1'den büyükse kalýnan son leveli aç
    //Deðilse ilk leveli aç
    public void PlayButton()
    {
        if (PlayerPrefs.HasKey("MaxLevel") && PlayerPrefs.GetInt("MaxLevel") > 1)
            SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel"));
        else SceneManager.LoadScene(1);
    }

    //Oyundaki zaman akýþýný durdur
    public void PauseButton()
    {
        LevelManager.isPlayable = false;
        Time.timeScale = 0;
    }
    //Oyundaki zaman akýþýný normale döndür
    public void ResumeButton()
    {
        LevelManager.isPlayable = false;
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
