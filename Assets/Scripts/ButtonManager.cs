using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //MaxLevel anahtar s�zc��� varsa ve son level 1'den b�y�kse kal�nan son leveli a�
    //De�ilse ilk leveli a�
    public void PlayButton()
    {
        if (PlayerPrefs.HasKey("MaxLevel") && PlayerPrefs.GetInt("MaxLevel") > 1)
            SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel"));
        else SceneManager.LoadScene(1);
    }

    //Oyundaki zaman ak���n� durdur
    public void PauseButton()
    {
        LevelManager.isPlayable = false;
        Time.timeScale = 0;
    }
    //Oyundaki zaman ak���n� normale d�nd�r
    public void ResumeButton()
    {
        LevelManager.isPlayable = false;
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
