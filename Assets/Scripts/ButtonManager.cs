using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
